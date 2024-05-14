create table Customers(
customer_id int identity(1001,1) primary key,
F_Name VARCHAR(255),
L_Name VARCHAR(255),
Phone_no varchar(255),
Email varchar(255),
Loyality_Points float);

create table Shipper(
shipper_id int identity(2001,1) primary key,
F_Name VARCHAR(255),
L_Name VARCHAR(255),
Phone_no varchar(255),
Email varchar(255));

create table Staff_Roll(
Roll_id int identity(1,1) primary key,
Name varchar(255));

create table staff(
staff_id int identity(101,1) primary key,
F_Name VARCHAR(255),
L_Name VARCHAR(255),
Phone_no varchar(255),
Email varchar(255),
roll_id int,

foreign key (roll_id) references staff_roll(Roll_id)
on delete cascade	on update cascade
);

create table Cash_Payment(
payment_id int identity(1,1) primary key,
amount varchar(255),
date DATE,
time TIMESTAMP,
customer_id int,
foreign key (customer_id)  references customers(customer_id)
on delete cascade	on update cascade
);

create table online_payment(
payment_id int identity(1,1) primary key,
amount varchar(255),
date DATE,
time TIMESTAMP,
customer_id int,
pay_method varchar(255),
status varchar(10),
foreign key (customer_id)  references customers(customer_id)
on delete cascade	on update cascade
);

 select * from food_items

create table card_payment(
payment_id int identity(1,1) primary key,
amount varchar(255),
date DATE,
time TIMESTAMP,
customer_id int,
card_no varchar(255),
card_type varchar(255),
expiry_date DATE,
foreign key (customer_id)  references customers(customer_id)
on delete cascade	on update cascade
);

create table tables(
table_id int identity(1,1)primary key,
No_of_Chairs int
);

create table table_booking(
booking_id int identity(1,1)primary key,
table_id int,
customer_id int,
Time_t TIME,
date DATE,

foreign key (table_id)  references tables (table_id)
on delete cascade	on update cascade,
foreign key (customer_id)  references customers (customer_id)
on delete cascade	on update cascade
);

create table category(
category_id int identity (1,1) primary key,
name varchar(255)
);

create table food_items(
food_id int identity (1,1) primary key,
category_id int ,
name varchar(255),
price int,
status varchar(255),
foreign key (category_id)  references category (category_id)
on delete cascade	on update cascade,
);

create table review(
review_id int identity(1,1),
food_id int,
customer_id int,
rating varchar(255),
review_date DATE,

FOREIGN KEY (food_id) REFERENCES food_items(food_id)
on delete cascade	on update cascade,
foreign key (customer_id)  references customers (customer_id)
on delete cascade	on update cascade
);

create table promotions(
promotion_id int identity(1,1)primary key,
name varchar(255),
description varchar(255),
start_date DATE,
end_date  DATE,
discount_type varchar(255),
discount_value varchar(255)
);

create table food_promotions(
food_promotion_id int identity(178,1)primary key,
promotion_id int,
food_id int,
foreign key (food_id) references food_items(food_id)
on delete cascade	on update cascade,
foreign key (promotion_id) references promotions(promotion_id)
on delete cascade	on update cascade
);

create table menu(
menu_id int identity(1,1)primary key,
food_id int,
details varchar(255),
foreign key (food_id) references food_items(food_id)
on delete cascade	on update cascade
);

create table order_details(
order_id int identity(1,1)primary key,
food_id int,
price int,
quantity int,
foreign key (food_id) references food_items(food_id)
on delete cascade	on update cascade
);

create table Order_Food(
order_no int identity(1,1)primary key,
order_id int,
staff_id int,
customer_id int,
table_id int,
order_date DATE,
total_bill float,

foreign key (order_id) references order_details(order_id)
on delete cascade	on update cascade,
foreign key (staff_id) references staff(staff_id)
on delete cascade	on update cascade,
foreign key (customer_id) references customers(customer_id)
on delete cascade	on update cascade,
foreign key (table_id) references tables(table_id)
on delete cascade	on update cascade);

create table delivery(
delivery_id int identity(1,1)primary key,
cart_id int,
shipper_id int,
date Date,
foreign key (shipper_id) references shipper(shipper_id)
on delete cascade	on update cascade);

create table cart(
cart_id int identity(1,1)primary key,
customer_id int,
delivery_id int,
total_bill int,
date DATE,
foreign key (customer_id) references customers(customer_id)
on delete cascade	on update cascade,
FOREIGN KEY (delivery_id)REFERENCES delivery(delivery_id)
on delete cascade	on update cascade
);

alter table delivery
ADD CONSTRAINT f2 FOREIGN KEY (cart_id) REFERENCES cart(cart_id)
 

create table cart_item(
cart_item_id int identity(009,1)primary key,
cart_id int,
food_id int,
quantity int,

foreign key (cart_id) references cart(cart_id)
on delete cascade	on update cascade,

foreign key (food_id) references food_items(food_id)
on delete cascade	on update cascade,
);

create table Admin(
admin_id int identity(1,1) primary key,
F_Name VARCHAR(255),
L_Name VARCHAR(255),
Phone_no varchar(255),
Email varchar(255));

create table manage_food(
manager_id int,
food_id int,
primary key(manager_id,food_id),

foreign key (manager_id) references Admin(admin_id)
on delete cascade	on update cascade,
foreign key (food_id) references food_items(food_id)
on delete cascade	on update cascade,
);

create table manage_category(
manager_id int,
category_id int,
primary key(manager_id,category_id),

foreign key (manager_id) references Admin(admin_id)
on delete cascade	on update cascade,
foreign key (category_id) references category(category_id)
on delete cascade	on update cascade
);

create table manage_staff(
manager_id int,
staff_id int,
primary key(manager_id,staff_id),

foreign key (manager_id) references Admin(admin_id)
on delete cascade	on update cascade,
foreign key (staff_id) references staff(staff_id)
on delete cascade	on update cascade
);

CREATE TABLE StaffLog (
    log_id INT IDENTITY(1,1) PRIMARY KEY,
    staff_id INT,
    F_Name VARCHAR(255),
    L_Name VARCHAR(255),
    Phone_no VARCHAR(255),
    Email VARCHAR(255),
    roll_id INT,
    add_date DATETIME
);

CREATE TABLE FoodItemLog (
    log_id INT IDENTITY(1,1) PRIMARY KEY,
    action VARCHAR(50),
    food_id INT,
    category_id INT,
    name VARCHAR(255),
    price INT,
    status VARCHAR(255),
    change_date DATETIME
);

CREATE TABLE CustomerLog (
    log_id INT IDENTITY(1,1) PRIMARY KEY,
    action VARCHAR(50),
    customer_id INT,
    F_Name VARCHAR(255),
    L_Name VARCHAR(255),
    Phone_no VARCHAR(255),
    Email VARCHAR(255),
    insert_date DATETIME
);



