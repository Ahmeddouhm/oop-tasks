using LMS;

Console.WriteLine("==================================================");
Console.WriteLine("        LIBRARY MANAGEMENT SYSTEM (LMS)");
Console.WriteLine("==================================================\n");

Library library = new Library("City Central Library");

// --- 1. SETUP: Create Books & Register Members ---
Book book1 = new Book("Design Patterns", "Gang of Four", "978-0201633610");
Book book2 = new Book("Clean Code", "Robert Martin", "978-0132350884");
Book book3 = new Book("The Pragmatic Programmer", "Andy Hunt", "978-0135957059");
Book book4 = new Book("Refactoring", "Martin Fowler", "978-0201485677");
Book book5 = new Book("Head First Design Patterns", "Eric Freeman", "978-0596007126");

library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);
library.AddBook(book4);
library.AddBook(book5);

Member member1 = new Member("Alice Johnson", "M001");
Member member2 = new Member("Bob Smith", "M002");

library.RegisterMember(member1);
library.RegisterMember(member2);

// --- 2. BASIC WORKFLOW ---
Console.WriteLine("--- 1. Initial Available Books ---");
library.DisplayAvailableBooks();
Console.WriteLine();

Console.WriteLine("--- 2. Normal Borrowing & Returning ---");
library.LendBook(member1, "978-0201633610"); // Alice borrows Design Patterns
library.DisplayAvailableBooks();
Console.WriteLine();

library.ReceiveBook(member1, "978-0201633610"); // Alice returns Design Patterns
Console.WriteLine();

// --- 3. BONUS CHALLENGE 4: ERROR HANDLING CASES ---
Console.WriteLine("--- 3. Error Handling Test Cases ---");

Console.WriteLine("\n[Case A] Borrowing with invalid ISBN:");
library.LendBook(member1, "999-0000000000");

Console.WriteLine("\n[Case B] Returning a book not borrowed by member:");
library.ReceiveBook(member1, "978-0132350884"); // Clean Code (not borrowed yet)

Console.WriteLine("\n[Case C] Borrowing a book that is already borrowed:");
library.LendBook(member1, "978-0132350884"); // Alice borrows Clean Code
library.LendBook(member2, "978-0132350884"); // Bob tries to borrow Clean Code (already borrowed)
Console.WriteLine();

// --- 4. BONUS CHALLENGE 1: MAX BORROW LIMIT (MAX 3 BOOKS) ---
Console.WriteLine("--- 4. Max Borrow Limit Test Case (Limit = 3) ---");
library.LendBook(member1, "978-0201633610"); // Alice 2nd book
library.LendBook(member1, "978-0135957059"); // Alice 3rd book
library.LendBook(member1, "978-0201485677"); // Alice 4th book (Should fail: Max Exceeded)
Console.WriteLine();

// --- 5. BONUS CHALLENGE 2: SEARCH BY TITLE & AUTHOR ---
Console.WriteLine("--- 5. Search Functionality Test Cases ---");
Console.WriteLine("\nSearching for Title 'Patterns':");
var titleResults = library.SearchByTitle("Patterns");
foreach (var book in titleResults)
{
    Console.WriteLine($"  Found: {book.Title} by {book.Author}");
}

Console.WriteLine("\nSearching for Author 'Martin':");
var authorResults = library.SearchByAuthor("Martin");
foreach (var book in authorResults)
{
    Console.WriteLine($"  Found: {book.Title} by {book.Author}");
}
Console.WriteLine();

// --- 6. BONUS CHALLENGE 3: BORROWING & RECEIVING LOGS ---
Console.WriteLine("--- 6. Borrowing & Receiving History Logs ---");
Console.WriteLine("\nBorrowing History Log:");
foreach (var log in library.BorrowingLog)
{
    Console.WriteLine($"  - {log}");
}

Console.WriteLine("\nReceiving History Log:");
foreach (var log in library.ReceivingLog)
{
    Console.WriteLine($"  - {log}");
}
Console.WriteLine("\n==================================================");