using BookManagement.Common;
using BookManagement.Data;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.Config;
using BookManagement.Model;
using BookManagement.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

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
            AuthorModel.Models = new ObservableCollection<AuthorDto>();
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

        private async Task SaveData()
        {
            if (AuthorModel <= 0)
            {
                await _unitrepository.AddUnit(Unitview.Units);
                Extend.Notification(Notice.ADDSUCCESS, Notice.OFFSETX, Notice.OFFSETY, Notice.OK);
            }
            else
            {
                await _unitrepository.UpdateUnit(Unitview.Units);
                Extend.Notification(Notice.EDITSUCCESS, Notice.OFFSETX, Notice.OFFSETY, Notice.OK);
            }

            await GetAllAsync(string.Empty, PagedList.PageNumber);
            Unitview.Units = new Unit();
        }


    }
}