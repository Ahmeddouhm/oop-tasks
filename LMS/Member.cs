using System;
using System.Collections.Generic;
using System.Text;

namespace LMS
{
    internal class Member
    {
        public string? Name { get; private set; }
        public string? ID { get; private set; }
        public List<Book> BorrowedBooks { get; private set; }

        public int BorrowedCount => BorrowedBooks.Count;

        public Member(string name, string id)
        {
            Name = name;
            ID = id;
            BorrowedBooks = new();
        }

        public string GetInfo() 
        {
            return $"MemberID : {ID} | Name : {Name} | Borrowed Books : {BorrowedCount}";
        }

        public void BorrowBook(Book book) 
        {
            BorrowedBooks.Add(book);
        }
        public void ReturnBook(Book book) 
        {
            BorrowedBooks.Remove(book);
        }


    }
}
