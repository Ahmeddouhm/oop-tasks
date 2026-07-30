using System;
using System.Collections.Generic;
using System.Text;

namespace LMS
{
    internal class Member
    {
        public string? Name { get; set; }
        public string? ID { get; set; }
        public List<Book> BorrowedBooks { get; set; }

        public int BorrowedCount;

        public Member(string name, string id)
        {
            Name = name;
            ID = id;
            BorrowedBooks = new();
            BorrowedCount = BorrowedBooks.Count;
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
