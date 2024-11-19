using BookManagement.Common;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.FileSetup;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;
using SweetAlertSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookManagement.Service.Deployment
{
    public class BookService: Service<Book, BookDto>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) :
            base(bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task DeleteBookAsync(Expression<Func<Book, bool>> predicate)
        {
            if (Extend.SweetAlertResults(Notice.ALERTCAPTION, Notice.ALERTMESSAGE, Notice.OKTEXT, Notice.CANCELTEXT, SweetAlertButton.OKCancel))
            {
                Book data = await _bookRepository.GetValueAsync(predicate);
                FileConfig.DeleFile(data.ImageUrl);
                await _bookRepository.DeleteAsync(predicate);

                Extend.Notification(Notice.DELETESUCCESS, Notice.OFFSETX, Notice.OFFSETY, Notice.OK);
            }
            else
            {
                return;
            }
        }
    }
}
