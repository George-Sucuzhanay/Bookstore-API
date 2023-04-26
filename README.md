##  📚 Bookstore API 📚



## 🚀 API Details
-  Created for an online bookstore to enable users to browse and purchase books.
-  Database has two tables: Books and Orders.
-  Books table contains book ID, title, author, price, and quantity information.
-  Orders table stores customer name, order ID, total amount, and date/time of the order.

## API Endpoints


- GET /order - retrieves all orders made in the bookstore
- POST /order - endpoint allows customers to place an order. The request body should include the customer name, a list of books with their IDs and quantities, and the total amount. This endpoint will create a new order in the Orders table and decrement the quantity of the books in the Books table.
- PUT /order - allows customers to add or remove books from their cart. The request body should include the customer name, book ID, and quantity. This endpoint will update the quantity of the books in the Books table and return the updated cart with the total amount.
- DELETE /order/{id} - removes a specific order for a return


## ✨ API Response Body ✨
```
"statusCode": 200,
"statusDescription": "Orders found",
```

## ✨ API Request Body ✨ 
```
 {
    "orderId": 1,
    "customerName": "George Sucuzhanay",
    "totalAmount": 250,
    "orderDate": "2023-04-20",
    "book": {
        "bookId": 1,
        "title": "Cat in the Hat",
        "author": "Dr. Seuss",
        "price": 25,
        "quantity": 2
    }
},
```

## 👩🏽‍🚀 Goals
-  Online bookstore API provides a convenient and easy way for customers to browse and purchase books
-  API endpoints enable customers to search, add books to cart, and place an order
-  If given more time, implement a decrementor on book quantity everytime a book is purchased

## 🛰️ SQL Table Creation 🛰️


```
CREATE TABLE Books (
    BookId int NOT NULL AUTO_INCREMENT,
    Title varchar(1000) NOT NULL,
    Author varchar(1000) NOT NULL,
    Price int NOT NULL,
    Quantity int NOT NULL,
    PRIMARY KEY (BookId)
)

CREATE TABLE `Orders` (
  `OrderId` int NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(1000) NOT NULL,
  `TotalAmount` int NOT NULL,
  `OrderDate` date NOT NULL,
  `BookId` int DEFAULT NULL,
  PRIMARY KEY (`OrderId`),
  KEY `FK_BookOrder` (`BookId`),
  CONSTRAINT `FK_BookOrder` FOREIGN KEY (`BookId`) REFERENCES `Books` (`BookId`)
 )
```

## 🥳 Thank You! 🥳
