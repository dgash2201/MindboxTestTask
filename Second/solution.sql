USE TestDB;

CREATE TABLE Products (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
)

CREATE TABLE Category (
  id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
)

CREATE TABLE Products_Category (
  product_id INT NOT NULL,
  category_id INT NOT NULL,
  PRIMARY KEY (product_id, category_id),
  FOREIGN KEY (product_id)
    REFERENCES Products (id) ON DELETE CASCADE,
  FOREIGN KEY (category_id)
    REFERENCES Category (id) ON DELETE CASCADE
)

INSERT INTO Products values ('Лыжи'), ('Ноутбук'), ('Шоколад'), ('Велосипед'), ('Наушники');
INSERT INTO Category values ('Техника'), ('Продукты'), ('Спорттовары');
INSERT INTO Products_Category values (1, 3), (2, 1), (3, 2), (4, 3), (5, 1);

SELECT P.name as product,
       C.name as category 
FROM Products P LEFT JOIN Products_Category PC on P.id = PC.product_id 
LEFT JOIN Category C on C.id = PC.category_id