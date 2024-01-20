create table auction_type (
    id INT IDENTITY(1, 1),
    type VARCHAR(45) NOT NULL,
    PRIMARY KEY(id),
    UNIQUE(type)
);

create table variety (
    id INT IDENTITY(1, 1),
    name VARCHAR(100) NOT NULL,
    PRIMARY KEY(id),
    UNIQUE(name)
);

create table [user] (
    id INT IDENTITY(1, 1),
    email VARCHAR(200) NOT NULL,
    phone INT,
    password VARCHAR(128) NOT NULL,
    admin BINARY NOT NULL,
    PRIMARY KEY(id),
    UNIQUE(email)
);

create table product (
    id INT IDENTITY(1, 1),
    name VARCHAR(100) NOT NULL,
    variety_id INT NOT NULL,
    stock INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(variety_id) REFERENCES variety(id),
    UNIQUE(name)
);

create table auction (
    id INT IDENTITY(1, 1),
    auction_type_id INT NOT NULL,
    product_id INT NOT NULL,
    minimum_value INT,
    initial_value INT,
    increment INT,
    start DATETIME NOT NULL,
    [end] DATETIME NOT NULL,
    current_bid INT,
    status BINARY NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(auction_type_id) REFERENCES auction_type(id),
    FOREIGN KEY(product_id) REFERENCES product(id),
);

create table bidding (
    id INT IDENTITY(1, 1),
    time DATETIME NOT NULL,
    value INT NOT NULL,
    auction_id INT NOT NULL,
    user_id INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(auction_id) REFERENCES auction(id),
    FOREIGN KEY(user_id) REFERENCES [user](id)
);
