-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: rostelecom4
-- ------------------------------------------------------
-- Server version	8.0.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `arhivse`
--

DROP TABLE IF EXISTS `arhivse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `arhivse` (
  `id_arhivSE` int NOT NULL AUTO_INCREMENT,
  `id_specact` int NOT NULL,
  `id_skladequip` int NOT NULL,
  `serialscore` varchar(45) NOT NULL,
  `dateSpis` date NOT NULL,
  PRIMARY KEY (`id_arhivSE`),
  KEY `ases_idx` (`id_skladequip`),
  KEY `asetsa_idx` (`id_specact`),
  CONSTRAINT `ases` FOREIGN KEY (`id_skladequip`) REFERENCES `t_sklad` (`id_skladequip`),
  CONSTRAINT `asetsa` FOREIGN KEY (`id_specact`) REFERENCES `t_specact` (`id_specact`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `arhivse`
--

LOCK TABLES `arhivse` WRITE;
/*!40000 ALTER TABLE `arhivse` DISABLE KEYS */;
/*!40000 ALTER TABLE `arhivse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `authorization`
--

DROP TABLE IF EXISTS `authorization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authorization` (
  `id_sotryd` int NOT NULL AUTO_INCREMENT,
  `fiosotryd` varchar(45) DEFAULT NULL,
  `key_doljnost` int DEFAULT NULL,
  `id_ylitca` int DEFAULT NULL,
  `adres` varchar(45) DEFAULT NULL,
  `telephone` varchar(15) DEFAULT NULL,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_sotryd`),
  KEY `tsd_idx` (`key_doljnost`),
  KEY `das_idx` (`id_ylitca`),
  CONSTRAINT `das` FOREIGN KEY (`id_ylitca`) REFERENCES `s_street` (`id_ylitca`),
  CONSTRAINT `tsd` FOREIGN KEY (`key_doljnost`) REFERENCES `s_doljnost` (`key_doljnost`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authorization`
--

LOCK TABLES `authorization` WRITE;
/*!40000 ALTER TABLE `authorization` DISABLE KEYS */;
INSERT INTO `authorization` VALUES (1,'admin',3,NULL,'admin','admin','admin','admin'),(2,'Васильев Данил Юрьевич',2,2,'44 кв 21','(321) 903-8172','user','user'),(3,'Сергей Петрович',1,4,'312 кв 43','(545) 390-8676',NULL,NULL);
/*!40000 ALTER TABLE `authorization` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_city`
--

DROP TABLE IF EXISTS `s_city`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_city` (
  `id_gorod` int NOT NULL AUTO_INCREMENT,
  `gorod` varchar(45) NOT NULL,
  PRIMARY KEY (`id_gorod`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_city`
--

LOCK TABLES `s_city` WRITE;
/*!40000 ALTER TABLE `s_city` DISABLE KEYS */;
INSERT INTO `s_city` VALUES (1,'Необходимо заполнить'),(2,'Мурманск'),(3,'Апатиты'),(4,'Заозёрск'),(5,'Гаджиево'),(6,'Заполярный'),(7,'Кандалакша'),(8,'Кировск'),(9,'Ковдор'),(10,'Кола'),(11,'Мончегорск'),(12,'Оленегорск'),(13,'Островной'),(14,'Полярные Зори'),(15,'Полярный'),(16,'Североморск'),(17,'Снежногорск');
/*!40000 ALTER TABLE `s_city` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_doljnost`
--

DROP TABLE IF EXISTS `s_doljnost`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_doljnost` (
  `key_doljnost` int NOT NULL AUTO_INCREMENT,
  `doljnost` varchar(45) NOT NULL,
  PRIMARY KEY (`key_doljnost`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_doljnost`
--

LOCK TABLES `s_doljnost` WRITE;
/*!40000 ALTER TABLE `s_doljnost` DISABLE KEYS */;
INSERT INTO `s_doljnost` VALUES (1,'Монтер'),(2,'Менеджер'),(3,'Системный администратор');
/*!40000 ALTER TABLE `s_doljnost` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_naznach`
--

DROP TABLE IF EXISTS `s_naznach`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_naznach` (
  `id_naznach` int NOT NULL AUTO_INCREMENT,
  `naznach` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_naznach`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_naznach`
--

LOCK TABLES `s_naznach` WRITE;
/*!40000 ALTER TABLE `s_naznach` DISABLE KEYS */;
INSERT INTO `s_naznach` VALUES (1,'Прием - передача оборудования'),(2,'Замена оборудования');
/*!40000 ALTER TABLE `s_naznach` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_reasons`
--

DROP TABLE IF EXISTS `s_reasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_reasons` (
  `id_reasons` int NOT NULL AUTO_INCREMENT,
  `reasons` varchar(45) NOT NULL,
  PRIMARY KEY (`id_reasons`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_reasons`
--

LOCK TABLES `s_reasons` WRITE;
/*!40000 ALTER TABLE `s_reasons` DISABLE KEYS */;
INSERT INTO `s_reasons` VALUES (1,'Тест'),(2,'Гарантия'),(3,'Неисправность');
/*!40000 ALTER TABLE `s_reasons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_stateequip`
--

DROP TABLE IF EXISTS `s_stateequip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_stateequip` (
  `id_stateequip` int NOT NULL AUTO_INCREMENT,
  `stateequip` varchar(45) NOT NULL,
  PRIMARY KEY (`id_stateequip`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_stateequip`
--

LOCK TABLES `s_stateequip` WRITE;
/*!40000 ALTER TABLE `s_stateequip` DISABLE KEYS */;
INSERT INTO `s_stateequip` VALUES (1,'Новое'),(2,'БУ');
/*!40000 ALTER TABLE `s_stateequip` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_statusad`
--

DROP TABLE IF EXISTS `s_statusad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_statusad` (
  `id_statusad` int NOT NULL AUTO_INCREMENT,
  `statusad` varchar(45) DEFAULT NULL,
  `colorstatusad` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_statusad`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_statusad`
--

LOCK TABLES `s_statusad` WRITE;
/*!40000 ALTER TABLE `s_statusad` DISABLE KEYS */;
INSERT INTO `s_statusad` VALUES (1,'Выполнен','-16732416'),(2,'Выполняется','-4306615'),(3,'В ожидании','-4501504');
/*!40000 ALTER TABLE `s_statusad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_street`
--

DROP TABLE IF EXISTS `s_street`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_street` (
  `id_ylitca` int NOT NULL AUTO_INCREMENT,
  `id_gorod` int NOT NULL,
  `ylitca` varchar(45) NOT NULL,
  PRIMARY KEY (`id_ylitca`),
  KEY `gorod_idx` (`id_gorod`),
  CONSTRAINT `gorod` FOREIGN KEY (`id_gorod`) REFERENCES `s_city` (`id_gorod`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_street`
--

LOCK TABLES `s_street` WRITE;
/*!40000 ALTER TABLE `s_street` DISABLE KEYS */;
INSERT INTO `s_street` VALUES (1,1,''),(2,2,'Проспект Кирова'),(3,2,'Кольский проспект'),(4,2,'Проспект Ленина'),(5,2,'Проспект Героев-Улица Академика Книповича');
/*!40000 ALTER TABLE `s_street` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_typeact`
--

DROP TABLE IF EXISTS `s_typeact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_typeact` (
  `id_typeact` int NOT NULL AUTO_INCREMENT,
  `typeact` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_typeact`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_typeact`
--

LOCK TABLES `s_typeact` WRITE;
/*!40000 ALTER TABLE `s_typeact` DISABLE KEYS */;
INSERT INTO `s_typeact` VALUES (1,'В собственность'),(2,'Во временное владение и пользование'),(3,'Возврат из временного владения и пользования'),(4,'Возврат из собственности');
/*!40000 ALTER TABLE `s_typeact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_typeequip`
--

DROP TABLE IF EXISTS `s_typeequip`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_typeequip` (
  `id_typeequip` int NOT NULL AUTO_INCREMENT,
  `typeequip` varchar(45) NOT NULL,
  PRIMARY KEY (`id_typeequip`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_typeequip`
--

LOCK TABLES `s_typeequip` WRITE;
/*!40000 ALTER TABLE `s_typeequip` DISABLE KEYS */;
INSERT INTO `s_typeequip` VALUES (1,'Адаптер'),(2,'Видеокамера'),(3,'Инжектор питания'),(4,'Коммутатор'),(5,'Маршрутизатор'),(6,'Модем'),(7,'Приставка'),(8,'Терминал');
/*!40000 ALTER TABLE `s_typeequip` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `s_yslyg`
--

DROP TABLE IF EXISTS `s_yslyg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `s_yslyg` (
  `id_yslyg` int NOT NULL AUTO_INCREMENT,
  `yslyga` varchar(80) NOT NULL,
  PRIMARY KEY (`id_yslyg`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `s_yslyg`
--

LOCK TABLES `s_yslyg` WRITE;
/*!40000 ALTER TABLE `s_yslyg` DISABLE KEYS */;
INSERT INTO `s_yslyg` VALUES (1,'Междугородной и международной телефонной связи'),(2,'Предоставление доступа к сети Интернет и услуг связи по передаче данных'),(3,'Предоставление доступа к телевизионным каналам');
/*!40000 ALTER TABLE `s_yslyg` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_abonent`
--

DROP TABLE IF EXISTS `t_abonent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_abonent` (
  `id_abonent` int NOT NULL AUTO_INCREMENT,
  `fioabonent` varchar(45) NOT NULL,
  `id_ylitca` int NOT NULL,
  `adres` varchar(45) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  PRIMARY KEY (`id_abonent`),
  KEY `dsadsa_idx` (`id_ylitca`),
  CONSTRAINT `dsadsa` FOREIGN KEY (`id_ylitca`) REFERENCES `s_street` (`id_ylitca`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_abonent`
--

LOCK TABLES `t_abonent` WRITE;
/*!40000 ALTER TABLE `t_abonent` DISABLE KEYS */;
INSERT INTO `t_abonent` VALUES (1,'Белякович Николай Сергеевич',5,'12 кв 43','(432) 423-4432'),(2,'Канев Евгений Владимирович',4,'22 кв 12','(242) 534-7567'),(3,'Матвеев Егор Сергеевич',3,'1 кв 32','(878) 325-8743'),(4,'Петров Петр Петрович',4,'1 кв 2','(635) 463-4523');
/*!40000 ALTER TABLE `t_abonent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_akt`
--

DROP TABLE IF EXISTS `t_akt`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_akt` (
  `id_akt` int NOT NULL AUTO_INCREMENT,
  `id_dogovor` int NOT NULL,
  `nomact` varchar(45) DEFAULT NULL,
  `id_naznach` int NOT NULL,
  `id_typeact` int NOT NULL,
  `id_sotryd` int NOT NULL,
  `stoimost` int DEFAULT '0',
  `id_statusad` int DEFAULT NULL,
  `arenda` int DEFAULT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`id_akt`),
  KEY `tatd_idx` (`id_dogovor`),
  KEY `tats_idx` (`id_sotryd`),
  KEY `tats_idx1` (`id_statusad`),
  KEY `tasn_idx` (`id_naznach`),
  KEY `tata_idx` (`id_typeact`),
  CONSTRAINT `tas` FOREIGN KEY (`id_statusad`) REFERENCES `s_statusad` (`id_statusad`),
  CONSTRAINT `tasn` FOREIGN KEY (`id_naznach`) REFERENCES `s_naznach` (`id_naznach`),
  CONSTRAINT `tata` FOREIGN KEY (`id_typeact`) REFERENCES `s_typeact` (`id_typeact`),
  CONSTRAINT `tatd` FOREIGN KEY (`id_dogovor`) REFERENCES `t_dogovor` (`id_dogovor`),
  CONSTRAINT `tats` FOREIGN KEY (`id_sotryd`) REFERENCES `authorization` (`id_sotryd`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_akt`
--

LOCK TABLES `t_akt` WRITE;
/*!40000 ALTER TABLE `t_akt` DISABLE KEYS */;
INSERT INTO `t_akt` VALUES (11,1,'Акт №1',1,1,3,3500,3,0,'2020-06-03'),(12,1,'Акт №3',1,4,3,14500,3,0,'2020-06-03'),(13,1,'Акт №2',1,2,3,5250,3,24,'2020-06-03'),(14,1,'Акт №4',1,3,3,7000,3,0,'2020-06-03'),(15,1,'Акт №5',2,4,3,0,3,0,'2020-06-03'),(16,1,'Акт №5',2,1,3,7000,3,0,'2020-06-03'),(17,1,'Акт №6',2,3,3,5500,3,0,'2020-06-03'),(18,1,'Акт №6',2,2,3,5500,3,12,'2020-06-03');
/*!40000 ALTER TABLE `t_akt` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_dogovor`
--

DROP TABLE IF EXISTS `t_dogovor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_dogovor` (
  `id_dogovor` int NOT NULL AUTO_INCREMENT,
  `nomdogovor` varchar(45) NOT NULL,
  `id_yslyg` int NOT NULL,
  `id_ylitca` int NOT NULL,
  `adres` varchar(45) NOT NULL,
  `id_facialscore` int NOT NULL,
  `id_sotryd` int NOT NULL,
  `id_statusad` int DEFAULT NULL,
  `date` date NOT NULL,
  PRIMARY KEY (`id_dogovor`),
  KEY `tdss_idx` (`id_statusad`),
  KEY `tdts_idx` (`id_sotryd`),
  KEY `id_facialscore_idx` (`id_facialscore`),
  KEY `dsadad_idx` (`id_ylitca`),
  KEY `dasdsa_idx` (`id_yslyg`),
  CONSTRAINT `id_facialscore` FOREIGN KEY (`id_facialscore`) REFERENCES `t_facialscore` (`id_facialscore`),
  CONSTRAINT `sdaas` FOREIGN KEY (`id_ylitca`) REFERENCES `s_street` (`id_ylitca`),
  CONSTRAINT `tdss` FOREIGN KEY (`id_statusad`) REFERENCES `s_statusad` (`id_statusad`),
  CONSTRAINT `tdsy` FOREIGN KEY (`id_yslyg`) REFERENCES `s_yslyg` (`id_yslyg`),
  CONSTRAINT `tdts` FOREIGN KEY (`id_sotryd`) REFERENCES `authorization` (`id_sotryd`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_dogovor`
--

LOCK TABLES `t_dogovor` WRITE;
/*!40000 ALTER TABLE `t_dogovor` DISABLE KEYS */;
INSERT INTO `t_dogovor` VALUES (1,'Договор №1',1,3,'13 кв 85',1,2,2,'2020-06-03');
/*!40000 ALTER TABLE `t_dogovor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_facialscore`
--

DROP TABLE IF EXISTS `t_facialscore`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_facialscore` (
  `id_facialscore` int NOT NULL AUTO_INCREMENT,
  `facialscore` varchar(45) NOT NULL,
  `id_abonent` int NOT NULL,
  PRIMARY KEY (`id_facialscore`),
  KEY `tfta_idx` (`id_abonent`),
  CONSTRAINT `tfta` FOREIGN KEY (`id_abonent`) REFERENCES `t_abonent` (`id_abonent`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_facialscore`
--

LOCK TABLES `t_facialscore` WRITE;
/*!40000 ALTER TABLE `t_facialscore` DISABLE KEYS */;
INSERT INTO `t_facialscore` VALUES (1,'089709870970',1),(2,'657742353425',1),(3,'645645776858',2),(4,'143576578795',3);
/*!40000 ALTER TABLE `t_facialscore` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_nakladnaya`
--

DROP TABLE IF EXISTS `t_nakladnaya`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_nakladnaya` (
  `id_nakladnaya` int NOT NULL AUTO_INCREMENT,
  `numnaklad` varchar(45) NOT NULL,
  `id_postavshik` int NOT NULL,
  `datenakl` date NOT NULL,
  PRIMARY KEY (`id_nakladnaya`),
  KEY `tntp_idx` (`id_postavshik`),
  CONSTRAINT `tntp` FOREIGN KEY (`id_postavshik`) REFERENCES `t_postavshik` (`id_postavshik`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_nakladnaya`
--

LOCK TABLES `t_nakladnaya` WRITE;
/*!40000 ALTER TABLE `t_nakladnaya` DISABLE KEYS */;
INSERT INTO `t_nakladnaya` VALUES (4,'1',1,'2020-03-25'),(7,'2',1,'2020-08-07');
/*!40000 ALTER TABLE `t_nakladnaya` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_postavshik`
--

DROP TABLE IF EXISTS `t_postavshik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_postavshik` (
  `id_postavshik` int NOT NULL AUTO_INCREMENT,
  `naimpost` varchar(45) NOT NULL,
  `INN` varchar(45) NOT NULL,
  `KPP` varchar(45) NOT NULL,
  `OGRN` varchar(45) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  `email` varchar(45) NOT NULL,
  `id_ylitca` int NOT NULL,
  `adres` varchar(45) NOT NULL,
  PRIMARY KEY (`id_postavshik`),
  KEY `street_idx` (`id_ylitca`),
  CONSTRAINT `dasd` FOREIGN KEY (`id_ylitca`) REFERENCES `s_street` (`id_ylitca`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_postavshik`
--

LOCK TABLES `t_postavshik` WRITE;
/*!40000 ALTER TABLE `t_postavshik` DISABLE KEYS */;
INSERT INTO `t_postavshik` VALUES (1,'ООО Техном','312312312312','312343254','2131231231233','(563) 534-8576','texnom@mail.ru',4,'22 кв 121');
/*!40000 ALTER TABLE `t_postavshik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_sklad`
--

DROP TABLE IF EXISTS `t_sklad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_sklad` (
  `id_skladequip` int NOT NULL AUTO_INCREMENT,
  `id_typeequip` int NOT NULL,
  `equipment` varchar(45) NOT NULL,
  `count` int DEFAULT '0',
  PRIMARY KEY (`id_skladequip`),
  KEY `tste_idx` (`id_typeequip`),
  CONSTRAINT `tste` FOREIGN KEY (`id_typeequip`) REFERENCES `s_typeequip` (`id_typeequip`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_sklad`
--

LOCK TABLES `t_sklad` WRITE;
/*!40000 ALTER TABLE `t_sklad` DISABLE KEYS */;
INSERT INTO `t_sklad` VALUES (1,7,'IPTV HD mini',989),(2,7,' IPTV SML-482 Base',992),(3,4,'TP-LINK TL-SF1005D',982),(4,2,'Hikvision HiWatch DS-I120',199),(5,2,'Hikvision DS-2CD-VC1W ',119),(6,4,'NETIS ST3105S',49);
/*!40000 ALTER TABLE `t_sklad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_specact`
--

DROP TABLE IF EXISTS `t_specact`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_specact` (
  `id_specact` int NOT NULL AUTO_INCREMENT,
  `id_act` int NOT NULL,
  `id_skladequip` int NOT NULL,
  `serialscore` varchar(45) NOT NULL,
  `id_stateequip` int DEFAULT NULL,
  `price` int NOT NULL,
  `dateArend` date DEFAULT NULL,
  `id_reasons` int DEFAULT NULL,
  PRIMARY KEY (`id_specact`),
  KEY `tsa_idx` (`id_act`),
  KEY `tsse_idx` (`id_skladequip`),
  KEY `tsste_idx` (`id_stateequip`),
  KEY `tssr_idx` (`id_reasons`),
  CONSTRAINT `tsa` FOREIGN KEY (`id_act`) REFERENCES `t_akt` (`id_akt`),
  CONSTRAINT `tsse` FOREIGN KEY (`id_skladequip`) REFERENCES `t_sklad` (`id_skladequip`),
  CONSTRAINT `tssr` FOREIGN KEY (`id_reasons`) REFERENCES `s_reasons` (`id_reasons`),
  CONSTRAINT `tsste` FOREIGN KEY (`id_stateequip`) REFERENCES `s_stateequip` (`id_stateequip`)
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_specact`
--

LOCK TABLES `t_specact` WRITE;
/*!40000 ALTER TABLE `t_specact` DISABLE KEYS */;
INSERT INTO `t_specact` VALUES (31,12,3,'242353465346',1,4500,'2020-06-03',2),(32,12,3,'432424234246',1,4500,'2020-06-03',2),(33,12,2,'675685453246',1,5500,'2020-06-03',3),(36,14,3,'457562346645',1,4500,'2020-06-03',3),(37,14,1,'765867867867',1,2500,'2020-06-03',3),(41,15,3,'124214124786',1,4500,'2020-06-03',2),(42,15,1,'543543534652',1,2500,'2020-06-03',3),(43,15,2,'645235236512',1,5500,'2020-06-03',3),(44,16,3,'534253465435',1,4500,NULL,3),(45,16,1,'464313535463',1,2500,NULL,3),(52,17,2,'645654645547',1,5500,'2020-06-03',3),(55,18,2,'049734230958',1,5500,NULL,2),(56,11,4,'312312321312',1,1250,NULL,2),(57,11,5,'534534634634',1,2250,NULL,2),(58,13,6,'453465472351',1,750,NULL,2),(59,13,3,'657568756741',1,4500,NULL,2);
/*!40000 ALTER TABLE `t_specact` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `t_specnakl`
--

DROP TABLE IF EXISTS `t_specnakl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `t_specnakl` (
  `id_specnakl` int NOT NULL AUTO_INCREMENT,
  `id_nakladnaya` int NOT NULL,
  `id_skladequip` int NOT NULL,
  `count` int NOT NULL,
  `price` int NOT NULL,
  PRIMARY KEY (`id_specnakl`),
  KEY `tsn_idx` (`id_nakladnaya`),
  KEY `tsts_idx` (`id_skladequip`),
  CONSTRAINT `tsn` FOREIGN KEY (`id_nakladnaya`) REFERENCES `t_nakladnaya` (`id_nakladnaya`),
  CONSTRAINT `tsts` FOREIGN KEY (`id_skladequip`) REFERENCES `t_sklad` (`id_skladequip`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `t_specnakl`
--

LOCK TABLES `t_specnakl` WRITE;
/*!40000 ALTER TABLE `t_specnakl` DISABLE KEYS */;
INSERT INTO `t_specnakl` VALUES (6,4,3,30,3333),(7,4,1,111,3123),(8,7,1,1000,2500),(9,7,2,1000,5500),(10,7,3,1000,4500),(11,4,4,200,1250),(12,4,5,120,2250),(13,7,6,50,750);
/*!40000 ALTER TABLE `t_specnakl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'rostelecom4'
--
/*!50003 DROP PROCEDURE IF EXISTS `Act` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `Act`(in NomDogovor int, in NomAct int)
BEGIN
SELECT 
	s_city.gorod,t_akt.date,t_abonent.fioabonent,t_dogovor.nomdogovor,t_dogovor.date,t_akt.stoimost,
    concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip' , s_stateequip.stateequip, t_specact.serialscore,t_specact.price
FROM
	t_specact, t_akt, t_dogovor, t_sklad,s_typeequip, s_stateequip, t_facialscore, t_abonent,s_street,s_city
WHERE
	t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor and t_dogovor.id_facialscore = t_facialscore.id_facialscore 
    and t_facialscore.id_abonent = t_abonent.id_abonent and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod
    and t_dogovor.id_dogovor = NomDogovor and t_akt.id_akt = NomAct;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ActArenda` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ActArenda`(in NomDogovor int, in NomAct int)
BEGIN
SELECT 
	s_city.gorod,t_akt.date,t_abonent.fioabonent,t_dogovor.nomdogovor,t_dogovor.date,
    concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip' , s_stateequip.stateequip, t_specact.serialscore,t_specact.price,t_specact.price/t_akt.arenda as 'pricearenda', t_akt.arenda
FROM
	t_specact, t_akt, t_dogovor, t_sklad, s_typeequip, s_stateequip, t_facialscore, t_abonent,s_street,s_city
WHERE
	t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor	and t_dogovor.id_facialscore = t_facialscore.id_facialscore 
    and t_facialscore.id_abonent = t_abonent.id_abonent and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod
    and t_dogovor.id_dogovor = NomDogovor and t_akt.id_akt = NomAct;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ActReplaceArend` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ActReplaceArend`(in NomDogovor int, in NomAct varchar(45))
BEGIN
SELECT distinct T2.gorod,T2.date,T2.fioabonent,T2.nomdogovor,T2.date1,T2.Equip, T2.serialscore,T2.stoimost,
T1.Equip1,T1.stateequip1,T1.serialscore1,T1.price,T1.pricearenda,T1.arenda,T2.reasons
FROM
(SELECT concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip1' , s_stateequip.stateequip as 'stateequip1', t_specact.serialscore as 'serialscore1',
    t_specact.price as 'price',t_specact.price/t_akt.arenda as 'pricearenda',t_akt.arenda
     FROM t_specact, t_akt, t_dogovor, t_sklad,s_typeequip, s_stateequip
     WHERE t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_typeact = 2
    and t_dogovor.id_dogovor = NomDogovor and t_akt.nomact = NomAct) T1,
(SELECT s_city.gorod,t_akt.date,t_abonent.fioabonent,t_dogovor.nomdogovor,t_dogovor.date as 'date1',concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip' ,t_specact.serialscore,t_akt.stoimost,s_reasons.reasons
     FROM t_specact, t_akt, t_dogovor, t_sklad,s_typeequip, s_stateequip, t_facialscore, t_abonent,s_street,s_city,s_reasons
     WHERE t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor and t_dogovor.id_facialscore = t_facialscore.id_facialscore 
    and t_facialscore.id_abonent = t_abonent.id_abonent and t_akt.id_typeact = 3 and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod
    and t_specact.id_reasons = s_reasons.id_reasons
    and t_dogovor.id_dogovor = NomDogovor and t_akt.nomact = NomAct) T2;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ActReplaceSale` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ActReplaceSale`(in NomDogovor int, in NomAct varchar(45))
BEGIN
SELECT T2.gorod,T2.date,T2.fioabonent,T2.nomdogovor,T2.date1,T2.Equip,T2.serialscore,
T1.Equip1,T1.stateequip1,T1.serialscore1,T1.price,T1.stoimost,T2.reasons
FROM
(SELECT concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip1' , s_stateequip.stateequip as 'stateequip1', t_specact.serialscore as 'serialscore1',
    t_specact.price as 'price', t_akt.stoimost
     FROM t_specact, t_akt, t_dogovor, t_sklad,s_typeequip, s_stateequip
     WHERE t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor and t_akt.id_typeact = 1
    and t_dogovor.id_dogovor = NomDogovor and t_akt.nomact = NomAct) T1,
(SELECT s_city.gorod,t_akt.date,t_abonent.fioabonent,t_dogovor.nomdogovor,t_dogovor.date as 'date1',concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip' ,t_specact.serialscore,s_reasons.reasons
     FROM t_specact, t_akt, t_dogovor, t_sklad,s_typeequip, s_stateequip, t_facialscore, t_abonent,s_street,s_city,s_reasons
     WHERE t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor and t_dogovor.id_facialscore = t_facialscore.id_facialscore 
    and t_specact.id_reasons = s_reasons.id_reasons
    and t_facialscore.id_abonent = t_abonent.id_abonent and t_akt.id_typeact = 4 and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod
    and t_dogovor.id_dogovor = NomDogovor and t_akt.nomact = NomAct) T2;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ActReturnArenda` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ActReturnArenda`(in NomDogovor int, in NomAct int)
BEGIN
SELECT 
	s_city.gorod,t_akt.date,t_abonent.fioabonent,t_dogovor.nomdogovor,t_dogovor.date as 'date2',
    concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip' , t_specact.serialscore, t_specact.dateArend,s_reasons.reasons
FROM
	t_specact, t_akt, t_dogovor, t_sklad,s_typeequip, s_stateequip, t_facialscore, t_abonent,s_street,s_city,s_reasons
WHERE
	t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor and t_dogovor.id_facialscore = t_facialscore.id_facialscore 
    and t_facialscore.id_abonent = t_abonent.id_abonent and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod
    and t_specact.id_reasons = s_reasons.id_reasons
    and t_dogovor.id_dogovor = NomDogovor and t_akt.id_akt = NomAct;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `ActReturnSale` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `ActReturnSale`(in NomDogovor int, in NomAct int)
BEGIN
SELECT 
	s_city.gorod,t_akt.date,t_abonent.fioabonent,t_dogovor.nomdogovor,t_dogovor.date as 'date2',
    concat(s_typeequip.typeequip," ",t_sklad.equipment) as 'Equip' , t_specact.serialscore, t_specact.dateArend,t_specact.price,t_akt.stoimost,s_reasons.reasons
FROM
	t_specact, t_akt, t_dogovor, t_sklad,s_typeequip, s_stateequip, t_facialscore, t_abonent,s_street,s_city,s_reasons
WHERE
	t_specact.id_act = t_akt.id_akt and t_specact.id_skladequip = t_sklad.id_skladequip and t_specact.id_stateequip = s_stateequip.id_stateequip 
    and t_sklad.id_typeequip = s_typeequip.id_typeequip and t_akt.id_dogovor = t_dogovor.id_dogovor and t_dogovor.id_facialscore = t_facialscore.id_facialscore 
    and t_facialscore.id_abonent = t_abonent.id_abonent and t_dogovor.id_ylitca = s_street.id_ylitca and s_street.id_gorod = s_city.id_gorod
    and t_specact.id_reasons = s_reasons.id_reasons
    and t_dogovor.id_dogovor = NomDogovor and t_akt.id_akt = NomAct;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-01  4:00:17
