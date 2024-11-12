using System;

namespace BookManagement.Repositorys.Interfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}