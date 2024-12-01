using BookManagement.Common;
using BookManagement.Data;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using BookManagement.Helpper.PassBcrypt;
using BookManagement.Repositorys.Interfaces;
using BookManagement.Service.Interfaces;
using System.Threading.Tasks;

namespace BookManagement.Service.Deployment
{
    public class EmployeeService: Service<Employee, EmployeeDto>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) :
            base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ResultLogin> LoginApp(UserLoginDto userLoginDto)
        {
            ResultLogin resultLogin = new ResultLogin();
            resultLogin.IsSuccess = false;
            resultLogin.Notice = string.Empty;
            var data = await _employeeRepository.GetValueAsync(x=>x.EmployeeName==userLoginDto.UserName);
            if (data != null)
            {
                if (PassBcrypt.VerifyEnhanced(userLoginDto.PassWord,data.Position))
                {
                    resultLogin.IsSuccess = true;
                    resultLogin.Notice = Notice.LOGINSUCCESS;
                }
                else
                {
                    resultLogin.IsSuccess = false;
                    resultLogin.Notice = Notice.PASSWORDNOT;
                }
            }
            else 
            {
                resultLogin.IsSuccess = false;
                resultLogin.Notice = Notice.USERNAMENOT;
            }
            return resultLogin;
        }
    }
}
