using BookManagement.Common;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.Config;
using BookManagement.Service.Interfaces;
using BookManagement.Utilities;
using SweetAlertSharp.Enums;
using System;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(nameof(CurrentView)); }
        }
        public ICommand ShutdownCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand AuthorCommand { get; set; }
        public ICommand BookCommand { get; set; }
        public ICommand BookGenreCommand { get; set; }
        public ICommand BookPublisherCommand { get; set; }
        public ICommand DeliveryNoteCommand { get; set; }
        public ICommand EmployeeCommand { get; set; }
        public ICommand EmployeeRoleCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand ViewChangeCommand { get; set; }

        private async Task HomeView(object obj)
        {
            CurrentView = new HomeViewModel();
            await Task.Yield();
        }
        private async Task AuthorView(object obj)
        {
            CurrentView = new AuthorViewModel();
            await Task.Yield();
        }

        private async Task BookGenreView(object obj)
        {
            CurrentView = new BookGenreViewModel();
            await Task.Yield();
        }

        private async Task BookPublisherView(object obj)
        {
            CurrentView = new BookPublisherViewModel();
            await Task.Yield();
        }

        private async Task BookView(object obj)
        {
            CurrentView = new BookViewModel();
            await Task.Yield();
        }

        private async Task DeliveryNoteView(object obj)
        {
            CurrentView = new DeliveryNoteViewModel();
            await Task.Yield();
        }

        private async Task EmployeeRoleView(object obj)
        {
            CurrentView = new EmployeeRoleViewModel();
            await Task.Yield();
        }

        private async Task EmployeeView(object obj)
        {
            CurrentView = new EmployeeViewModel();
            await Task.Yield();
        }

        private async Task SupplierView(object obj)
        {
            CurrentView = new SupplierViewModel();
            await Task.Yield();
        }

        private async Task Shutdown(object obj)
        {
            if (Extend.SweetAlertResults(Notice.ALERTCAPTIONCLOSE, Notice.ALERTMESSAGECLOSE, Notice.OKTEXT, Notice.CANCELTEXT, SweetAlertButton.OKCancel))
            {
                Application.Current.Shutdown();
            }
            else
            {
                return;
            }
            await Task.Yield();
        }
        public bool Isloaded { get; set; } = false;
        public MainWindowViewModel()
        {
            HomeCommand = new AsyncRelayCommand<HomeViewModel>(HomeView, null, null);
            AuthorCommand = new AsyncRelayCommand<AuthorViewModel>(AuthorView, null, null);
            BookCommand = new AsyncRelayCommand<BookViewModel>(BookView, null, null);
            ShutdownCommand = new AsyncRelayCommand<object>(Shutdown, null, null);
            BookGenreCommand = new AsyncRelayCommand<BookGenreViewModel>(BookGenreView, null, null);
            BookPublisherCommand = new AsyncRelayCommand<BookPublisherViewModel>(BookPublisherView, null, null);
            DeliveryNoteCommand = new AsyncRelayCommand<DeliveryNoteViewModel>(DeliveryNoteView, null, null);
            EmployeeCommand = new AsyncRelayCommand<EmployeeViewModel>(EmployeeView, null, null);
            EmployeeRoleCommand = new AsyncRelayCommand<EmployeeRoleViewModel>(EmployeeRoleView, null, null);
            SupplierCommand = new AsyncRelayCommand<SupplierViewModel>(SupplierView, null, null);
            ViewChangeCommand = new AsyncRelayCommand<object>(ViewChanged, null, null);
            // Startup Page
            CurrentView = new HomeViewModel();
        }
        private async Task ViewChanged(object obj)
        {
            Window window = obj as Window;
            if (!Isloaded)
            {
                Isloaded = true;
                window.Hide();
                Login loginview = new Login();
                loginview.ShowDialog();
                var login = loginview.DataContext as LoginViewModel;
                if (login == null) return;
                if (login.IsLogin)
                {
                    window.Show();
                }
                else
                {
                    window.Close();
                }

            }
            await Task.Yield();
        }
    }
}