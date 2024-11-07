/*1*/
select p.Name , p.Price
from dbo.Products as p
where p.Price>500;
/*2*/
select year(o.OrderDate) as Orderyear,
sum(o.TotalAmount * p.Price) as TotalAmount
from dbo.Orders as o
join Products as p on o.ProductId = p.Id
group by (year(o.OrderDate));
/*3*/
SELECT c.Name, SUM(p.Price * od.TotalAmount) AS TotalSales
FROM Orders od
JOIN Products p ON od.ProductID = p.Id
JOIN Categories c ON p.CategoryID = c.Id
GROUP BY c.Name;
/*4*/
select [Name] , [Price]
from Products
ORDER BY Price DESC;
/*5*/
SELECT C.Name , SUM( O.TotalAmount) AS OrderCount
FROM Customers C
JOIN Orders O ON O.CustomerId = C.Id
GROUP BY C.Name;
/*6*/
SELECT C.Name, AVG(P.Price) AS AveragePrice
FROM Categories C
JOIN PRODUCTS P ON P.CategoryId = C.Id
GROUP BY C.Name;
/*7*/
SELECT C.Name , P.Name
FROM Categories C
JOIN  PRODUCTS P ON C.Id = P.CategoryId
ORDER BY C.Name , P.Name;
/*8*/
SELECT C.Name AS Category , SUM(P.Price * O.TotalAmount) AS SalesIn2023
FROM Categories C 
JOIN Products P ON P.CategoryId = C.Id
JOIN Orders O ON O.ProductId = P.Id
WHERE YEAR(O.OrderDate) = 2023
GROUP BY C.Name;
/*9*/
SELECT MONTH(OrderDate) AS OrderMonth, COUNT(Orders.Id) AS OrderCount
FROM Orders
GROUP BY MONTH(OrderDate);
/*10*/
SELECT C.Name ,SUM(O.TotalAmount) AS TotalOrder,SUM(O.TotalAmount * P.Price) AS TotalPrice
FROM Customers C
JOIN Orders O ON O.CustomerId = C.Id
JOIN Products P ON P.Id = O.ProductId
GROUP BY C.Name;
/*11*/
SELECT C.Name , COUNT(O.Id) AS OrderCount
FROM Categories C
LEFT JOIN Products P ON P.CategoryId = C.Id
LEFT JOIN Orders O ON O.ProductId = P.Id
GROUP BY C.Name 
ORDER BY ORDERCOUNT DESC;
/*12*/
SELECT C.Name, COUNT(O.Id) AS OrderCount
FROM Customers C
JOIN Orders O ON O.CustomerId = C.Id
GROUP BY C.Name
ORDER BY OrderCount DESC;
/*13*/
SELECT YEAR(O.OrderDate) AS OrderYear , COUNT(O.Id) AS OrderCount
FROM Orders O
GROUP BY YEAR(O.OrderDate);
/*14*/
SELECT P.Name , COUNT(DISTINCT O.CustomerId) AS CustomerCount
FROM Products P
LEFT JOIN Orders O ON O.ProductId = P.Id
GROUP BY P.Name
ORDER BY CustomerCount DESC;