using System;
using System.Collections.Generic;
using System.Text;

namespace LMS
{
    internal class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book()
        {
            
        }
        public Book(string title, string author, string isbn, bool isAvailable)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = isAvailable;
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
