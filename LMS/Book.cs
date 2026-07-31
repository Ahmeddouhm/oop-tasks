using System;
using System.Collections.Generic;
using System.Text;

namespace LMS
{
    internal class Book
    {
        public string? Title { get; private set; }
        public string? Author { get; private set; }
        public string? ISBN { get; private set; }
        public bool IsAvailable { get; private set; } = true;

        public Book()
        {
            
        }
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public string GetInfo() 
        {
            string status = IsAvailable ? "Available" : "Not Available";
            return $"Book : '{Title}' | Written By : '{Author}'" +
                   $"Book Status : '{status}' | ISBN : '{ISBN}'";
        }

        public void Borrow() 
        {
            IsAvailable = false;
        }

        public void ReturnBook() 
        {
            IsAvailable = true;
        }


    }
}
