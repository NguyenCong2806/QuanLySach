using BookManagement.Common;
using BookManagement.Data.Dto;
using BookManagement.Data;
using BookManagement.Entity;
using BookManagement.Helpper.Config;
using BookManagement.Model;
using BookManagement.Service.Interfaces;
using BookManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class BookPublisherViewModel
    {
        public BookPublisherModel BookPublisherModel { get; set; }
        private IBookPublisherService _bookPublisherService;
        public PagedList<BookPublisher, string> PagedList;

        public BookPublisherViewModel()
        {
            PagedList = new PagedList<BookPublisher, string>()
            {
                KeyWord = string.Empty,
                PageNumber = 1,
                RecordsPerPage = 10,
                KeySelector = (d => d.BookPublisherName.ToString()),
                KeyFind = new List<Expression<Func<BookPublisher, bool>>>()
            };

            BookPublisherModel = new BookPublisherModel();
            _bookPublisherService = InstanceBase.BookPublisherService;
        }

        private async Task GetAllAsync(string keyWord, int pageNumber)
        {
            PagedList.PageNumber = BookPublisherModel.PageIndex = pageNumber;
            //Find keyword//
            PagedList.KeyWord = keyWord;
            if (!string.IsNullOrEmpty(keyWord))
            {
                PagedList.KeyFind = new List<Expression<Func<BookPublisher, bool>>>();
                PagedList.KeyFind.Add(x => x.BookPublisherName.Contains(keyWord));
            }
            ///Get data//
            var data = await _bookPublisherService.GetAllAsync(PagedList);
            //Pagding//
            BookPublisherModel.PageSize = data.PageCount;

            //Pagination(pageNumber);
            bool isEnablePrevious = false;
            bool isEnableNext = false;
            int totalpage = BookPublisherModel.PageSize;
            Extend.Pagination(ref isEnablePrevious, ref isEnableNext, ref pageNumber, totalpage);
            BookPublisherModel.IsEnablePrevious = isEnablePrevious;
            BookPublisherModel.IsEnableNext = isEnableNext;

            BookPublisherModel.Models = Extend.ToObservableCollection(data.ListData);
        }

        #region Command

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new AsyncRelayCommand<BookPublisherDto>(param => SaveData(), null);

                return _saveCommand;
            }
        }

        private ICommand _previousPageCommand;

        public ICommand PreviousPageCommand
        {
            get
            {
                if (_previousPageCommand == null)
                    _previousPageCommand = new AsyncRelayCommand<BookPublisherDto>(param => PreviousPageAsync(), null);

                return _previousPageCommand;
            }
        }

        private ICommand _nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                if (_nextPageCommand == null)
                    _nextPageCommand = new AsyncRelayCommand<BookPublisherDto>(param => NextPageAsync(), null);

                return _nextPageCommand;
            }
        }

        private ICommand _findDataCommand;

        public ICommand FindDataCommand
        {
            get
            {
                if (_findDataCommand == null)
                    _findDataCommand = new AsyncRelayCommand<BookPublisherDto>(param => FindDataAsync(), null);

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
            BookPublisherModel.Model.ValidateBookGenreName();
            if (!BookPublisherModel.Model.HasErrors)
            {
                if (BookPublisherModel.Model.BookPublishercode == Guid.Empty)
                {
                    BookPublisherModel.Model.BookPublishercode = Guid.NewGuid();
                    await _bookPublisherService.AddAsync(BookPublisherModel.Model);
                }
                else
                {
                    await _bookPublisherService.UpdateAsync(BookPublisherModel.Model);
                }
                await GetAllAsync(string.Empty, PagedList.PageNumber);
                BookPublisherModel.Model = new BookPublisherDto() { BookPublishercode = new Guid(), BookPublisherName = string.Empty };
            }
            else
            {
                return;
            }
        }

        private async Task GetSingleDataAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<BookPublisherDto>()?.ToList();
            if (bookGenreList != null)
            {
                foreach (var item in bookGenreList)
                {
                    BookPublisherModel.Model = item;
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
            if (!string.IsNullOrEmpty(BookPublisherModel.Model.BookPublisherName))
            {
                await GetAllAsync(BookPublisherModel.Model.BookPublisherName, PagedList.PageNumber);
            }
            else
            {
                PagedList.KeyFind = new List<Expression<Func<BookPublisher, bool>>>();
                await GetAllAsync(string.Empty, PagedList.PageNumber);
            }
        }

        private async Task ResetData()
        {
            BookPublisherModel.Model = new BookPublisherDto() { BookPublishercode = new Guid(), BookPublisherName = string.Empty };
            PagedList.KeyFind = new List<Expression<Func<BookPublisher, bool>>>();
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

        /// <summary>
        /// Remove data unit
        /// </summary>
        /// <param name="id"></param>
        private async Task RemoveAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<BookPublisherDto>()?.ToList();
            if (bookGenreList != null)
            {
                foreach (var item in bookGenreList)
                {
                    await _bookPublisherService.DeleteAsync(x => x.BookPublishercode == item.BookPublishercode);
                }
            }
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
    }
}
