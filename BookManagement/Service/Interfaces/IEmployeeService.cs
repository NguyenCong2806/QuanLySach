using BookManagement.Data;
using BookManagement.Data.Dto;
using BookManagement.Entity;
using System.Threading.Tasks;

namespace BookManagement.Service.Interfaces
{
    public interface IEmployeeService: IService<Employee, EmployeeDto>
    {
        Task<ResultLogin> LoginApp(UserLoginDto userLoginDto);
    }
}
