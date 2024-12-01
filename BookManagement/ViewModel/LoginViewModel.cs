using BookManagement.Common;
using BookManagement.Helpper.Config;
using BookManagement.Model;
using BookManagement.Service.Interfaces;
using BookManagement.Utilities;
using SweetAlertSharp.Enums;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class LoginViewModel
    {
        public bool IsLogin { get; set; } = false;
        public UserLoginModel UserLogin { get; set; }
        private IEmployeeService _employeeService;
        public LoginViewModel()
        {
            UserLogin = new UserLoginModel();
            ShutdownCommand = new AsyncRelayCommand<object>(Shutdown, null, null);
            _employeeService = InstanceBase.EmployeeService;
        }
        #region Command
        public ICommand ShutdownCommand { get; set; }
        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                    _loginCommand = new AsyncRelayCommand<object>(param => LoginApp(param), null);

                return _loginCommand;
            }
        }

        #endregion
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
        private async Task LoginApp(object obj)
        {
            var data = UserLogin.Model;
            Window loginview = obj as Window;
            if (loginview == null) return;

            var res = await _employeeService.LoginApp(data);
            if (res.IsSuccess) 
            {
                IsLogin = true;
                loginview.Close();
            }
            
        }
    }
}