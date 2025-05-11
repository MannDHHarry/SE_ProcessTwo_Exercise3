create database OrderManagement
Go

use OrderManagement
Go
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY,
    UserName NVARCHAR(50),
    email NVARCHAR(100),
    password NVARCHAR(50),
    lock BIT
);

CREATE TABLE Item (
    ItemID INT PRIMARY KEY IDENTITY,
    ItemName NVARCHAR(50),
    Size NVARCHAR(20)
);

CREATE TABLE Agent (
    AgentID INT PRIMARY KEY IDENTITY,
    AgentName NVARCHAR(50),
    Address NVARCHAR(100)
);

CREATE TABLE [Order] (
    OrderID INT PRIMARY KEY IDENTITY,
    OrderDate DATE,
    AgentID INT,
    FOREIGN KEY (AgentID) REFERENCES Agent(AgentID)
);

CREATE TABLE OrderDetail (
    ID INT PRIMARY KEY IDENTITY,
    OrderID INT,
    ItemID INT,
    Quantity INT,
    UnitAmount DECIMAL(10,2),
    FOREIGN KEY (OrderID) REFERENCES [Order](OrderID),
    FOREIGN KEY (ItemID) REFERENCES Item(ItemID)
);

INSERT INTO Users (UserName, email, password, lock) VALUES
('Nan', 'nan@ordermgmt.com', 'Nan111', 0),
('Chu', 'chu@ordermgmt.com', 'Chu123', 0),
('Mai', 'mai@ordermgmt.com', 'Mai111', 0),
('Zin', 'zin@ordermgmt.com', 'Zin123', 1),
('Tom', 'tom@ordermgmt.com', 'Tom111', 0),
('Lia', 'lia@ordermgmt.com', 'Lia123', 0),
('Ben', 'ben@ordermgmt.com', 'Ben111', 0),
('Hoa', 'hoa@ordermgmt.com', 'Hoa123', 0),
('Kim', 'kim@ordermgmt.com', 'Kim111', 0),
('Ray', 'ray@ordermgmt.com', 'Ray123', 0),
('Ann', 'ann@ordermgmt.com', 'Ann111', 0),
('Leo', 'leo@ordermgmt.com', 'Leo123', 0),
('Kai', 'kai@ordermgmt.com', 'Kai111', 0),
('Miu', 'miu@ordermgmt.com', 'Miu123', 1),
('Ken', 'ken@ordermgmt.com', 'Ken111', 1),
('Amy', 'amy@ordermgmt.com', 'Amy123', 0),
('Tim', 'tim@ordermgmt.com', 'Tim111', 0),
('Zoe', 'zoe@ordermgmt.com', 'Zoe123', 0),
('Sam', 'sam@ordermgmt.com', 'Sam111', 0),
('Lyn', 'lyn@ordermgmt.com', 'Lyn123', 0);

INSERT INTO Item (ItemName, Size) VALUES
('Laptop', '15-inch'),
('Smartphone', '6-inch'),
('Tablet', '10-inch'),
('Monitor', '24-inch'),
('Keyboard', 'Standard'),
('Mouse', 'Wireless'),
('Printer', 'Laser'),
('Scanner', 'A4'),
('Desk', 'Medium'),
('Chair', 'Ergonomic'),
('Headphones', 'Over-Ear'),
('Webcam', 'HD'),
('Speaker', 'Bluetooth'),
('Router', 'Dual-Band'),
('Hard Drive', '1TB'),
('SSD', '512GB'),
('USB Stick', '64GB'),
('Power Bank', '10,000mAh'),
('Projector', 'HD'),
('Microphone', 'Studio');

INSERT INTO Agent (AgentName, Address) VALUES
('John Doe', '123 Market St'),
('Jane Smith', '456 Trade Ave'),
('Michael Johnson', '789 Commerce Rd'),
('Emily Davis', '101 Supply Blvd'),
('Daniel Lee', '202 Vendor Ln'),
('Sarah Wilson', '303 Buyer Cir'),
('James Brown', '404 Deal Dr'),
('Olivia Clark', '505 Sales Pkwy'),
('David Lewis', '606 Broker Ave'),
('Sophia Walker', '707 Dispatch Rd'),
('Chris Hall', '808 Logistic Blvd'),
('Emma Allen', '909 Order St'),
('Robert Young', '1111 Fulfill Ln'),
('Mia King', '1212 Transport Way'),
('William Scott', '1313 Carrier Rd'),
('Isabella Green', '1414 Delivery Dr'),
('Andrew Adams', '1515 Exchange St'),
('Ava Baker', '1616 Purchase Pl'),
('Joseph Nelson', '1717 Tradepoint Dr'),
('Charlotte Carter', '1818 Supply Chain Ave');

INSERT INTO [Order] (OrderDate, AgentID) VALUES
('2025-04-01', 1),
('2025-04-02', 2),
('2025-04-03', 3),
('2025-04-04', 4),
('2025-04-05', 5),
('2025-04-06', 6),
('2025-04-07', 7),
('2025-04-08', 8),
('2025-04-09', 9),
('2025-04-10', 10),
('2025-04-11', 11),
('2025-04-12', 12),
('2025-04-13', 13),
('2025-04-14', 14),
('2025-04-15', 15),
('2025-04-16', 16),
('2025-04-17', 17),
('2025-04-18', 18),
('2025-04-19', 19),
('2025-04-20', 20);

INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount) VALUES
(1, 1, 2, 1000.00),
(2, 2, 3, 500.00),
(3, 3, 1, 750.00),
(4, 4, 4, 120.00),
(5, 5, 5, 45.00),
(6, 6, 2, 25.00),
(7, 7, 1, 200.00),
(8, 8, 3, 180.00),
(9, 9, 2, 300.00),
(10, 10, 2, 150.00),
(11, 11, 1, 90.00),
(12, 12, 2, 110.00),
(13, 13, 1, 250.00),
(14, 14, 3, 80.00),
(15, 15, 2, 95.00),
(16, 16, 4, 130.00),
(17, 17, 3, 60.00),
(18, 18, 2, 55.00),
(19, 19, 1, 400.00),
(20, 20, 2, 175.00);

select * from Users
select * from Item
select * from [Order]
select * from OrderDetail
select * from Agent


