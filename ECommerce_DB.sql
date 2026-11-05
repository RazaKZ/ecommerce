-- ==============================================================
-- ECommerce Database Script for MySQL Workbench
-- Project: QST.ECommerce (.NET 9 Web API + EF Core Pomelo MySQL)
-- ==============================================================

-- 1. Database Creation
CREATE DATABASE IF NOT EXISTS `ECommerce`
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

USE `ECommerce`;

-- Disable foreign key checks during setup
SET FOREIGN_KEY_CHECKS = 0;

-- ==============================================================
-- 2. Drop existing tables if re-running
-- ==============================================================
DROP TABLE IF EXISTS `Products`;
DROP TABLE IF EXISTS `Categories`;
DROP TABLE IF EXISTS `Department`;
DROP TABLE IF EXISTS `Brand`;

-- ==============================================================
-- 3. Table: Department
-- Mapped from QST.ECommerce.Domain.Catalogue.Department
-- Config: DepartmentConfig.cs
-- ==============================================================
CREATE TABLE `Department` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `DepartmentName` VARCHAR(200) NOT NULL,
    `Description` TEXT NULL,
    `IsActive` TINYINT(1) NOT NULL DEFAULT 1,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ==============================================================
-- 4. Table: Brand
-- Mapped from QST.ECommerce.Domain.Catalogue.Brand
-- Config: BrandConfig.cs
-- ==============================================================
CREATE TABLE `Brand` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `Name` VARCHAR(300) NOT NULL,
    `Description` VARCHAR(1000) NULL,
    `IsActive` TINYINT(1) NOT NULL DEFAULT 1,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ==============================================================
-- 5. Table: Categories
-- Mapped from QST.ECommerce.Domain.Catalogue.Category
-- Config: CateogryConfig.cs
-- ==============================================================
CREATE TABLE `Categories` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `DepartmentId` INT NOT NULL,
    `Name` VARCHAR(200) NOT NULL,
    `Description` VARCHAR(1000) NULL,
    `IsActive` TINYINT(1) NOT NULL DEFAULT 1,
    PRIMARY KEY (`Id`),
    KEY `IX_Categories_DepartmentId` (`DepartmentId`),
    CONSTRAINT `FK_Categories_Department_DepartmentId` 
        FOREIGN KEY (`DepartmentId`) REFERENCES `Department` (`Id`) 
        ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ==============================================================
-- 6. Table: Products
-- Mapped from QST.ECommerce.Domain.Catalogue.Product
-- Config: ProductConfig.cs
-- ==============================================================
CREATE TABLE `Products` (
    `Id` INT NOT NULL AUTO_INCREMENT,
    `Name` VARCHAR(300) NOT NULL,
    `Price` DECIMAL(18, 2) NOT NULL DEFAULT 0.00,
    PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- Re-enable foreign key checks
SET FOREIGN_KEY_CHECKS = 1;

-- ==============================================================
-- 7. Sample / Seed Data (Testing ke liye initial data)
-- ==============================================================

-- Sample Departments
INSERT INTO `Department` (`Id`, `DepartmentName`, `Description`, `IsActive`) VALUES
(1, 'Electronics', 'Electronic Devices and Gadgets', 1),
(2, 'Computers', 'Computers, Laptops & Accessories', 1),
(3, 'Smart Home', 'Smart Home Appliances & Automation', 1);

-- Sample Brands
INSERT INTO `Brand` (`Id`, `Name`, `Description`, `IsActive`) VALUES
(1, 'Apple', 'Smartphones, Tablets and Laptops', 1),
(2, 'Samsung', 'Consumer electronics & tech', 1),
(3, 'Dell', 'Laptops and Computer Peripherals', 1);

-- Sample Categories
INSERT INTO `Categories` (`Id`, `DepartmentId`, `Name`, `Description`, `IsActive`) VALUES
(1, 1, 'Accessories & Supplies', 'Electronic accessories and chargers', 1),
(2, 1, 'Camera & Photo', 'Digital cameras and lenses', 1),
(3, 2, 'Laptops & Computers', 'High performance computing laptops', 1),
(4, 2, 'Computer Accessories', 'Keyboards, Mouse and Monitors', 1);

-- Sample Products
INSERT INTO `Products` (`Id`, `Name`, `Price`) VALUES
(1, 'Laptop', 30000.00),
(2, 'Mobile', 13000.00),
(3, 'Perfume', 400.00);

-- Verify queries
SELECT * FROM `Department`;
SELECT * FROM `Brand`;
SELECT * FROM `Categories`;
SELECT * FROM `Products`;

