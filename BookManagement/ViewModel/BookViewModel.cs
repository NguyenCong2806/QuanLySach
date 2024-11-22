using BookManagement.Common;
using BookManagement.Data;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.Config;
using BookManagement.Helpper.FileSetup;
using BookManagement.Model;
using BookManagement.Service.Interfaces;
using BookManagement.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class BookViewModel
    {
        public BookModel BookModel { get; set; }

        private IBookService _bookService;
        private IAuthorService _authorService;
        private IBookGenreService _bookGenreService;
        private IBookPublisherService _bookPublisherService;
        private ISupplierService _supplierService;

        public bool IsCheck {  get; set; }
        public string ImgName { get; set; }

        public PagedList<Book, string> PagedList;
        public BookViewModel()
        {
            PagedList = new PagedList<Book, string>()
            {
                KeyWord = string.Empty,
                PageNumber = 1,
                RecordsPerPage = 10,
                KeySelector = (d => d.BookName.ToString()),
                KeyFind = new List<Expression<Func<Book, bool>>>()
            };

            BookModel = new BookModel();

            BookModel.HiddenPage = "Hidden";
            BookModel.VisiblePage = "Hidden";

            _bookService = InstanceBase.BookService;
            _authorService = InstanceBase.AuthorService;
            _bookGenreService = InstanceBase.BookGenreService;
            _bookPublisherService = InstanceBase.BookPublisherService;
            _supplierService = InstanceBase.SupplierService;
        }

        private async Task GetAllAsync(string keyWord, int pageNumber)
        {
            PagedList.PageNumber = BookModel.PageIndex = pageNumber;
            //Find keyword//
            PagedList.KeyWord = keyWord;
            if (!string.IsNullOrEmpty(keyWord))
            {
                PagedList.KeyFind = new List<Expression<Func<Book, bool>>>();
                PagedList.KeyFind.Add(x => x.BookName.Contains(keyWord));
            }
            ///Get data//
            var data = await _bookService.GetAllAsync(PagedList);
            var dataAuthors = await _authorService.GetAll();
            var dataBookGenre = await _bookGenreService.GetAll();
            var dataBookPublisher = await _bookPublisherService.GetAll();
            var dataSupplier = await _supplierService.GetAll();
            //Pagding//
            BookModel.PageSize = data.PageCount;

            bool isEnablePrevious = false;
            bool isEnableNext = false;
            int totalpage = BookModel.PageSize;
            Extend.Pagination(ref isEnablePrevious, ref isEnableNext, ref pageNumber, totalpage);
            BookModel.IsEnablePrevious = isEnablePrevious;
            BookModel.IsEnableNext = isEnableNext;

            BookModel.Models = Extend.ToObservableCollection(data.ListData);
            BookModel.ComboBoxAuthorItemSource = new ObservableCollection<AuthorDto>(dataAuthors);
            BookModel.ComboBoxBookGenreItemSource = new ObservableCollection<BookGenreDto>(dataBookGenre);
            BookModel.ComboBoxBookPublisherItemSource = new ObservableCollection<BookPublisherDto>(dataBookPublisher);
            BookModel.ComboBoxSupplierItemSource = new ObservableCollection<SupplierDto>(dataSupplier);
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
        private ICommand _hiddenCommand;

        public ICommand HiddemCommand
        {
            get
            {
                if (_hiddenCommand == null)
                    _hiddenCommand = new AsyncRelayCommand<string>(param => CheckHidden(), null);

                return _hiddenCommand;
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
        private ICommand _openFileCommand;

        public ICommand OpenFileCommand
        {
            get
            {
                if (_openFileCommand == null)
                    _openFileCommand = new AsyncRelayCommand<Object>(param => OpenFodel(), null);

                return _openFileCommand;
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
        private ICommand _resetPageCommand;

        public ICommand ResetPageCommand
        {
            get
            {
                if (_resetPageCommand == null)
                    _resetPageCommand = new AsyncRelayCommand<object>(param => Reset(), null);

                return _resetPageCommand;
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

            BookModel.HiddenPage = "Visible";
            BookModel.VisiblePage = "Hidden";

            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
        private async Task CheckHidden()
        {
            BookModel.HiddenPage = "Hidden";
            BookModel.VisiblePage = "Visible";
            BookModel.Model = new BookDto();
            await Task.CompletedTask;
        }
        private async Task Reset()
        {
            BookModel.HiddenPage = "Visible";
            BookModel.VisiblePage = "Hidden";
            BookModel.Model = new BookDto();
            await Task.CompletedTask;
        }
        private async Task OpenFodel()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                IsCheck = true;
                ImgName = BookModel.Model.ImageUrl;
                BookModel.Model.ImageUrl = openFileDialog.FileName;
            }
            else {

                return;
            }

            await Task.CompletedTask;
        }
        private async Task SaveData()
        {
            if (!BookModel.Model.HasErrors)
            {
                BookModel.Model.BookGenrecode = BookModel.Model.BookGenreDto.BookGenrecode;
                BookModel.Model.Authorcode = BookModel.Model.AuthorDto.Authorcode;
                BookModel.Model.BookPublishercode = BookModel.Model.BookPublisherDto.BookPublishercode;
                BookModel.Model.Suppliercode = BookModel.Model.SupplierDto.Suppliercode;
                BookModel.Model.ImageUrl = FileConfig.SaveFile(BookModel.Model.ImageUrl);

                if (BookModel.Model.Bookcode == Guid.Empty)
                {
                    BookModel.Model.Bookcode = Guid.NewGuid();
                    await _bookService.AddAsync(BookModel.Model);
                }
                else
                {
                    if (IsCheck)
                    {
                        ///Xoas file cu //
                        FileConfig.DeleFileUpdate(ImgName);
                    }
                    
                    await _bookService.UpdateAsync(BookModel.Model);
                }
                await GetAllAsync(string.Empty, PagedList.PageNumber);
                BookModel.HiddenPage = "Visible";
                BookModel.VisiblePage = "Hidden";

            }
            else
            {
                return;
            }
        }

        private async Task GetSingleDataAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<BookDto>()?.ToList();
            if (bookGenreList != null)
            {
                BookDto book = bookGenreList.FirstOrDefault();
                book.ImageUrl = FileConfig.GetFileNameWithExtension(book.ImageUrl);

                BookModel.Model.AuthorDto = BookModel.ComboBoxAuthorItemSource.First(x=>x.Authorcode== book.Authorcode);
                BookModel.Model.BookGenreDto = BookModel.ComboBoxBookGenreItemSource.First(x => x.BookGenrecode == book.BookGenrecode);
                BookModel.Model.BookPublisherDto = BookModel.ComboBoxBookPublisherItemSource.First(x => x.BookPublishercode == book.BookPublishercode);
                BookModel.Model.SupplierDto = BookModel.ComboBoxSupplierItemSource.First(x => x.Suppliercode == book.Suppliercode);
                BookModel.Model = book;
                BookModel.Model.ImageUrl = FileConfig.GetFile(book.ImageUrl);

                BookModel.HiddenPage = "Hidden";
                BookModel.VisiblePage = "Visible";
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
            if (!string.IsNullOrEmpty(BookModel.Model.BookName))
            {
                await GetAllAsync(BookModel.Model.BookName, PagedList.PageNumber);
            }
            else
            {
                PagedList.KeyFind = new List<Expression<Func<Book, bool>>>();
                await GetAllAsync(string.Empty, PagedList.PageNumber);
            }
        }

        private async Task ResetData()
        {
            BookModel.Model = new BookDto();
            PagedList.KeyFind = new List<Expression<Func<Book, bool>>>();
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

        /// <summary>
        /// Remove data unit
        /// </summary>
        /// <param name="id"></param>
        private async Task RemoveAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<BookDto>()?.ToList();
            if (bookGenreList != null)
            {
                foreach (var item in bookGenreList)
                {
                    await _bookService.DeleteBookAsync(x => x.BookGenrecode == item.BookGenrecode);
                }
            }
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
    }
}