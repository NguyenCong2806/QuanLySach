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
        private static IBookPublisherRepository _bookPublisherRepository;
        public static IBookPublisherRepository BookPublisherRepository
        {
            get
            {
                if (_bookPublisherRepository == null)
                {
                    _bookPublisherRepository = new BookPublisherRepository(DbContext);
                }
                return _bookPublisherRepository;
            }
        }
        private static ISupplierRepository _supplierRepository;
        public static ISupplierRepository SupplierRepository
        {
            get
            {
                if (_supplierRepository == null)
                {
                    _supplierRepository = new SupplierRepository(DbContext);
                }
                return _supplierRepository;
            }
        }
        private static IEmployeeRepository _employeeRepository;
        public static IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(DbContext);
                }
                return _employeeRepository;
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
        private static IBookPublisherService _bookPublisherService;
        public static IBookPublisherService BookPublisherService
        {
            get
            {
                if (_bookPublisherService == null)
                {
                    _bookPublisherService = new BookPublisherService(BookPublisherRepository);
                }
                return _bookPublisherService;
            }
        }
        private static ISupplierService _supplierService;
        public static ISupplierService SupplierService
        {
            get
            {
                if (_supplierService == null)
                {
                    _supplierService = new SupplierService(SupplierRepository);
                }
                return _supplierService;
            }
        }
        private static IEmployeeService _employeeService;
        public static IEmployeeService EmployeeService
        {
            get
            {
                if (_employeeService == null)
                {
                    _employeeService = new EmployeeService(EmployeeRepository);
                }
                return _employeeService;
            }
        }
        #endregion
    }
}