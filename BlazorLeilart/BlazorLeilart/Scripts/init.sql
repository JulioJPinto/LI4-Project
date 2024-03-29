-- init.sql
USE master;
GO
-- Create the database
CREATE DATABASE [Leilart];
GO

USE [Leilart];

-- Create auction_type table
CREATE TABLE auction_type (
                              id INT IDENTITY(1, 1),
                              type VARCHAR(45) NOT NULL,
                              PRIMARY KEY(id),
                              UNIQUE(type)
);

-- Create variety table
CREATE TABLE variety (
                         id INT IDENTITY(1, 1),
                         name VARCHAR(100) NOT NULL,
                         PRIMARY KEY(id),
                         UNIQUE(name)
);

-- Create user table
CREATE TABLE [user] (
                        id INT IDENTITY(1, 1),
    email VARCHAR(200) NOT NULL,
    phone INT,
    password VARCHAR(128) NOT NULL,
    admin BIT NOT NULL,A
    PRIMARY KEY(id),
    UNIQUE(email)
    );

-- Create product table
CREATE TABLE product (
                         id INT IDENTITY(1, 1),
                         name VARCHAR(100) NOT NULL,
                         variety_id INT NOT NULL,
                         stock INT NOT NULL,
                         url VARCHAR(100) NOT NULL, 
                         PRIMARY KEY(id),
                         FOREIGN KEY(variety_id) REFERENCES variety(id),
                         UNIQUE(name)
);

-- Create auction table
CREATE TABLE auction (
                         id INT IDENTITY(1, 1),
                         auction_type_id INT NOT NULL,
                         product_id INT NOT NULL,
                         minimum_value INT,
                         initial_value INT,
                         increment INT,
                         start DATETIME NOT NULL,
                        [end] DATETIME NOT NULL,
                         current_bid INT,
                         status BIT NOT NULL,
                         PRIMARY KEY(id),
                         FOREIGN KEY(auction_type_id) REFERENCES auction_type(id),
                         FOREIGN KEY(product_id) REFERENCES product(id),
                         FOREIGN KEY(current_bid) REFERENCES bidding(id)
);

-- Create bidding table
CREATE TABLE bidding (
                         id INT IDENTITY(1, 1),
                         time DATETIME NOT NULL,
                         value INT NOT NULL,
                         auction_id INT NOT NULL,
                         user_id INT NOT NULL,
                         PRIMARY KEY(id),
                         FOREIGN KEY(auction_id) REFERENCES auction(id),
                         FOREIGN KEY(user_id) REFERENCES [user](id)
);
