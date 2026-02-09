CREATE DATABASE payroll_service;
GO

USE payroll_service;
GO

CREATE TABLE employee_payroll
(
    employee_id INT IDENTITY(1,1) PRIMARY KEY,
    employee_name VARCHAR(100) NOT NULL,
    phone_number VARCHAR(15),
    address VARCHAR(255),
    department VARCHAR(100),
    basic_pay DECIMAL(18,2),
    start_date DATE
);

CREATE TABLE payroll_details
(
    payroll_id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT NOT NULL,
    basic_pay DECIMAL(18,2),
    deductions DECIMAL(18,2),
    taxable_pay DECIMAL(18,2),
    income_tax DECIMAL(18,2),
    net_pay DECIMAL(18,2),
    FOREIGN KEY (employee_id) REFERENCES employee_payroll(employee_id)
);
