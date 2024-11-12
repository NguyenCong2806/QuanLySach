using BookManagement.Data;
using BookManagement.Data.Dto;
using System.Collections.ObjectModel;

namespace BookManagement.Model
{
    public class AuthorModel : DataModel<AuthorDto>
    {
        public AuthorModel()
        {
            Model = new AuthorDto();
            Models = new ObservableCollection<AuthorDto>();
        }
    }
}