﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduLiving_Hub.Models.ViewModels
{
    public class DetailAuthor
    {
        public AuthorDto SelectedAuthor { get; set; }
        public IEnumerable<BookDto> BooksWritten { get; set; }

    }
}