using BookManagement.Common;
using BookManagement.Data;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.Config;
using BookManagement.Model;
using BookManagement.Service.Interfaces;
using BookManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class BookGenreViewModel
    {
        public BookGenreModel BookGenreModel { get; set; }
        private IBookGenreService _bookGenreService;
        public PagedList<BookGenre, string> PagedList;

        public BookGenreViewModel()
        {
            PagedList = new PagedList<BookGenre, string>()
            {
                KeyWord = string.Empty,
                PageNumber = 1,
                RecordsPerPage = 10,
                KeySelector = (d => d.BookGenrecode.ToString()),
                KeyFind = new List<Expression<Func<BookGenre, bool>>>()
            };

            BookGenreModel = new BookGenreModel();
            _bookGenreService = InstanceBase.BookGenreService;
        }

        private async Task GetAllAsync(string keyWord, int pageNumber)
        {
            PagedList.PageNumber = BookGenreModel.PageIndex = pageNumber;
            //Find keyword//
            PagedList.KeyWord = keyWord;
            if (!string.IsNullOrEmpty(keyWord))
            {
                PagedList.KeyFind = new List<Expression<Func<BookGenre, bool>>>();
                PagedList.KeyFind.Add(x => x.BookGenreName.Contains(keyWord));
            }
            ///Get data//
            var data = await _bookGenreService.GetAllAsync(PagedList);
            //Pagding//
            BookGenreModel.PageSize = data.PageCount;

            //Pagination(pageNumber);
            bool isEnablePrevious = false;
            bool isEnableNext = false;
            int totalpage = BookGenreModel.PageSize;
            Extend.Pagination(ref isEnablePrevious, ref isEnableNext, ref pageNumber, totalpage);
            BookGenreModel.IsEnablePrevious = isEnablePrevious;
            BookGenreModel.IsEnableNext = isEnableNext;

            BookGenreModel.Models = Extend.ToObservableCollection(data.ListData);
        }

        #region Command

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new AsyncRelayCommand<BookGenreDto>(param => SaveData(), null);

                return _saveCommand;
            }
        }

        private ICommand _previousPageCommand;

        public ICommand PreviousPageCommand
        {
            get
            {
                if (_previousPageCommand == null)
                    _previousPageCommand = new AsyncRelayCommand<BookGenreDto>(param => PreviousPageAsync(), null);

                return _previousPageCommand;
            }
        }

        private ICommand _nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                if (_nextPageCommand == null)
                    _nextPageCommand = new AsyncRelayCommand<BookGenreDto>(param => NextPageAsync(), null);

                return _nextPageCommand;
            }
        }

        private ICommand _findDataCommand;

        public ICommand FindDataCommand
        {
            get
            {
                if (_findDataCommand == null)
                    _findDataCommand = new AsyncRelayCommand<BookGenreDto>(param => FindDataAsync(), null);

                return _findDataCommand;
            }
        }

        private ICommand _getSingleDataCommand;

        public ICommand GetSingleCommand
        {
            get
            {
                if (_getSingleDataCommand == null)
                    _getSingleDataCommand = new AsyncRelayCommand<Object>(param => GetSingleDataAsync(param), null);

                return _getSingleDataCommand;
            }
        }

        private ICommand _resetCommand;

        public ICommand ResetCommand
        {
            get
            {
                if (_resetCommand == null)
                    _resetCommand = new AsyncRelayCommand<Object>(param => ResetData(), null);

                return _resetCommand;
            }
        }

        private ICommand _removeDataCommand;

        public ICommand RemoveDataCommand
        {
            get
            {
                if (_removeDataCommand == null)
                    _removeDataCommand = new AsyncRelayCommand<object>(param => RemoveAsync(param), null);

                return _removeDataCommand;
            }
        }

        private ICommand _getAllData;

        public ICommand GetDataCommand
        {
            get
            {
                if (_getAllData == null)
                    _getAllData = new AsyncRelayCommand<object>(param => GetAll(), null);

                return _getAllData;
            }
        }

        #endregion Command

        private async Task GetAll()
        {
            PagedList.PageNumber = 1;
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

        private async Task SaveData()
        {
            BookGenreModel.Model.ValidateBookGenreName();
            if (!BookGenreModel.Model.HasErrors)
            {
                if (BookGenreModel.Model.BookGenrecode == Guid.Empty)
                {
                    BookGenreModel.Model.BookGenrecode = Guid.NewGuid();
                    await _bookGenreService.AddAsync(BookGenreModel.Model);
                }
                else
                {
                    await _bookGenreService.UpdateAsync(BookGenreModel.Model);
                }
                await GetAllAsync(string.Empty, PagedList.PageNumber);
                BookGenreModel.Model = new BookGenreDto() { BookGenrecode = new Guid(), BookGenreName = string.Empty };
            }
            else
            {
                return;
            }
        }

        private async Task GetSingleDataAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<BookGenreDto>()?.ToList();
            if (bookGenreList != null)
            {
                foreach (var item in bookGenreList)
                {
                    BookGenreModel.Model = item;
                }
            }
            await Task.CompletedTask;
        }

        private async Task NextPageAsync()
        {
            await GetAllAsync(string.Empty, PagedList.PageNumber + 1);
        }

        private async Task PreviousPageAsync()
        {
            await GetAllAsync(string.Empty, PagedList.PageNumber - 1);
        }

        private async Task FindDataAsync()
        {
            if (!string.IsNullOrEmpty(BookGenreModel.Model.BookGenreName))
            {
                await GetAllAsync(BookGenreModel.Model.BookGenreName, PagedList.PageNumber);
            }
            else
            {
                PagedList.KeyFind = new List<Expression<Func<BookGenre, bool>>>();
                await GetAllAsync(string.Empty, PagedList.PageNumber);
            }
        }

        private async Task ResetData()
        {
            BookGenreModel.Model = new BookGenreDto() { BookGenrecode = new Guid(), BookGenreName = string.Empty };
            PagedList.KeyFind = new List<Expression<Func<BookGenre, bool>>>();
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

        /// <summary>
        /// Remove data unit
        /// </summary>
        /// <param name="id"></param>
        private async Task RemoveAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<BookGenreDto>()?.ToList();
            if (bookGenreList != null)
            {
                foreach (var item in bookGenreList)
                {
                    await _bookGenreService.DeleteAsync(x => x.BookGenrecode == item.BookGenrecode);
                }
            }
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
    }
}