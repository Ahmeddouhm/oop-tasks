using System;
using System.Collections.Generic;
using System.Text;

namespace LMS
{
    internal class Library
    {
        public string? Name { get; set; }

        public List<Book> Books { get; set; }

        public List<Member> Members { get; set; }

        public Library(string name)
        {
            Name = name;
            Books = new();
            Members = new();
        }

        public void AddBook(Book book) 
        {
            
        }

        public void RegisterMember(Member member) 
        {
        
        }

        public void LendBook(Member member, string isbn) 
        {
            
        }

        public void ReceiveBook(Member member, string isbn) 
        {
            
        }

        public void DisplayAvailableBooks() 
        {
        
        }

        public Book Search(string isbn) 
        {
            Book book = new();
            return book;
        }


    }
}
