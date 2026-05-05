-- ============================================================
--  Dump propre de la base bd_gsb pour l'application GSB2
--  Schema aligne avec le code C# (DAO).
--  Cible : MySQL 8.0
-- ============================================================

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

-- ------------------------------------------------------------
-- Creation / selection de la base
-- ------------------------------------------------------------
CREATE DATABASE IF NOT EXISTS `bd_gsb`
  CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci;
USE `bd_gsb`;

-- ------------------------------------------------------------
-- Drop dans l'ordre inverse des FK
-- ------------------------------------------------------------
DROP TABLE IF EXISTS `liai_medicine_prescription`;
DROP TABLE IF EXISTS `prescription`;
DROP TABLE IF EXISTS `medicine`;
DROP TABLE IF EXISTS `patients`;
DROP TABLE IF EXISTS `users`;

-- ------------------------------------------------------------
-- Table users
-- ------------------------------------------------------------
CREATE TABLE `users` (
  `id_users`   INT          NOT NULL AUTO_INCREMENT,
  `firstname`  VARCHAR(100) NOT NULL,
  `name`       VARCHAR(100) DEFAULT NULL,
  `email`      VARCHAR(100) DEFAULT NULL,
  `password`   VARCHAR(255) DEFAULT NULL,
  `role`       TINYINT(1)   DEFAULT 0,
  PRIMARY KEY (`id_users`),
  UNIQUE KEY `uq_users_email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Mots de passe = SHA2('123', 256)
INSERT INTO `users` (`id_users`,`firstname`,`name`,`email`,`password`,`role`) VALUES
  (1,'Alice'  ,'Martin'  ,'alice.martin@example.com'  ,SHA2('123',256), 1),
  (2,'Bob'    ,'Durand'  ,'bob.durand@example.com'    ,SHA2('123',256), 1),
  (3,'Claire' ,'Lefevre' ,'claire.lefevre@example.fr' ,SHA2('123',256), 0),
  (4,'David'  ,'Bernard' ,'david.bernard@example.com' ,SHA2('123',256), 0),
  (5,'Emma'   ,'Petit'   ,'emma.petit@example.com'    ,SHA2('123',256), 1),
  (6,'Safwane','Bada'    ,'safwaneb96@gmail.com'      ,SHA2('123',256), 1);

-- ------------------------------------------------------------
-- Table patients (age en INT, le code lit GetInt32)
-- ------------------------------------------------------------
CREATE TABLE `patients` (
  `id_patients` INT          NOT NULL AUTO_INCREMENT,
  `id_users`    INT          DEFAULT NULL,
  `name`        VARCHAR(50)  DEFAULT NULL,
  `firstname`   VARCHAR(255) DEFAULT NULL,
  `age`         INT          DEFAULT NULL,
  `gender`      VARCHAR(1)   DEFAULT NULL,
  PRIMARY KEY (`id_patients`),
  KEY `fk_patients_users` (`id_users`),
  CONSTRAINT `fk_patients_users`
    FOREIGN KEY (`id_users`) REFERENCES `users` (`id_users`)
    ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `patients` (`id_patients`,`id_users`,`name`,`firstname`,`age`,`gender`) VALUES
  (1, 3, 'Lefevre', 'Claire', 29, 'F'),
  (2, 4, 'Bernard', 'David' , 45, 'H'),
  (3, 1, 'Almeida', 'Joao'  , 24, 'H');

-- ------------------------------------------------------------
-- Table medicine
-- ------------------------------------------------------------
CREATE TABLE `medicine` (
  `id_medicine` INT           NOT NULL AUTO_INCREMENT,
  `id_users`    INT           DEFAULT NULL,
  `dosage`      VARCHAR(50)   DEFAULT NULL,
  `names`       VARCHAR(50)   DEFAULT NULL,
  `description` VARCHAR(1000) DEFAULT NULL,
  `molecule`    VARCHAR(50)   DEFAULT NULL,
  PRIMARY KEY (`id_medicine`),
  KEY `fk_medicine_users` (`id_users`),
  CONSTRAINT `fk_medicine_users`
    FOREIGN KEY (`id_users`) REFERENCES `users` (`id_users`)
    ON DELETE SET NULL ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `medicine` (`id_medicine`,`id_users`,`dosage`,`names`,`description`,`molecule`) VALUES
  (1, 1, '500 mg', 'Paracetamol' , 'Antidouleur et antipyretique'      , 'Paracetamolum'),
  (2, 1, '20 mg' , 'Doliprane'   , 'Soulage la fievre et la douleur'   , 'Paracetamolum'),
  (3, 2, '10 mg' , 'Ibuprofen'   , 'Anti-inflammatoire non steroidien' , 'Ibuprofenum'),
  (4, 5, '50 mg' , 'Amoxicilline', 'Antibiotique a large spectre'      , 'Amoxicillin'),
  (5, 1, '5 mg'  , 'Xanax'       , 'Anxiolytique (benzodiazepine)'     , 'Alprazolam');

-- ------------------------------------------------------------
-- Table prescription
-- ------------------------------------------------------------
CREATE TABLE `prescription` (
  `id_prescription` INT      NOT NULL AUTO_INCREMENT,
  `id_users`        INT      DEFAULT NULL,
  `id_patients`     INT      DEFAULT NULL,
  `validity`        DATETIME DEFAULT NULL,
  PRIMARY KEY (`id_prescription`),
  KEY `fk_prescription_users` (`id_users`),
  KEY `fk_prescription_patients` (`id_patients`),
  CONSTRAINT `fk_prescription_users`
    FOREIGN KEY (`id_users`) REFERENCES `users` (`id_users`)
    ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `fk_prescription_patients`
    FOREIGN KEY (`id_patients`) REFERENCES `patients` (`id_patients`)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `prescription` (`id_prescription`,`id_users`,`id_patients`,`validity`) VALUES
  (1, 1, 1, '2025-12-31 00:00:00'),
  (2, 2, 2, '2025-11-30 00:00:00'),
  (3, 2, 2, '2026-01-15 00:00:00'),
  (4, 1, 3, '2025-12-05 00:00:00');

-- ------------------------------------------------------------
-- Table d'association liai_medicine_prescription
-- (nom de colonne corrige : id_prescription, plus de typo)
-- ------------------------------------------------------------
CREATE TABLE `liai_medicine_prescription` (
  `id_prescription` INT NOT NULL,
  `id_medicine`     INT NOT NULL,
  `quantity`        INT DEFAULT NULL,
  PRIMARY KEY (`id_prescription`, `id_medicine`),
  KEY `fk_liai_medicine` (`id_medicine`),
  CONSTRAINT `fk_liai_prescription`
    FOREIGN KEY (`id_prescription`) REFERENCES `prescription` (`id_prescription`)
    ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_liai_medicine`
    FOREIGN KEY (`id_medicine`) REFERENCES `medicine` (`id_medicine`)
    ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

INSERT INTO `liai_medicine_prescription` (`id_prescription`,`id_medicine`,`quantity`) VALUES
  (1, 1, 5),
  (1, 2, 178),
  (2, 3, 44),
  (3, 5, 26),
  (4, 1, 3),
  (4, 2, 1);

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
