using BookManagement.Common;
using BookManagement.Data;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.Config;
using BookManagement.Helpper.PassBcrypt;
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
    public class EmployeeViewModel
    {
        public EmployeeModel EmployeeModel { get; set; }
        private IEmployeeService _employeeService;
        public PagedList<Employee, string> PagedList;
        
        public EmployeeViewModel()
        {
            PagedList = new PagedList<Employee, string>()
            {
                KeyWord = string.Empty,
                PageNumber = 1,
                RecordsPerPage = 10,
                KeySelector = (d => d.EmployeeName.ToString()),
                KeyFind = new List<Expression<Func<Employee, bool>>>()
            };

            EmployeeModel = new EmployeeModel();
            _employeeService = InstanceBase.EmployeeService;

            EmployeeModel.HiddenPage = "Hidden";
            EmployeeModel.VisiblePage = "Hidden";
        }
        #region Command
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
                    _previousPageCommand = new AsyncRelayCommand<EmployeeDto>(param => PreviousPageAsync(), null);

                return _previousPageCommand;
            }
        }

        private ICommand _nextPageCommand;

        public ICommand NextPageCommand
        {
            get
            {
                if (_nextPageCommand == null)
                    _nextPageCommand = new AsyncRelayCommand<EmployeeDto>(param => NextPageAsync(), null);

                return _nextPageCommand;
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
        private ICommand _findDataCommand;

        public ICommand FindDataCommand
        {
            get
            {
                if (_findDataCommand == null)
                    _findDataCommand = new AsyncRelayCommand<EmployeeDto>(param => FindDataAsync(), null);

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
        private ICommand _saveDataCommand;

        public ICommand SaveDataCommand
        {
            get
            {
                if (_saveDataCommand == null)
                    _saveDataCommand = new AsyncRelayCommand<Object>(param => SaveData(), null);

                return _saveDataCommand;
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
        #endregion
        private async Task GetAll()
        {
            PagedList.PageNumber = 1;

            EmployeeModel.HiddenPage = "Visible";
            EmployeeModel.VisiblePage = "Hidden";

            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
        private async Task CheckHidden()
        {
            EmployeeModel.HiddenPage = "Hidden";
            EmployeeModel.VisiblePage = "Visible";
            EmployeeModel.Model = new EmployeeDto();
            await Task.CompletedTask;
        }
        private async Task Reset()
        {
            EmployeeModel.HiddenPage = "Visible";
            EmployeeModel.VisiblePage = "Hidden";
            EmployeeModel.Model = new EmployeeDto();
            await Task.CompletedTask;
        }
        private async Task GetAllAsync(string keyWord, int pageNumber)
        {
            PagedList.PageNumber = EmployeeModel.PageIndex = pageNumber;
            //Find keyword//
            PagedList.KeyWord = keyWord;
            if (!string.IsNullOrEmpty(keyWord))
            {
                PagedList.KeyFind = new List<Expression<Func<Employee, bool>>>();
                PagedList.KeyFind.Add(x => x.EmployeeName.Contains(keyWord));
            }
            ///Get data//
            var data = await _employeeService.GetAllAsync(PagedList);
            //Pagding//
            EmployeeModel.PageSize = data.PageCount;

            //Pagination(pageNumber);
            bool isEnablePrevious = false;
            bool isEnableNext = false;
            int totalpage = EmployeeModel.PageSize;
            Extend.Pagination(ref isEnablePrevious, ref isEnableNext, ref pageNumber, totalpage);
            EmployeeModel.IsEnablePrevious = isEnablePrevious;
            EmployeeModel.IsEnableNext = isEnableNext;

            EmployeeModel.Models = Extend.ToObservableCollection(data.ListData);
        }
        private async Task GetSingleDataAsync(object value)
        {
            var items = value as System.Collections.IList;
            var authorList = items.Cast<EmployeeDto>()?.ToList();
            if (authorList != null)
            {
                foreach (var item in authorList)
                {
                    EmployeeModel.Model = item;
                }
                EmployeeModel.HiddenPage = "Hidden";
                EmployeeModel.VisiblePage = "Visible";
            }
            await Task.CompletedTask;
        }
        private async Task OpenForm()
        {
           
            await GetAllAsync(string.Empty, PagedList.PageNumber);
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
            if (!string.IsNullOrEmpty(EmployeeModel.Model.EmployeeName))
            {
                await GetAllAsync(EmployeeModel.Model.EmployeeName, PagedList.PageNumber);
            }
            else
            {
                PagedList.KeyFind = new List<Expression<Func<Employee, bool>>>();
                await GetAllAsync(string.Empty, PagedList.PageNumber);
            }
        }
        private async Task ResetData()
        {
            EmployeeModel.Model = new EmployeeDto();
            PagedList.KeyFind = new List<Expression<Func<Employee, bool>>>();
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }
        private async Task SaveData()
        {
            //EmployeeModel.Model.ValidateBookGenreName();
            if (!EmployeeModel.Model.HasErrors)
            {
                if (EmployeeModel.Model.Employeecode == Guid.Empty)
                {
                    EmployeeModel.Model.Employeecode = Guid.NewGuid();
                    EmployeeModel.Model.Position = PassBcrypt.EnhancedHashPassword(EmployeeModel.Model.Position);
                    await _employeeService.AddAsync(EmployeeModel.Model);
                }
                else
                {
                    await _employeeService.UpdateAsync(EmployeeModel.Model);
                }
                await GetAllAsync(string.Empty, PagedList.PageNumber);
                EmployeeModel.Model = new EmployeeDto();

                EmployeeModel.HiddenPage = "Visible";
                EmployeeModel.VisiblePage = "Hidden";
            }

            else
            {
                return;
            }


        }
        /// <summary>
        /// Remove data unit
        /// </summary>
        /// <param name="id"></param>
        private async Task RemoveAsync(object value)
        {

            var items = value as System.Collections.IList;
            var authorList = items.Cast<EmployeeDto>()?.ToList();
            if (authorList != null)
            {
                foreach (var item in authorList)
                {
                    await _employeeService.DeleteAsync(x => x.Employeecode == item.Employeecode);
                }
            }
            await GetAllAsync(string.Empty, PagedList.PageNumber);
        }

    }
}
