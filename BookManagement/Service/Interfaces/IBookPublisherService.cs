﻿using BookManagement.Data.Dto;
using BookManagement.Entity;

namespace BookManagement.Service.Interfaces
{
    public interface IBookPublisherService : 
        IService<BookPublisher, BookPublisherDto>
    {
    }
}