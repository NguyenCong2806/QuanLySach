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
    public class SupplierViewModel
    {
        public SupplierModel SupplierModel { get; set; }
        private ISupplierService _supplierService;
        public PagedList<Supplier, string> PagedList;

        public SupplierViewModel()
        {
            PagedList = new PagedList<Supplier, string>()
            {
                KeyWord = string.Empty,
                PageNumber = 1,
                RecordsPerPage = 10,
                KeySelector = (d => d.SupplierName.ToString()),
                KeyFind = new List<Expression<Func<Supplier, bool>>>()
            };

            SupplierModel = new SupplierModel();
            _supplierService = InstanceBase.SupplierService;
        }

        private async Task GetAllAsync(string keyWord, int pageNumber)
        {
            PagedList.PageNumber = SupplierModel.PageIndex = pageNumber;
            //Find keyword//
            PagedList.KeyWord = keyWord;
            if (!string.IsNullOrEmpty(keyWord))
            {
                PagedList.KeyFind = new List<Expression<Func<Supplier, bool>>>();
                PagedList.KeyFind.Add(x => x.SupplierName.Contains(keyWord));
            }
            ///Get data//
            var data = await _supplierService.GetAllAsync(PagedList);
            //Pagding//
            SupplierModel.PageSize = data.PageCount;

            //Pagination(pageNumber);
            bool isEnablePrevious = false;
            bool isEnableNext = false;
            int totalpage = SupplierModel.PageSize;
            Extend.Pagination(ref isEnablePrevious, ref isEnableNext, ref pageNumber, totalpage);
            SupplierModel.IsEnablePrevious = isEnablePrevious;
            SupplierModel.IsEnableNext = isEnableNext;

            SupplierModel.Models = Extend.ToObservableCollection(data.ListData);
        }

        #region Command

        private ICommand _saveCommand;

        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                    _saveCommand = new AsyncRelayCommand<SupplierDto>(param => SaveData(), null);

                return _saveCommand;
            }
        }

        private ICommand _previousPageCommand;

        public ICommand PreviousPageCommand
        {
            get
            {
                if (_previousPageCommand == null)
                    _previousPageCommand = new AsyncRelayCommand<SupplierDto>(param => PreviousPageAsync(), null);

                return _previousPageCommand;
            }
        }

        private ICommand _nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                if (_nextPageCommand == null)
                    _nextPageCommand = new AsyncRelayCommand<SupplierDto>(param => NextPageAsync(), null);

                return _nextPageCommand;
            }
        }

        private ICommand _findDataCommand;

        public ICommand FindDataCommand
        {
            get
            {
                if (_findDataCommand == null)
                    _findDataCommand = new AsyncRelayCommand<SupplierDto>(param => FindDataAsync(), null);

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
            SupplierModel.Model.ValidateSupplierName();
            if (!SupplierModel.Model.HasErrors)
            {
                if (SupplierModel.Model.Suppliercode == Guid.Empty)
                {
                    SupplierModel.Model.Suppliercode = Guid.NewGuid();
                    await _supplierService.AddAsync(SupplierModel.Model);
                }
                else
                {
                    await _supplierService.UpdateAsync(SupplierModel.Model);
                }
                await GetAllAsync(string.Empty, PagedList.PageNumber);
                SupplierModel.Model = new SupplierDto() { Suppliercode = new Guid(), SupplierName = string.Empty };
            }
            else
            {
                return;
            }
        }

        private async Task GetSingleDataAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<SupplierDto>()?.ToList();
            if (bookGenreList != null)
            {
                foreach (var item in bookGenreList)
                {
                    SupplierModel.Model = item;
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
            if (!string.IsNullOrEmpty(SupplierModel.Model.SupplierName))
            {
                await GetAllAsync(SupplierModel.Model.SupplierName, PagedList.PageNumber);
            }
            else
            {
                PagedList.KeyFind = new List<Expression<Func<Supplier, bool>>>();
                await GetAllAsync(string.Empty, PagedList.PageNumber);
            }
        }

        private async Task ResetData()
        {
            SupplierModel.Model = new SupplierDto() { Suppliercode = new Guid(), SupplierName = string.Empty };
            PagedList.KeyFind = new List<Expression<Func<Supplier, bool>>>();
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

        /// <summary>
        /// Remove data unit
        /// </summary>
        /// <param name="id"></param>
        private async Task RemoveAsync(object value)
        {
            var items = value as System.Collections.IList;
            var bookGenreList = items.Cast<SupplierDto>()?.ToList();
            if (bookGenreList != null)
            {
                foreach (var item in bookGenreList)
                {
                    await _supplierService.DeleteAsync(x => x.Suppliercode == item.Suppliercode);
                }
            }
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
    }
}
