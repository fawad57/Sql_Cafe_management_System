-- Adding categories
INSERT INTO category (name)
VALUES 
    ('Appetizers'),
    ('Main Course'),
    ('Desserts'),
    ('Beverages'),
    ('Salads');

-- Adding food items
-- Appetizers
INSERT INTO food_items (category_id, name, price, status)
VALUES 
    (1, 'Spring Rolls', 6, 'Available'),
    (1, 'Chicken Wings', 8, 'Available'),
    (1, 'Mozzarella Sticks', 7, 'Available');

-- Main Course
INSERT INTO food_items (category_id, name, price, status)
VALUES 
    (2, 'Grilled Chicken', 15, 'Available'),
    (2, 'Spaghetti Carbonara', 12, 'Available'),
    (2, 'Beef Burger', 10, 'Available');

-- Desserts
INSERT INTO food_items (category_id, name, price, status)
VALUES 
    (3, 'Chocolate Cake', 8, 'Available'),
    (3, 'Cheesecake', 7, 'Available'),
    (3, 'Ice Cream Sundae', 6, 'Available');

-- Beverages
INSERT INTO food_items (category_id, name, price, status)
VALUES 
    (4, 'Coca-Cola', 2, 'Available'),
    (4, 'Fresh Orange Juice', 4, 'Available'),
    (4, 'Iced Tea', 3, 'Available');

-- Salads
INSERT INTO food_items (category_id, name, price, status)
VALUES 
    (5, 'Caesar Salad', 9, 'Available'),
    (5, 'Greek Salad', 8, 'Available'),
    (5, 'Caprese Salad', 7, 'Available');


-- Customers
INSERT INTO Customers (F_Name, L_Name, Phone_no, Email, Loyality_Points)
VALUES
    ('Areeba', 'Nisar', '123-456-7890', 'areeba.nisar@gmail.com', 100),
    ('Alice', 'Smith', '987-654-3210', 'alice.smith@gmail.com', 50),
    ('Michael', 'Johnson', '555-555-5555', 'michael.j@gmail.com', 75),
    ('Emily', 'Brown', '111-222-3333', 'emily.brown@gmail.com', 120),
    ('David', 'Lee', '444-444-4444', 'david.lee@gmail.com', 90);

-- Shipper
INSERT INTO Shipper (F_Name, L_Name, Phone_no, Email)
VALUES
    ('James', 'Johnson', '999-999-9999', 'james.j@gmail.com'),
    ('Emma', 'Davis', '888-888-8888', 'emma.d@gmail.com'),
    ('Olivia', 'Wilson', '777-777-7777', 'olivia.w@gmail.com'),
    ('Daniel', 'Martinez', '666-666-6666', 'daniel.m@gmail.com'),
    ('Sophia', 'Taylor', '333-333-3333', 'sophia.t@gmail.com');

-- Staff_Roll
INSERT INTO Staff_Roll (Name)
VALUES
    ('Chef'),
    ('Waiter'),
    ('Manager'),
    ('Bartender'),
    ('Cleaner');

-- Staff
INSERT INTO Staff (F_Name, L_Name, Phone_no, Email, roll_id)
VALUES
    ('Robert', 'Anderson', '222-222-2222', 'robert.a@gmail.com', 1),
    ('Jennifer', 'Brown', '333-333-3333', 'jennifer.b@gmail.com', 2),
    ('William', 'Miller', '444-444-4444', 'william.m@gmail.com', 3),
    ('Emma', 'Garcia', '555-555-5555', 'emma.g@gmail.com', 4),
    ('Ethan', 'Moore', '666-666-6666', 'ethan.m@gmail.com', 5);

-- Tables
INSERT INTO Tables (No_of_Chairs)
VALUES
    (4),
    (6),
    (2),
    (8),
    (10);

-- Table_Booking
INSERT INTO Table_Booking (table_id, customer_id, Time_t, date)
VALUES
    (1, 1001, '18:00:00', '2024-04-29'),
    (2, 1002, '19:00:00', '2024-04-28'),
    (3, 1003, '20:00:00', '2024-04-27'),
    (4, 1004, '21:00:00', '2024-04-26'),
    (5, 1005, '22:00:00', '2024-04-25');

-- Review
INSERT INTO Review (food_id, customer_id, rating, review_date)
VALUES
    (1, 1001, '5', '2024-04-29'),
    (2, 1002, '4', '2024-04-28'),
    (3, 1003, '3', '2024-04-27'),
    (4, 1004, '4', '2024-04-26'),
    (5, 1005, '5', '2024-04-25');

-- Promotions
INSERT INTO Promotions (name, description, start_date, end_date, discount_type, discount_value)
VALUES
    ('Weekend Special', 'Get 20% off on all orders over $50', '2024-04-27', '2024-04-30', 'Percentage', '20'),
    ('Happy Hour', '50% off on selected drinks from 5 PM to 7 PM', '2024-04-28', '2024-04-28', 'Percentage', '50'),
    ('Lunch Deal', 'Special lunch menu for $10 from 12 PM to 3 PM', '2024-04-29', '2024-04-29', 'Fixed Amount', '10'),
    ('Birthday Bash', 'Celebrate your birthday with us and get a free dessert!', '2024-04-30', '2024-04-30', 'Free Item', 'Dessert'),
    ('Family Feast', 'Family combo meal for 4 at $40', '2024-05-01', '2024-05-01', 'Fixed Amount', '40');

-- Food_Promotions
INSERT INTO Food_Promotions (promotion_id, food_id)
VALUES
    (1, 1),
    (2, 10),
    (3, 15),
    (4, 7),
    (5, 6);

-- Menu
INSERT INTO Menu (food_id, details)
VALUES
    (1, 'Delicious spring rolls served with sweet chili sauce'),
    (2, 'Spicy chicken wings served with ranch dressing'),
    (3, 'Golden and crispy mozzarella sticks served with marinara sauce'),
    (4, 'Tender grilled chicken breast served with mashed potatoes and vegetables'),
    (5, 'Classic spaghetti carbonara with bacon and Parmesan cheese'),
    (6, 'Juicy beef burger with fries and coleslaw'),
    (7, 'Decadent chocolate cake with vanilla ice cream'),
    (8, 'Creamy cheesecake with raspberry coulis'),
    (9, 'Refreshing ice cream sundae with assorted toppings'),
    (10, 'Refreshing Coca-Cola served chilled'),
    (11, 'Freshly squeezed orange juice'),
    (12, 'Iced tea with lemon slices'),
    (13, 'Classic Caesar salad with homemade dressing'),
    (14, 'Fresh Greek salad with feta cheese and olives'),
    (15, 'Caprese salad with ripe tomatoes, mozzarella, and basil');

-- Order_Details
INSERT INTO Order_Details (food_id, price, quantity)
VALUES
    (1, 6, 2),
    (2, 8, 1),
    (3, 7, 3),
    (4, 15, 1),
    (5, 12, 2);

-- Order_Food
INSERT INTO Order_Food (order_id, staff_id, customer_id, table_id, order_date, total_bill)
VALUES
    (1, 101, 1001, 1, '2024-04-29', 25.50),
    (2, 102, 1002, 2, '2024-04-28', 24.00),
    (3, 103, 1003, 3, '2024-04-27', 30.00),
    (4, 104, 1004, 4, '2024-04-26', 40.00),
    (5, 105, 1005, 5, '2024-04-25', 42.00);



-- Cart
INSERT INTO Cart (customer_id, total_bill, date)
VALUES
    (1001, 30, '2024-04-29'),
    (1002, 25, '2024-04-28'),
    (1003, 40, '2024-04-27'),
    (1004, 35, '2024-04-26'),
    (1005, 50, '2024-04-25');

	select * from cart
-- Cart_Item
INSERT INTO Cart_Item (cart_id, food_id, quantity)
VALUES
    (2, 1, 2),
    (2, 10, 3),
    (3, 15, 1),
    (4, 7, 2),
    (5, 6, 1);

-- Admin
INSERT INTO Admin (F_Name, L_Name, Phone_no, Email)
VALUES
    ('Fawad', 'Humayun', '999-999-9999', 'fawad.humayun@gmail.com');

-- Manage_Food
INSERT INTO Manage_Food (manager_id, food_id)
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (1, 5);

-- Manage_Category
INSERT INTO Manage_Category (manager_id, category_id)
VALUES
    (1, 1),
    (1, 2),
    (1, 3),
    (1, 4),
    (1, 5);

-- Manage_Staff
INSERT INTO Manage_Staff (manager_id, staff_id)
VALUES
    (1, 101),
    (1, 102),
    (1, 103),
    (1, 104),
    (1, 105);


