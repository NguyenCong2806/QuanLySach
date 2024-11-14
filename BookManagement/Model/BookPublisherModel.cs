using BookManagement.Data;
using BookManagement.Data.Dto;
using System.Collections.ObjectModel;

namespace BookManagement.Model
{
    public class BookPublisherModel : DataModel<BookPublisherDto>
    {
        public BookPublisherModel()
        {
            Model = new BookPublisherDto();
            Models = new ObservableCollection<BookPublisherDto>();
        }
    }
}