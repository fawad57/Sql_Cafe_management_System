--Views

--1
create view check_details as
SELECT f.name AS item_name, c.name AS category_name, f.price, f.status
FROM food_items f
JOIN category c ON c.category_id = f.category_id;

--2
create view category_view as
select name from category;

--3
create view menu_view as
SELECT  m.menu_id, f.name AS item_name, c.name AS category_name, f.price, f.status
FROM menu m
JOIN food_items f on f.food_id=m.food_id
JOIN category c ON c.category_id = f.category_id;

--4
create view remove_item as
select f.name AS item_name, c.name AS category_name, f.price, f.status
from food_items f, category c
where c.category_id=f.category_id;

--5
create view Check_feedback as
SELECT f.name AS item_name, c.name AS category_name,COUNT(r.review_id) AS num_reviews,AVG(CAST(r.rating AS DECIMAL(10,2))) AS average_rating
FROM food_items f
 JOIN category c ON f.category_id = c.category_id
LEFT JOIN review r ON f.food_id = r.food_id
GROUP BY f.name, c.name;

-- Triggers

--1
CREATE TRIGGER CustomerInsertTrigger
ON Customers
AFTER INSERT
AS
BEGIN
    INSERT INTO CustomerLog (action, customer_id, F_Name, L_Name, Phone_no, Email, insert_date)
    SELECT 'Inserted', customer_id, F_Name, L_Name, Phone_no, Email, GETDATE()
    FROM inserted;
END;

--2
CREATE TRIGGER FoodItemInsertTrigger
ON food_items
AFTER INSERT
AS
BEGIN
    INSERT INTO FoodItemLog (action, food_id, category_id, name, price, status, change_date)
    SELECT 'Inserted', food_id, category_id, name, price, status, GETDATE()
    FROM inserted;
END;

--3
CREATE TRIGGER AddStaffMember
ON staff
AFTER INSERT
AS
BEGIN
    INSERT INTO StaffLog (staff_id, F_Name, L_Name, Phone_no, Email, roll_id, add_date)
    SELECT staff_id, F_Name, L_Name, Phone_no, Email, roll_id, GETDATE()
    FROM inserted;
END;

--4
CREATE TRIGGER PreventCartAddition
ON cart
Instead of INSERT
AS
BEGIN
    DECLARE @currentTime TIME;
    SET @currentTime = CONVERT(TIME, GETDATE());

    IF (@currentTime >= '00:00:00' AND @currentTime <= '08:00:00')
    BEGIN
        RAISERROR ('Items cannot be added to the cart between 12 AM and 8 AM.', 16, 1);
        ROLLBACK TRANSACTION;
    END
    ELSE
    BEGIN
        -- Insert the data into the table
        INSERT INTO cart (customer_id, delivery_id, total_bill, date)
        SELECT customer_id, delivery_id, total_bill, date
        FROM inserted;
    END
END;