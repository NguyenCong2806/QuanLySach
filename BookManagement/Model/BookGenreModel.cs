using BookManagement.Data;
using BookManagement.Data.Dto;
using System.Collections.ObjectModel;

namespace BookManagement.Model
{
    public class BookGenreModel : DataModel<BookGenreDto>
    {
        public BookGenreModel()
        {
            Model = new BookGenreDto();
            Models = new ObservableCollection<BookGenreDto>();
        }
    }
}