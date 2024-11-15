﻿using BookManagement.Repositorys.Interfaces;
using System;
using System.Threading.Tasks;

namespace BookManagement.Utilities
{
    public static class TaskUtilities
    {
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}