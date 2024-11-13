using BookManagement.Common;
using BookManagement.Data;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.Config;
using BookManagement.Model;
using BookManagement.Service.Interfaces;
using BookManagement.Utilities;
using SweetAlertSharp.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class AuthorViewModel
    {
        public AuthorModel AuthorModel { get; set; }
        private IAuthorService _authorService;
        public PagedList<Author, string> PagedList;

        public AuthorViewModel()
        {
            PagedList = new PagedList<Author, string>()
            {
                KeyWord = string.Empty,
                PageNumber = 1,
                RecordsPerPage = 7,
                KeySelector = (d => d.Authorcode.ToString()),
                KeyFind = new List<Expression<Func<Author, bool>>>()
            };

            AuthorModel = new AuthorModel();
            _authorService = InstanceBase.AuthorService;
        }

        private async Task GetAllAsync(string keyWord, int pageNumber)
        {
            PagedList.PageNumber = AuthorModel.PageIndex = pageNumber;
            //Find keyword//
            PagedList.KeyWord = keyWord;
            if (!string.IsNullOrEmpty(keyWord))
            {
                PagedList.KeyFind = new List<Expression<Func<Author, bool>>>();
                PagedList.KeyFind.Add(x => x.AuthorName.Contains(keyWord));
            }
            ///Get data//
            var data = await _authorService.GetAllAsync(PagedList);
            //Pagding//
            AuthorModel.PageSize = data.PageCount;

            //Pagination(pageNumber);
            bool isEnablePrevious = false;
            bool isEnableNext = false;
            int totalpage = AuthorModel.PageSize;
            Extend.Pagination(ref isEnablePrevious, ref isEnableNext, ref pageNumber, totalpage);
            AuthorModel.IsEnablePrevious = isEnablePrevious;
            AuthorModel.IsEnableNext = isEnableNext;

            AuthorModel.Models = Extend.ToObservableCollection(data.ListData);
        }
        #region Command
        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new AsyncRelayCommand<Unit>(param => SaveData(), null);

                return _saveCommand;
            }
        }

        private ICommand _previousPageCommand;

        public ICommand PreviousPageCommand
        {
            get
            {
                if (_previousPageCommand == null)
                    _previousPageCommand = new AsyncRelayCommand<Unit>(param => PreviousPageAsync(), null);

                return _previousPageCommand;
            }
        }

        private ICommand _nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                if (_nextPageCommand == null)
                    _nextPageCommand = new AsyncRelayCommand<Unit>(param => NextPageAsync(), null);

                return _nextPageCommand;
            }
        }

        private ICommand _findDataCommand;

        public ICommand FindDataCommand
        {
            get
            {
                if (_findDataCommand == null)
                    _findDataCommand = new AsyncRelayCommand<Unit>(param => FindDataAsync(), null);

                return _findDataCommand;
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
        #endregion
        private async Task GetAll()
        {
            PagedList.PageNumber = 1;
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

        private async Task SaveData()
        {
            if (AuthorModel.Model.Authorcode == Guid.Empty)
            {
                await _authorService.AddAsync(AuthorModel.Model);
            }
            else
            {
                await _authorService.UpdateAsync(AuthorModel.Model);
            }

            await GetAllAsync(string.Empty, PagedList.PageNumber);
            AuthorModel.Model = new AuthorDto();
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
            if (!string.IsNullOrEmpty(AuthorModel.Model.AuthorName))
            {
                await GetAllAsync(AuthorModel.Model.AuthorName, PagedList.PageNumber);
            }
            else
            {
                PagedList.KeyFind = new List<Expression<Func<Author, bool>>>();
                await GetAllAsync(string.Empty, PagedList.PageNumber);
            }
        }
        /// <summary>
        /// Remove data unit
        /// </summary>
        /// <param name="id"></param>
        private async Task RemoveAsync(object value)
        {
            
            var items = value as System.Collections.IList;
            var authorList = items.Cast<AuthorDto>()?.ToList();
            if (authorList != null)
            {
                foreach (var item in authorList)
                {
                    await _authorService.DeleteAsync(x => x.Authorcode == item.Authorcode);
                }
            }
            
        }

       
    }
}