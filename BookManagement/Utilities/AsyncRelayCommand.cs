using BookManagement.Repositorys.Deployment;
using BookManagement.Repositorys.Interfaces;
using System;
using System.Threading.Tasks;

namespace BookManagement.Utilities
{
    public class AsyncRelayCommand<T> : AsyncCommand<T>
    {
        public AsyncRelayCommand(Func<T, Task> execute, Func<T, bool> canExecute = null,
            IErrorHandler errorHandler = null) : base(execute, canExecute, errorHandler)
        {
        }
    }
}