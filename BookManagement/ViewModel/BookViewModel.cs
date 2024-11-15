using BookManagement.Utilities;
using BookManagement.View;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BookManagement.ViewModel
{
    public class BookViewModel
    {
        public BookViewModel()
        {

        }
        private ICommand _nextPageAddAndEditCommand;

        public ICommand NextPageAddAndEditCommand
        {
            get
            {
                if (_nextPageAddAndEditCommand == null)
                    _nextPageAddAndEditCommand = new AsyncRelayCommand<object>(param => NextPage(), null);

                return _nextPageAddAndEditCommand;
            }
        }

        private async Task NextPage()
        {
            BookAddAndEdit bookAddAndEdit = new BookAddAndEdit();
            bookAddAndEdit.
            await Task.CompletedTask;
        }
        
    }
}
