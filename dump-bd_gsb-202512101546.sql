-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: bd_gsb
-- ------------------------------------------------------
-- Server version	8.0.41

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `liai_medicine_prescription`
--

DROP TABLE IF EXISTS `liai_medicine_prescription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `liai_medicine_prescription` (
  `id_prescrition` int DEFAULT NULL,
  `id_medicine` int DEFAULT NULL,
  `quantity` int DEFAULT NULL,
  KEY `id_prescrition` (`id_prescrition`),
  KEY `id_medicine` (`id_medicine`),
  CONSTRAINT `liai_medicine_prescription_ibfk_1` FOREIGN KEY (`id_prescrition`) REFERENCES `prescription` (`id_prescription`),
  CONSTRAINT `liai_medicine_prescription_ibfk_2` FOREIGN KEY (`id_medicine`) REFERENCES `medicine` (`id_medicine`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `liai_medicine_prescription`
--

LOCK TABLES `liai_medicine_prescription` WRITE;
/*!40000 ALTER TABLE `liai_medicine_prescription` DISABLE KEYS */;
INSERT INTO `liai_medicine_prescription` VALUES (1,1,5),(1,2,178),(2,3,44),(3,5,26),(5,2,1),(5,1,3);
/*!40000 ALTER TABLE `liai_medicine_prescription` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicine`
--

DROP TABLE IF EXISTS `medicine`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medicine` (
  `id_medicine` int NOT NULL AUTO_INCREMENT,
  `id_users` int DEFAULT NULL,
  `dosage` varchar(50) DEFAULT NULL,
  `names` varchar(50) DEFAULT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `molecule` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_medicine`),
  KEY `id_users` (`id_users`),
  CONSTRAINT `medicine_ibfk_1` FOREIGN KEY (`id_users`) REFERENCES `users` (`id_users`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicine`
--

LOCK TABLES `medicine` WRITE;
/*!40000 ALTER TABLE `medicine` DISABLE KEYS */;
INSERT INTO `medicine` VALUES (1,1,'500 mg','Paracetamol','Antidouleur et antipyrétique','Paracetamolum'),(2,1,'20 mg','Doliprane','Soulage la fièvre et la douleur','Paracetamolum'),(3,2,'10 mg','Ibuprofen','Anti-inflammatoire non stéroïdien','Ibuprofenum'),(4,5,'50 mg','Amoxicilline','Antibiotique à large spectre','Amoxicillin'),(5,1,'5 mg','Xanax','Anxiolytique (benzodiazépine)','Alprazolam');
/*!40000 ALTER TABLE `medicine` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `patients`
--

DROP TABLE IF EXISTS `patients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `patients` (
  `id_patients` int NOT NULL AUTO_INCREMENT,
  `id_users` int DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `age` varchar(50) DEFAULT NULL,
  `firstname` varchar(255) DEFAULT NULL,
  `gender` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`id_patients`),
  KEY `id_users` (`id_users`),
  CONSTRAINT `patients_ibfk_1` FOREIGN KEY (`id_users`) REFERENCES `users` (`id_users`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `patients`
--

LOCK TABLES `patients` WRITE;
/*!40000 ALTER TABLE `patients` DISABLE KEYS */;
INSERT INTO `patients` VALUES (1,3,'Lefevre','29','Claire','F'),(2,4,'Bernard','45','David','H'),(3,1,'Almeida','24','Joao','H');
/*!40000 ALTER TABLE `patients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prescription`
--

DROP TABLE IF EXISTS `prescription`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prescription` (
  `id_prescription` int NOT NULL AUTO_INCREMENT,
  `id_patients` int DEFAULT NULL,
  `id_users` int DEFAULT NULL,
  `quantity` varchar(50) DEFAULT NULL,
  `validity` datetime DEFAULT NULL,
  PRIMARY KEY (`id_prescription`),
  KEY `id_patients` (`id_patients`),
  KEY `id_users` (`id_users`),
  CONSTRAINT `prescription_ibfk_1` FOREIGN KEY (`id_patients`) REFERENCES `patients` (`id_patients`),
  CONSTRAINT `prescription_ibfk_2` FOREIGN KEY (`id_users`) REFERENCES `users` (`id_users`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prescription`
--

LOCK TABLES `prescription` WRITE;
/*!40000 ALTER TABLE `prescription` DISABLE KEYS */;
INSERT INTO `prescription` VALUES (1,1,1,'2 boîtes','2025-12-31 00:00:00'),(2,2,2,'1 boîte','2025-11-30 00:00:00'),(3,2,2,'3 boîtes','2026-01-15 00:00:00'),(5,3,1,NULL,'2025-12-05 00:00:00');
/*!40000 ALTER TABLE `prescription` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_users` int NOT NULL AUTO_INCREMENT,
  `firstname` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `role` bit(1) DEFAULT NULL,
  PRIMARY KEY (`id_users`),
  UNIQUE KEY `firstname` (`firstname`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Alice','Martin','alice.martin@example.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',_binary ''),(2,'Bob','Durand','bob.durand@example.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',_binary ''),(3,'Claire','Lefevre','claire.lefevre@example.fr','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',_binary '\0'),(4,'David','Bernard','david.bernard@example.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',_binary '\0'),(5,'Emma','Petit','emma.petit@example.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',_binary ''),(6,'Safwane','Bada','safwaneb96@gmail.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',_binary '\0'),(9,'yam','Yam','yam@yam.com','a665a45920422f9d417e4867efdc4fb8a04a1f3fff1fa07e998e86f7f7a27ae3',_binary '\0');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'bd_gsb'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-12-10 15:46:30
