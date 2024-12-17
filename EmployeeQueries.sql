-- Create Employee table

CREATE TABLE Employee(
	EmployeeID int IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Title NVARCHAR(50) NULL,
	City NVARCHAR(50) NULL,
);


-- Insert Employees into Employee table
INSERT INTO Employee VALUES('Sruthi', 'kamisetti', 'Software Developer', 'Waterloo'),
('John', 'Smith', 'Senior Software Developer', 'Toronto'),
('Sai', 'Kumar', 'Lead Developer', 'London'),
('John', 'Sam', 'Senior Architect', 'Waterloo'),
('Rick', 'Tom', 'Lead Architect', 'Toronto');

SELECT * FROM Employee;