using BookManagement.Entity;
using BookManagement.Repositorys.Deployment;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Deployment;
using BookManagement.Service.Interfaces;
using System.Data.Entity;

namespace BookManagement.Helpper.Config
{
    public static class InstanceBase
    {
        /// <summary>
        /// Instance database
        /// </summary>
        private static DbContext _dbContext;
        public static DbContext DbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new WAREHOUSEBOOKEntities();
                }
                return _dbContext;
            }
        }
        #region Repository
        private static IBookGenreRepository _bookGenreRepository;
        public static IBookGenreRepository BookGenreRepository
        {
            get
            {
                if (_bookGenreRepository == null)
                {
                    _bookGenreRepository = new BookGenreRepository(DbContext);
                }
                return _bookGenreRepository;
            }
        }
        private static IAuthorRepository _authorRepository;
        public static IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(DbContext);
                }
                return _authorRepository;
            }
        }
        #endregion

        #region Service
        private static IBookGenreService _bookGenreService;
        public static IBookGenreService BookGenreService
        {
            get
            {
                if (_bookGenreService == null)
                {
                    _bookGenreService = new BookGenreService(BookGenreRepository);
                }
                return _bookGenreService;
            }
        }
        private static IAuthorService _authorService;
        public static IAuthorService AuthorService
        {
            get
            {
                if (_authorService == null)
                {
                    _authorService = new AuthorService(AuthorRepository);
                }
                return _authorService;
            }
        }
        #endregion
    }
}