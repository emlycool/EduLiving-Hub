﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduLiving_Hub.Models.ViewModels
{
    public class DetailGenre
    {
        public GenreDto SelectedGenre { get; set; }
        public IEnumerable<BookDto> BooksInGenre { get; set; }
    }
}