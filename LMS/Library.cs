using System;
using System.Collections.Generic;
using System.Text;

namespace LMS
{
    internal class Library
    {
        public string? Name { get; set; }

        public List<Book> Books { get; private set; }

        public List<Member> Members { get; private set; }
        public List<string> BorrowingLog { get; private set; }
        public List<string> ReceivingLog { get; private set; }

        public Library(string name)
        {
            Name = name;
            Books = new();
            Members = new();
            BorrowingLog = new();
            ReceivingLog = new();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RegisterMember(Member member)
        {
            Members.Add(member);
        }

        // Bonus : Max Borrow Count .
        public void LendBook(Member? member, string? isbn)
        {
            if (member is null)
            {
                Console.WriteLine("Member Not Found !");
                return;
            }

            Book? book = Search(isbn ?? "");

            if (book is null)
            {
                Console.WriteLine("Book Not Found !");
                return;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine("Book isn't Available Now !");
                return;
            }

            if (member.BorrowedCount >= 3)
            {
                Console.WriteLine("Max Borrowing Exceeded !");
                return;
            }

            member.BorrowBook(book);
            book.Borrow();
            Console.WriteLine($"{member.Name} borrowed: {book.Title} | {member.Name} Borrowing Count Now = {member.BorrowedCount}");
            BorrowingLog.Add($"{book.Title}, {DateTime.Now.ToString()}");
        }

        public void ReceiveBook(Member member, string isbn)
        {
            Book? returnBook = null;

            foreach (var book in member.BorrowedBooks)
            {
                if (book.ISBN == isbn)
                {
                    returnBook = book;
                    break;
                }
            }

            if (returnBook is null)
            {
                Console.WriteLine("Book is Already Available !");
                return;
            }

            if (returnBook.IsAvailable)
            {
                Console.WriteLine("Book is Already Available !");
                return;
            }

            member.ReturnBook(returnBook);
            returnBook.ReturnBook();
            Console.WriteLine($"{member.Name} returned: {returnBook.Title} | {member.Name} Borrowing Count Now = {member.BorrowedCount}");
            ReceivingLog.Add($"{returnBook.Title}, {DateTime.Now.ToString()}");

        }

        /*
         Available books in City Central Library:
            - Design Patterns by Gang of Four (ISBN: 978-0201633610)
            - Clean Code by Robert Martin (ISBN: 978-0132350884)
            - The Pragmatic Programmer by Andy Hunt (ISBN: 978-0135957059)
         */
        public void DisplayAvailableBooks()
        {
            Console.WriteLine($"Available books in {Name} :");
            foreach (var book in Books)
            {
                if (book.IsAvailable)
                {
                    Console.WriteLine($"    - {book.Title} by {book.Author} (ISBN: {book.ISBN})");
                }
            }
        }

        public Book? Search(string isbn)
        {
            foreach (var book in Books)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }
            }
            return null;
        }

        public List<Book> SearchByTitle(string title)
        {
            List<Book> result = new();
            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Title Can't be Null");
                return result;
            }
            foreach (var book in Books)
            {
                if (book.Title is not null &&  book.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                {
                     result.Add(book);
                }
            }
            return result;
        }
        public List<Book> SearchByAuthor(string author)
        {
            List<Book> result = new();

            if (author is null)
            {
                Console.WriteLine("Author Can't be Null");
                return result;
            }

            foreach (var book in Books)
            {
                if (book.Author is not null && book.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                {
                     result.Add(book);
                }
            }
            return result;
        }


    }
}
