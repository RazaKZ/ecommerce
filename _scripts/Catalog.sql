DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `Id` int NOT NULL,
  `Name` varchar(500) NOT NULL,
  `Price` decimal(18,2) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `department`;
CREATE TABLE `department` (
  `Id` int NOT NULL,
  `DepartmentName` varchar(300) DEFAULT NULL,
  `Description` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `brand`;
CREATE TABLE `brand` (
  `Id` int NOT NULL,
  `Name` varchar(300) NOT NULL,
  `Description` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
