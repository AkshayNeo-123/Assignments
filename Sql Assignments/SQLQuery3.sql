CREATE DATABASE BookStoreDB
use BookStoreDB

--Create the Authors Table

create table Authors (
AuthorId INT IDENTITY PRIMARY KEY,
Name VARCHAR (100) NOT NULL,
Country VARCHAR (100)
); 

--Create the Books Table

CREATE TABLE Books (
    BookID INT PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    AuthorID INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    PublishedYear INT NOT NULL,
    FOREIGN KEY (AuthorID) REFERENCES Authors(AuthorID) ON DELETE CASCADE
)

--Create the Customers Table

create table Customers(
CustomerID INT primary key,
Name varchar(255) NOT NULL,
Email varchar(255) UNIQUE NOT NULL,
PhoneNumber varchar(15) NOT NULL
)

--Create the Orders Table

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY, 
    CustomerID INT NOT NULL, 
    OrderDate DATE NOT NULL, 
    TotalAmount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE
)

--Create the Orders Item Table

CREATE TABLE OrderItems (
    OrderItemID INT PRIMARY KEY, 
    OrderID INT NOT NULL, 
    BookID INT NOT NULL, 
    Quantity INT NOT NULL, 
    SubTotal DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (BookID) REFERENCES Books(BookID) ON DELETE CASCADE
)

--Insert Data into the Tables

INSERT INTO Authors (Name, Country) 
VALUES 
('J.K. Rowling', 'United Kingdom'),
('George R.R. Martin', 'United States')

INSERT INTO Books (BookID, Title, AuthorID, Price, PublishedYear)
VALUES 
(1, 'Harry Potter and the Sorcerer''s Stone', 1, 19.99, 2021),
(2, 'A Game of Thrones', 2, 24.99, 2000)

INSERT INTO Customers (CustomerID, Name, Email, PhoneNumber)
VALUES 
(1, 'Ajay', 'ajay@ex.com', '1234567890'),
(2, 'Mahesh', 'mahi@ex.com', '0987654321')

INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES 
(1, 1, '2025-03-06', 44.98),
(2, 2, '2025-03-06', 49.98)

INSERT INTO OrderItems (OrderItemID, OrderID, BookID, Quantity, SubTotal)
VALUES 
(1, 1, 1, 1, 19.99),
(2, 1, 2, 1, 24.99),
(3, 2, 1, 2, 39.98),
(4, 2, 2, 1, 24.99)

--Select All Books by a Specific Author

SELECT Title, Price, PublishedYear
FROM Books
WHERE AuthorID = 1

--Join Orders with Order Items

SELECT o.OrderID, o.OrderDate, oi.Quantity, oi.SubTotal
FROM Orders o
JOIN OrderItems oi ON o.OrderID = oi.OrderID
WHERE o.CustomerID = 1

--Total Amount of Each Order

SELECT o.OrderID, SUM(oi.SubTotal) AS TotalAmount
FROM Orders o
JOIN OrderItems oi ON o.OrderID = oi.OrderID
GROUP BY o.OrderID

--Update the Price of a Book

UPDATE Books
SET Price = 22.99
WHERE BookID = 1

--Delete an Order

DELETE FROM Orders
WHERE OrderID = 2

--Count the Number of Books Ordered by Each Customer

SELECT c.Name, COUNT(oi.OrderItemID) AS BooksOrdered
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN OrderItems oi ON o.OrderID = oi.OrderID
GROUP BY c.CustomerID, c.Name

--Add a New Column to the Orders Table

ALTER TABLE Orders
ADD ShippingAddress VARCHAR(255)

--Add a Unique Constraint to the PhoneNumber Column

ALTER TABLE Customers
ADD CONSTRAINT unique_phone UNIQUE (PhoneNumber)

--Modify a Column's Data Type

ALTER TABLE Books
ALTER COLUMN Price DECIMAL(12, 2)


--To Insert at least 5 records into each table

INSERT INTO Authors (Name, Country)
VALUES
('Mark Zuckerberg', 'United States'),
('J.R.R. Tolkien', 'United Kingdom'),
('Haruki Murakami', 'Japan')


INSERT INTO Books (BookID, Title, AuthorID, Price, PublishedYear)
VALUES 
(3, 'Learn SQL in 24 Hours', 3, 1800, 2019),
(4, 'SQL for Beginners', 4, 2200, 2021),
(5, 'Mastering SQL Queries', 5, 2023, 2023)


INSERT INTO Customers (CustomerID, Name, Email, PhoneNumber)
VALUES
(3, 'Raj B', 'raj@example.com', '555-9101'),
(4, 'Aman A', 'aman@example.com', '555-1122'),
(5, 'john M', 'john@example.com', '555-3344');

INSERT INTO Orders (OrderID, CustomerID, OrderDate, TotalAmount)
VALUES
(3, 3, '2023-03-10', 4500.00),
(4, 4, '2023-03-15', 2200.00),
(5, 5, '2023-03-20', 5000.00);

-- Insert OrderItems
INSERT INTO OrderItems (OrderItemID, OrderID, BookID, Quantity, SubTotal)
VALUES
(5, 4, 5, 2, 5000.00)

--Update the price of a book titled "SQL Mastery" by increasing it by 10%

UPDATE Books
SET Price = Price * 1.10
WHERE Title = 'SQL Mastery'


--Delete a customer who has not placed any orders

DELETE FROM Customers
WHERE CustomerID NOT IN (SELECT DISTINCT CustomerID FROM Orders)

-- Retrieve all books with a price greater than 2000

SELECT * 
FROM Books
WHERE Price > 2000;

--Find the total number of books available

SELECT COUNT(*) AS TotalBooks
FROM Books

--Find books published between 2015 and 2023

SELECT * 
FROM Books
WHERE PublishedYear BETWEEN 2015 AND 2023

-- Find all customers who have placed at least one order

SELECT DISTINCT c.*
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID


-- Retrieve books where the title contains the word "SQL"

SELECT * 
FROM Books
WHERE Title LIKE '%SQL%'

-- Find the most expensive book in the store

SELECT TOP 1 * 
FROM Books
ORDER BY Price DESC


--Retrieve customers whose name starts with "A" or "J"

SELECT * 
FROM Customers
WHERE Name LIKE 'A%' OR Name LIKE 'J%'

--Calculate the total revenue from all orders

SELECT SUM(TotalAmount) AS TotalRevenue
FROM Orders

-- JOINS ---------

--1)Retrieve all book titles along with their respective author names

SELECT b.Title, a.Name AS AuthorName
FROM Books b
JOIN Authors a ON b.AuthorID = a.AuthorID

--2)List all customers and their orders (if any)

SELECT c.Name AS CustomerName, o.OrderID, o.OrderDate, o.TotalAmount
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID

--3)Find all books that have never been ordered

SELECT b.Title
FROM Books b
LEFT JOIN OrderItems oi ON b.BookID = oi.BookID
WHERE oi.OrderID IS NULL

--4)Retrieve the total number of orders placed by each customer

SELECT c.Name AS CustomerName, COUNT(o.OrderID) AS TotalOrders
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.Name

--5)Find the books ordered along with the quantity for each order

SELECT o.OrderID, b.Title, oi.Quantity
FROM OrderItems oi
JOIN Books b ON oi.BookID = b.BookID
JOIN Orders o ON oi.OrderID = o.OrderID


--6)Display all customers, even those who haven’t placed any orders

SELECT c.Name AS CustomerName, o.OrderID
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID

--7)Find authors who have not written any books

SELECT a.Name AS AuthorName
FROM Authors a
LEFT JOIN Books b ON a.AuthorID = b.AuthorID
WHERE b.BookID IS NULL




--SubQueries---------

--1)Find the customer(s) who placed the first order (earliest OrderDate)

SELECT Name
FROM Customers
WHERE CustomerID = (
    SELECT TOP 1 CustomerID
    FROM Orders
    ORDER BY OrderDate ASC
)


--2)Find the customer(s) who placed the most orders

SELECT Name
FROM Customers
WHERE CustomerID = (
    SELECT TOP 1 CustomerID
    FROM Orders
    GROUP BY CustomerID
    ORDER BY COUNT(OrderID) DESC)

--3)Find customers who have not placed any orders

SELECT Name
FROM Customers
WHERE CustomerID NOT IN (
    SELECT CustomerID
    FROM Orders
)

--4)Retrieve all books cheaper than the most expensive book written by any author based on your data

SELECT Title, Price
FROM Books
WHERE Price < (
    SELECT MAX(Price)
    FROM Books
)


--5)List all customers whose total spending is greater than the average spending of all customers

SELECT Name
FROM Customers
WHERE CustomerID IN (
    SELECT CustomerID
    FROM Orders
    GROUP BY CustomerID
    HAVING SUM(TotalAmount) > (
        SELECT AVG(TotalAmount)
        FROM Orders
    )
)


-- Stored Procedures----------------

--1)Stored Procedure that accepts a CustomerID and returns all orders placed by that customer


CREATE PROCEDURE GetOrders
    @CustomerID INT
AS
BEGIN
    SELECT OrderID, OrderDate, TotalAmount
    FROM Orders
    WHERE CustomerID = @CustomerID;
END

EXEC GetOrders @CustomerID = 1

--2) Stored Procedure that accepts MinPrice and MaxPrice as parameters and returns all books within that price range

CREATE PROCEDURE GetBooksByPriceRange
    @MinPrice DECIMAL(10, 2),
    @MaxPrice DECIMAL(10, 2)
AS
BEGIN
    SELECT BookID, Title, Price, PublishedYear
    FROM Books
    WHERE Price BETWEEN @MinPrice AND @MaxPrice;
END

--Create a view named AvailableBooks that shows only books that are in stock, including BookID, Title, AuthorID, Price, and PublishedYear

CREATE VIEW AvailableBooks AS
SELECT BookID, Title, AuthorID, Price, PublishedYear
FROM Books
WHERE Price > 0

SELECT * FROM AvailableBooks


--101949986330