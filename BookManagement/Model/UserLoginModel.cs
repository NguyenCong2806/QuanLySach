using BookManagement.Data;
using BookManagement.Data.Dto;

namespace BookManagement.Model
{
    public class UserLoginModel : DataModel<UserLoginDto>
    {
        public UserLoginModel()
        {
            Model = new UserLoginDto();
        }
    }
}
