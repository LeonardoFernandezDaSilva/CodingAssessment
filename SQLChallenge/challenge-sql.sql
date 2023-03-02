SELECT c.FirstName||' '||c.LastName as "Full name", c.Age, o.OrderId, o.DateCreated, o.MethodofPurchase as "Purchase Method", od.ProductNumber, od.ProductOrigin 
FROM Customer c
LEFT JOIN Orders o ON c.PersonID = o.PersonID 
LEFT JOIN OrderDetails od ON od.OrderID = o.OrderID 
WHERE od.ProductID = 1112222333