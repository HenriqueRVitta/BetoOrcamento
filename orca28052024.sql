-- MySQL dump 10.13  Distrib 8.0.33, for Win64 (x86_64)
--
-- Host: mysql.isagor.com.br    Database: isagorcombr
-- ------------------------------------------------------
-- Server version	5.7.44-48-log

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
-- Table structure for table `tb_aliquota`
--

DROP TABLE IF EXISTS `tb_aliquota`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_aliquota` (
  `al_id` int(11) NOT NULL AUTO_INCREMENT,
  `al_indice` int(11) DEFAULT NULL,
  `al_data` datetime DEFAULT NULL,
  `al_percentual` decimal(8,2) DEFAULT NULL,
  PRIMARY KEY (`al_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_aliquota`
--

LOCK TABLES `tb_aliquota` WRITE;
/*!40000 ALTER TABLE `tb_aliquota` DISABLE KEYS */;
INSERT INTO `tb_aliquota` VALUES (1,1,NULL,8.30),(2,2,NULL,2.78),(3,3,NULL,8.00),(4,4,NULL,0.89),(5,5,NULL,20.00),(6,6,NULL,2.22);
/*!40000 ALTER TABLE `tb_aliquota` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_cliente`
--

DROP TABLE IF EXISTS `tb_cliente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_cliente` (
  `cl_id` int(11) NOT NULL AUTO_INCREMENT,
  `cl_nome` varchar(80) DEFAULT NULL,
  `cl_senha` varchar(255) DEFAULT NULL,
  `cl_email` varchar(80) DEFAULT NULL,
  `cl_data_validade` date DEFAULT NULL,
  PRIMARY KEY (`cl_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_cliente`
--

LOCK TABLES `tb_cliente` WRITE;
/*!40000 ALTER TABLE `tb_cliente` DISABLE KEYS */;
INSERT INTO `tb_cliente` VALUES (1,'Cliente Teste','senha',NULL,NULL);
/*!40000 ALTER TABLE `tb_cliente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_cliente_despesas`
--

DROP TABLE IF EXISTS `tb_cliente_despesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_cliente_despesas` (
  `pd_id` int(11) NOT NULL AUTO_INCREMENT,
  `pd_cliente` int(11) DEFAULT NULL,
  `pd_despesa` int(11) DEFAULT NULL,
  `pd_valor_previsto` decimal(15,2) DEFAULT NULL,
  PRIMARY KEY (`pd_id`),
  KEY `fk_projeto_despesa_idx` (`pd_despesa`),
  KEY `fk_cliete_despesa_cliente_idx` (`pd_cliente`),
  CONSTRAINT `fk_cliente_despesas_cliente` FOREIGN KEY (`pd_cliente`) REFERENCES `tb_cliente` (`cl_id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_cliente_despesas_despesas` FOREIGN KEY (`pd_despesa`) REFERENCES `tb_despesas` (`da_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=453 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_cliente_despesas`
--

LOCK TABLES `tb_cliente_despesas` WRITE;
/*!40000 ALTER TABLE `tb_cliente_despesas` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_cliente_despesas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_contrato`
--

DROP TABLE IF EXISTS `tb_contrato`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_contrato` (
  `co_id` int(11) NOT NULL AUTO_INCREMENT,
  `co_cliente` int(11) DEFAULT NULL,
  `co_data` date DEFAULT NULL,
  `co_valor` decimal(15,2) DEFAULT NULL,
  PRIMARY KEY (`co_id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_contrato`
--

LOCK TABLES `tb_contrato` WRITE;
/*!40000 ALTER TABLE `tb_contrato` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_contrato` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_custos`
--

DROP TABLE IF EXISTS `tb_custos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_custos` (
  `cu_id` int(11) NOT NULL AUTO_INCREMENT,
  `cu_codigo` varchar(4) DEFAULT NULL,
  `cu_descricao` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`cu_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_custos`
--

LOCK TABLES `tb_custos` WRITE;
/*!40000 ALTER TABLE `tb_custos` DISABLE KEYS */;
INSERT INTO `tb_custos` VALUES (1,'01','TAXAS DIVERSAS'),(2,'0101','PROFISSIONAL / SERVIÇO PARA APROVAÇÃO DE PROJETO LEGAL'),(3,'0102','RRT / ART'),(6,'0202','PLOTAGENS'),(7,'0203','ALUGUEL DE ESPAÇO PARA REUNIÕES'),(8,'0205','CONTRATAÇÃO DE 3D'),(9,'03','DESLOCAMENTOS'),(10,'0301','ENTREGA DE DOCUMENTOS'),(11,'0302','HORA TÉCNICA PARA REUNIÕES EXTRAS'),(12,'0303','LEVANTAMENTO MÉTRICO E FOTOGRÁFICO'),(13,'0304','VISITAS TÉCNICAS'),(15,'0306','ESTACIONAMENTOS'),(17,'0401','PRESENTE FECHAMENTO DE PARCERIA'),(18,'0204','CONTRATAÇÃO DE ESTAGIARIO EXTRA'),(19,'0000','DIGITALIZAÇÃO '),(20,'AAAA','CONTRATAÇÃO ESPECIALISTA');
/*!40000 ALTER TABLE `tb_custos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_despesas`
--

DROP TABLE IF EXISTS `tb_despesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_despesas` (
  `da_id` int(11) NOT NULL AUTO_INCREMENT,
  `da_codigo` varchar(6) DEFAULT NULL,
  `da_descricao` varchar(80) DEFAULT NULL,
  `da_formula` varchar(45) DEFAULT NULL,
  `da_hora_trabalhada` int(11) DEFAULT NULL,
  PRIMARY KEY (`da_id`)
) ENGINE=InnoDB AUTO_INCREMENT=91 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_despesas`
--

LOCK TABLES `tb_despesas` WRITE;
/*!40000 ALTER TABLE `tb_despesas` DISABLE KEYS */;
INSERT INTO `tb_despesas` VALUES (1,'01','PROFISSIONAIS E COLABORADORES',NULL,NULL),(2,'0101','SOCIO',NULL,138),(3,'0102','SOCIO',NULL,138),(4,'0103','SOCIO',NULL,138),(5,'0104','SOCIO',NULL,138),(6,'0105','SOCIO',NULL,138),(8,'0110','ARQUITETO I',NULL,275),(9,'011001','PROVISÃO DE 13º','#0110*%1',NULL),(10,'011002','PROVISÃO DE 1/3 13º','#0110*%2',NULL),(11,'011003','FGTS','#0110*%3',NULL),(12,'011004','PROVISÃO DE FGTS SOBRE 13º E FÉRIAS','#0110*%4',NULL),(13,'011005','INSS','#0110*%5',NULL),(14,'011006','PROVISÃO DE INSS SOBRFE 13º E FÉRIAS','#0110*%6',NULL),(15,'0111','ARQUITETO II',NULL,275),(16,'011101','PROVISÃO DE 13º','#0111*%1',NULL),(17,'011102','PROVISÃO DE 1/3 13º','#0111*%2',NULL),(18,'011103','FGTS','#0111*%3',NULL),(19,'011104','PROVISÃO DE FGTS SOBRE 13º E FÉRIAS','#0111*%4',NULL),(20,'011105','INSS','#0111*%5',NULL),(21,'011106','PROVISÃO DE INSS SOBRFE 13º E FÉRIAS','#0111*%6',NULL),(22,'0112','ARQUITETO III',NULL,275),(23,'011201','PROVISÃO DE 13º','#0112*%1',NULL),(24,'011202','PROVISÃO DE 1/3 13º','#0112*%2',NULL),(25,'011203','FGTS','#0112*%3',NULL),(26,'011204','PROVISÃO DE FGTS SOBRE 13º E FÉRIAS','#0112*%4',NULL),(27,'011205','INSS','#0112*%5',NULL),(28,'011206','PROVISÃO DE INSS SOBRFE 13º E FÉRIAS','#0112*%6',NULL),(29,'0113','ARQUITETO IV',NULL,275),(30,'011301','PROVISÃO DE 13º','#0113*%1',NULL),(31,'011302','PROVISÃO DE 1/3 13º','#0113*%2',NULL),(32,'011303','FGTS','#0113*%3',NULL),(33,'011304','PROVISÃO DE FGTS SOBRE 13º E FÉRIAS','#0113*%4',NULL),(34,'011305','INSS','#0113*%5',NULL),(35,'011306','PROVISÃO DE INSS SOBRFE 13º E FÉRIAS','#0113*%6',NULL),(36,'0120','BOLSISTA',NULL,172),(37,'012001','AUXILIO TRANSPORTE','se#0120(6*2)*22',NULL),(38,'0130','ADMINISTRATIVO I',NULL,275),(39,'013001','PROVISÃO DE 13º','#0130*%1',NULL),(40,'013002','PROVISÃO DE 1/3 13º','#0130*%2',NULL),(41,'013003','FGTS','#0130*%3',NULL),(42,'013004','PROVISÃO DE FGTS SOBRE 13º E FÉRIAS','#0130*%4',NULL),(43,'013005','INSS','#0130*%5',NULL),(44,'013006','PROVISÃO DE INSS SOBRFE 13º E FÉRIAS','#0130*%6',NULL),(45,'0140','ASSESSORIA CONTABIL',NULL,NULL),(46,'02','GUIAS',NULL,NULL),(47,'0201','GUIA DO SIMPLES NACIONAL',NULL,NULL),(48,'0202','GUIA DO PRO-LABORE',NULL,NULL),(49,'0203','GUIA DO INSS',NULL,NULL),(50,'0204','ISS(IMPOSTO MUNICIPAL)',NULL,NULL),(51,'0205','ANUIDADE CAU PF',NULL,NULL),(52,'0206','ANUIDADE PJ',NULL,NULL),(53,'03','ESTRUTURA FÍSICA',NULL,NULL),(54,'0301','CONDOMÍNIO',NULL,NULL),(55,'0302','ALUGUEL',NULL,NULL),(56,'0303','IPTU',NULL,NULL),(57,'0304','ENERGIA',NULL,NULL),(58,'0305','ÁGUA',NULL,NULL),(59,'0306','INTERNET E TELEFONE',NULL,NULL),(60,'0307','SUPERMERCADO',NULL,NULL),(61,'0308','MATERIAL DE LIMPEZA',NULL,NULL),(62,'0309','MANUTENÇÃO ESPAÇO FÍSICO',NULL,NULL),(63,'04','ESTRUTURA DE SERVIÇOS',NULL,NULL),(64,'0401','MANUTENÇÃO DE COMPUTADORES',NULL,NULL),(65,'0402','MATERIAL DE IMPRESSORA',NULL,NULL),(66,'0403','GRÁFICA',NULL,NULL),(67,'0404','PAPELARIA',NULL,NULL),(68,'0405','DOMÍNIO SITE',NULL,NULL),(69,'0406','DOMÍNIO EMAIL',NULL,NULL),(70,'0407','MKT DIGITAL',NULL,NULL),(71,'0408','SOFTWARE OFICIAIS',NULL,NULL),(72,'0409','ASSINATURAS MENSAIS',NULL,NULL),(73,'0410','TARIFAS BANCÁRIAS',NULL,NULL),(74,'05','INVESTIMENTOS',NULL,NULL),(75,'0501','CURSO INCORPORAÇÃO',NULL,NULL),(76,'0502','MESTRADO UFMG',NULL,NULL),(77,'0503','GRADUAÇÃO',NULL,NULL),(78,'0504','CURSOS E EVENTOS',NULL,NULL),(79,'0505','PÓS',NULL,NULL),(80,'0506','COMPUTADOR',NULL,NULL),(81,'0507','SOFTWARE',NULL,NULL),(82,'06','DESLOCAMENTO',NULL,NULL),(83,'0601','DESLOCAMENTO DIÁRIOS AO ESCRITÓRIO','20/6,8*3,3*20',NULL),(84,'0602','DESGASTE DO AUTOMOVEL','(75000*0,01)/12',NULL),(85,'010101','PROVISÃO DE 13º','#0101*%1',NULL),(86,'010102','PROVISÃO 1/3 13º','#0101*%2',NULL),(87,'010103','FGTS','#0101*%3',NULL),(88,'010104','PROVISÃO FGTS SOBRE 13º E FERIAS','#0101*%4',NULL),(89,'010105','INSS','#0101*%5',NULL),(90,'010106','PROVISÃO DE INSS SOBRE 13º E FERIAS','#0101*%6',NULL);
/*!40000 ALTER TABLE `tb_despesas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_etapas`
--

DROP TABLE IF EXISTS `tb_etapas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_etapas` (
  `et_id` int(11) NOT NULL AUTO_INCREMENT,
  `et_codigo` varchar(6) DEFAULT NULL,
  `et_descricao` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`et_id`)
) ENGINE=InnoDB AUTO_INCREMENT=124 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_etapas`
--

LOCK TABLES `tb_etapas` WRITE;
/*!40000 ALTER TABLE `tb_etapas` DISABLE KEYS */;
INSERT INTO `tb_etapas` VALUES (1,'01','ETAPA PRELIMINAR'),(2,'0101','REUNIÃO DE 1º CONTATO/BRIEFING'),(3,'010101','MONTAGEM DE ATA REUNIÃO'),(4,'010102','OBJETIVOS DO CLIENTE E DA OBRA'),(5,'010103','PRAZOS E RECURSOS DISPONIVEIS'),(6,'010104','PADRÕES DE CONTRUÇÕES E ACABAMENTOS PRETENDID'),(7,'010105','FECHAMENTO E DISTRIBUIÇÃO DE ATA DE REUNIÃO'),(8,'0102','PROPOSTA COMERCIAL E ORÇAMENTO DO TRABALHO'),(9,'010201','ELABORAÇÃO'),(10,'010202','RENIÃO DE APRESENTAÇÃO'),(11,'0103','CONTRATO DE PRESTAÇÃO DE SERVIÇOS'),(12,'010301','ELABORAÇÃO'),(13,'010302','REUNIÃO DE APRESENTAÇÃO'),(14,'0104','PERFIL DO CLIENTE'),(15,'010401','ESTUDO DO \"ESTILO DE VIDA\"'),(16,'0105','LEVANTAMENTO (LV)'),(17,'010501','FÍSICO(CONSIDERADO PASSAR A LIMPO DEPOIS)'),(18,'010502','FOTOGRÁFICO'),(19,'010503','INFORMAÇÕES SOBRE O TERRENO'),(20,'010504','INFORMAÇÕES SOBE O ENTORNO'),(21,'010505','CONVENÇÃO DE OBRAS DO CONDOMÍNIO'),(22,'010506','LEGISLAÇÃO ARQUITETÕNICA E URBANÍSTICA'),(23,'0106','PROGRAMA DE NECESSIDADE (EV)'),(24,'010601','ORGANOGRAMAS E FLUXOGRAMAS'),(25,'010602','RELAÇÃO DOS SETORES'),(26,'010603','NECESSIDADES DE ÁREA'),(27,'010604','CÓDIGO DE OBRAS'),(28,'010605','NORMAS PEERTINENTES'),(29,'0107','ESTUDO DE VIABILIDADE (EV)'),(30,'0108','VISITAS TÉCNICAS'),(31,'010801','ILUMINAÇÃO'),(32,'010802','REVESTIMENTOS'),(33,'010803','MARCENARIA'),(34,'02','ESTUDO PRELIMINAR (EP)'),(35,'0201','SITUAÇÃO'),(36,'0202','PLANTA GERAL DE IMPLANTAÇÃO'),(37,'0203','PLANTAS DOS PAVIMENTOS'),(38,'0204','PLANTA COBERTURA'),(39,'0205','CORTES (LONGITUDINAIS E TRANSVERSAIS)'),(40,'0206','ELAVAÇÕES(FACHADAS)'),(41,'0207','MEMORIAL JUSTIFICADO'),(42,'0208','ANÁLISE PRELIMINAR DE CUSTO'),(43,'0209','MAQUETE(ESTUDO VOLUMÉTRICO)'),(44,'0210','IMAGENS PERSPECTIVADAS'),(45,'0211','VÍDEO'),(46,'0212','REUNIÃO DE APRESENTAÇÃO E APROVAÇÃO'),(47,'0213','POSSÍVEIS ALTERAÇÕES'),(48,'0214','REUNIÃO DE REAPRESENTAÇÃO'),(49,'03','ANTEPROJETO (AP-ARQ)'),(50,'0301','SITUAÇÃO'),(51,'0302','PLANTA GERAL DE IMPLANTAÇÃO'),(52,'0303','PLANTA DE TERRAPLANAGEM'),(53,'0304','PLANTAS DOS PAVIMENTOS'),(54,'0305','PLANTA COBERTURA'),(55,'0306','CORTES (LONGITUDINAIS E TRANSVERSAIS)'),(56,'0307','ELEVAÇÕES(FACHADAS)'),(57,'0308','MEMORIAL DE ASPECTOS CONSTRUTIVOS'),(58,'0309','DISCRIMINAÇÃO TÉCNICA'),(59,'0310','QUADRO GERAL DE ACABAMENTO'),(60,'0311','LISTA PRELIMINAR DE MATERIAIS'),(61,'0312','IMAGENS PERSPECTIVADAS'),(62,'0313','ESTIMATIVA DE CUSTO'),(63,'0314','REUNIÃO DE APRESENTAÇÃO E APROVAÇÃO'),(64,'0315','POSSÍVEIS ALTERAÇÕES'),(65,'0316','REUNIÃO DE REAPRESENTAÇÃO'),(66,'04','PROJETO LEGAL (PL)'),(67,'0401','PLANTA GERAL DE IMPLANTAÇÃO'),(68,'0402','PLANTA DE TERRAPLANAGEM'),(69,'0403','PLANTAS DOS PAVIMENTOS'),(70,'0404','PLANTA DA COBERTURA'),(71,'0405','CORTES (LONGITUDINAIS E TRANSVERSAIS)'),(72,'0406','ELAVAÇÕES(FACHADAS)'),(73,'0407','DETALHES CONSTRUTIVOS'),(74,'0408','MEMORIAL DESCRITIVO DA EDIFICAÇÃO'),(75,'0409','PROTOCOLAÇÃO E ACOMPANHAMENTO EM ORGÃO OFICIAL'),(76,'0410','POSSÍVEIS ALTERAÇÕES'),(77,'05','PROJETO PARA EXECUÇÃO(PE)'),(78,'0501','PLANTA GERAL DE IMPLANTAÇÃO'),(79,'0502','PLANTA DE TERRAPLANAGEM'),(80,'0503','PLANTAS DOS PAVIMENTOS'),(81,'0504','PLANTA DA COBERTURA'),(82,'0505','CORTES (LONGITUDINAIS E TRANSVERSAIS)'),(83,'0506','ELAVAÇÕES(FACHADAS)'),(84,'0507','PLANTAS, CORTES E LEVAÇÕES DE AMBIENTES'),(85,'0508','DETALHES CONSTRUTIVOS'),(86,'0509','DISCRIMINAÇÃO TÉCNICA'),(87,'0510','QUADRO GERAL DE ACABAMENTO'),(88,'0511','ESPECIFICAÇÕES'),(89,'0512','LISTA DE MATERIAIS'),(90,'0513','IMAGENS PERSPECTIVADAS'),(91,'0514','ORÇAMENTO DE PROJETO'),(92,'06','COORDENAÇÃO E COMPATIBILIZAÇÃO DE PROJETO (CP)'),(93,'0601','RELATORIOS TÉCNICOS'),(94,'060101','PRAZOS E CRONOGRAMAS'),(95,'060102','RECURSOS HUMANOS'),(96,'060103','MATERIAIS NECESSÁRIOS'),(97,'060104','INTERFERÊNCIA E DESCONFORMIDADES'),(98,'060105','ACOMPANHAMENTO DO AMDAMENTO DAS ATIVIDADES'),(99,'0602','ATAS REUNIÕES'),(100,'0603','PROJETOS COMPATIBILIDADES'),(101,'07','COORDENAÇÃO DE EQUIPE MULTIDISCIPLINAR (CE)'),(102,'0701','RELATORIOS TÉCNICOS'),(103,'08','ASSISTÊNCIA À PROJETOS COMPLEMENTARES (AP)'),(104,'0801','VISITAS TÉCNICAS PRÉ-DEFINIDAS'),(105,'080101','ORÇAMENTO,VISITAS TÉCNICAS E CONTRATAÇÃO DE PROFISSIONAIS OU EMPRESA'),(106,'080201','INDICAÇÃO DE ITENS EXECUTADOS'),(107,'080202','REVISÃO E AJUSTES'),(108,'080203','APROVAÇÃO E COMPATIBILIZAÇÃO'),(109,'09','ASSITÊNCIA À EXECUÇÃO DA OBRA (AE)'),(110,'0901','VISITAS TÉCNICAS PRÉ-DEFINIDAS'),(111,'0902','RELATORIOS DE ACOMPANHAMENTO DA EXECUÇÃO DAS DIFERENTES ETAPAS DA OBRA'),(112,'10','\"AS BUILT (AB)\"'),(113,'1001','PLANTA GERAL DE IMPLANTAÇÃO'),(114,'1002','PLANTA DE TERRAPLANAGEM'),(115,'1003','CORTES (LONGITUDINAIS E TRANSVERSAIS)'),(116,'1004','PLANTA BAIXA DOS PAVIMENTOS'),(117,'1005','PLANTA DA COBERTURA'),(118,'1006','ELEVAÇÕES'),(119,'1007','MEMORIAL DESCRITIVO'),(120,'100701','DA EDIFICAÇÃO'),(121,'100702','INSTALAÇÕES PREDIAIS'),(122,'100703','COMPONENTES CONSTRUTIVOS'),(123,'100704','MATERIAIS DE CONSTRUÇÃO');
/*!40000 ALTER TABLE `tb_etapas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_precos`
--

DROP TABLE IF EXISTS `tb_precos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_precos` (
  `pe_id` int(11) NOT NULL AUTO_INCREMENT,
  `pe_meses` int(11) DEFAULT NULL,
  `pe_preco` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`pe_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_precos`
--

LOCK TABLES `tb_precos` WRITE;
/*!40000 ALTER TABLE `tb_precos` DISABLE KEYS */;
INSERT INTO `tb_precos` VALUES (1,6,100.00),(2,12,190.00),(3,18,180.00);
/*!40000 ALTER TABLE `tb_precos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_profissional`
--

DROP TABLE IF EXISTS `tb_profissional`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_profissional` (
  `pr_id` int(11) NOT NULL AUTO_INCREMENT,
  `pr_descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`pr_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_profissional`
--

LOCK TABLES `tb_profissional` WRITE;
/*!40000 ALTER TABLE `tb_profissional` DISABLE KEYS */;
INSERT INTO `tb_profissional` VALUES (1,'ARQUITETO I'),(2,'ARQUITETO II'),(3,'ARQUITETO III'),(4,'ESTAGIARIO I'),(5,'PROPRIETARIO');
/*!40000 ALTER TABLE `tb_profissional` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_projeto_custo`
--

DROP TABLE IF EXISTS `tb_projeto_custo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_projeto_custo` (
  `pc_id` int(11) NOT NULL AUTO_INCREMENT,
  `pc_projeto` int(11) DEFAULT NULL,
  `pc_custo` int(11) DEFAULT NULL,
  `pc_valor_previsto` decimal(15,2) DEFAULT NULL,
  PRIMARY KEY (`pc_id`),
  KEY `fk_projeto_custo_idx` (`pc_custo`),
  KEY `fk_projeto_idx` (`pc_projeto`),
  CONSTRAINT `fk_projeto_custo` FOREIGN KEY (`pc_custo`) REFERENCES `tb_custos` (`cu_id`),
  CONSTRAINT `fk_projeto_custo_projeto` FOREIGN KEY (`pc_projeto`) REFERENCES `tb_projetos` (`pr_id`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_projeto_custo`
--

LOCK TABLES `tb_projeto_custo` WRITE;
/*!40000 ALTER TABLE `tb_projeto_custo` DISABLE KEYS */;
INSERT INTO `tb_projeto_custo` VALUES (6,1,6,150.00),(7,1,3,114.15),(8,1,2,200.00),(15,4,6,150.00),(16,4,3,114.15),(17,4,2,0.00),(18,4,17,500.00),(19,4,13,250.00),(20,4,12,250.00),(21,4,11,100.00),(22,4,10,50.00),(23,4,18,1200.00),(24,5,6,150.00),(25,5,3,114.15),(26,5,2,0.00),(27,5,17,500.00),(28,5,13,250.00),(29,5,12,250.00),(30,5,11,100.00),(31,5,10,50.00),(32,5,18,1200.00);
/*!40000 ALTER TABLE `tb_projeto_custo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_projeto_etapas`
--

DROP TABLE IF EXISTS `tb_projeto_etapas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_projeto_etapas` (
  `pe_id` int(11) NOT NULL AUTO_INCREMENT,
  `pe_projeto` int(11) DEFAULT NULL,
  `pe_etapa` int(11) DEFAULT NULL,
  `pe_hora_previsto` decimal(10,2) DEFAULT NULL,
  `pe_realisado` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`pe_id`),
  KEY `fk_projeto_etapa_idx` (`pe_etapa`),
  KEY `fk_projeto_etapa_projeto_idx` (`pe_projeto`),
  CONSTRAINT `fk_projeto_etapa` FOREIGN KEY (`pe_etapa`) REFERENCES `tb_etapas` (`et_id`),
  CONSTRAINT `fk_projeto_etapa_projeto` FOREIGN KEY (`pe_projeto`) REFERENCES `tb_projetos` (`pr_id`)
) ENGINE=InnoDB AUTO_INCREMENT=164 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_projeto_etapas`
--

LOCK TABLES `tb_projeto_etapas` WRITE;
/*!40000 ALTER TABLE `tb_projeto_etapas` DISABLE KEYS */;
INSERT INTO `tb_projeto_etapas` VALUES (1,1,1,1.50,NULL),(2,1,2,252.00,NULL),(3,1,3,23.97,NULL),(4,1,4,22.17,NULL),(34,1,6,219.67,NULL),(36,4,1,1.50,0.00),(37,4,2,252.00,0.00),(38,4,3,23.97,0.00),(39,4,4,22.17,0.00),(69,4,6,219.67,0.00),(159,5,1,1.50,0.00),(160,5,2,252.00,0.00),(161,5,3,23.97,0.00),(162,5,4,22.17,0.00),(163,5,6,219.67,0.00);
/*!40000 ALTER TABLE `tb_projeto_etapas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_projeto_observacao`
--

DROP TABLE IF EXISTS `tb_projeto_observacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_projeto_observacao` (
  `pb_id` int(11) NOT NULL AUTO_INCREMENT,
  `pb_projeto` int(11) DEFAULT NULL,
  `pb_observacao` longtext,
  PRIMARY KEY (`pb_id`),
  KEY `fk_projeto_observacao_projeto_idx` (`pb_projeto`),
  CONSTRAINT `fk_projeto_observacao_projeto` FOREIGN KEY (`pb_projeto`) REFERENCES `tb_projetos` (`pr_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_projeto_observacao`
--

LOCK TABLES `tb_projeto_observacao` WRITE;
/*!40000 ALTER TABLE `tb_projeto_observacao` DISABLE KEYS */;
INSERT INTO `tb_projeto_observacao` VALUES (1,4,'Teste I\r\nTeste II\r\nTeste III\r\nfinal');
/*!40000 ALTER TABLE `tb_projeto_observacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_projeto_profissional`
--

DROP TABLE IF EXISTS `tb_projeto_profissional`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_projeto_profissional` (
  `pp_id` int(11) NOT NULL AUTO_INCREMENT,
  `pp_projeto` int(11) DEFAULT NULL,
  `pp_profissional` int(11) DEFAULT NULL,
  `pp_hora_trabalhada` decimal(15,2) DEFAULT NULL,
  `pp_quantidade` int(11) DEFAULT NULL,
  PRIMARY KEY (`pp_id`),
  KEY `fk_projeto_profissional_idx` (`pp_profissional`),
  KEY `fk_projeto_profissional_projeto_idx` (`pp_projeto`),
  CONSTRAINT `fk_projeto_profissional` FOREIGN KEY (`pp_profissional`) REFERENCES `tb_despesas` (`da_id`),
  CONSTRAINT `fk_projeto_profissional_projeto` FOREIGN KEY (`pp_projeto`) REFERENCES `tb_projetos` (`pr_id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_projeto_profissional`
--

LOCK TABLES `tb_projeto_profissional` WRITE;
/*!40000 ALTER TABLE `tb_projeto_profissional` DISABLE KEYS */;
INSERT INTO `tb_projeto_profissional` VALUES (14,1,8,15000.00,1),(15,1,36,1200.00,1),(16,1,38,3000.00,1),(26,4,8,15000.00,1),(28,4,38,3000.00,1),(29,4,45,1412.00,1),(38,4,36,1200.00,1),(39,5,8,15000.00,1),(40,5,38,3000.00,1),(41,5,45,1412.00,1),(42,5,36,1200.00,1),(43,1,2,25000.00,1);
/*!40000 ALTER TABLE `tb_projeto_profissional` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_projetos`
--

DROP TABLE IF EXISTS `tb_projetos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_projetos` (
  `pr_id` int(11) NOT NULL AUTO_INCREMENT,
  `pr_cliente` int(11) DEFAULT NULL,
  `pr_tipologia` int(11) DEFAULT NULL,
  `pr_metragem` int(11) DEFAULT NULL,
  `pr_endereco` varchar(45) DEFAULT NULL,
  `pr_conteudo` varchar(45) DEFAULT NULL,
  `pr_proprietario` varchar(45) DEFAULT NULL,
  `pr_data` date DEFAULT NULL,
  `pr_responsavel` varchar(45) DEFAULT NULL,
  `pr_margem_lucro` decimal(10,2) DEFAULT NULL,
  `pr_margem_dificuldade` decimal(10,2) DEFAULT NULL,
  `pr_margem_criativo` decimal(10,2) DEFAULT NULL,
  `pr_impostos` decimal(10,2) DEFAULT NULL,
  `pr_desconto` decimal(10,2) DEFAULT NULL,
  `pr_nome` varchar(80) DEFAULT NULL,
  `pr_data_cadastro` datetime DEFAULT NULL,
  `pr_margem_lucro_real` decimal(10,2) DEFAULT NULL,
  `pr_margem_dificuldade_real` decimal(10,2) DEFAULT NULL,
  `pr_margem_criativo_real` decimal(10,2) DEFAULT NULL,
  `pr_impostos_real` decimal(10,2) DEFAULT NULL,
  `pr_desconto_real` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`pr_id`),
  KEY `fk_projeto_cliente_idx` (`pr_cliente`),
  KEY `fk_projeto_tipologia_idx` (`pr_tipologia`),
  CONSTRAINT `fk_projeto_tipologia` FOREIGN KEY (`pr_tipologia`) REFERENCES `tb_tipologia` (`ti_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_projetos`
--

LOCK TABLES `tb_projetos` WRITE;
/*!40000 ALTER TABLE `tb_projetos` DISABLE KEYS */;
INSERT INTO `tb_projetos` VALUES (1,1,4,600,'COND VEREDAS - NOVA LIMA','LD, EP, EV, PL, PE, CP, AB','LUCAS E ANALIA','2024-05-18','IVAN MARTINS',0.30,0.10,0.20,0.06,0.01,'CASA AMR','0000-00-00 00:00:00',NULL,NULL,NULL,NULL,NULL),(4,1,20,1000,'PLANTA DE BERNEFICIAMENTO EM SABARÁ','ARQUITETURA, LAY-OUT, ÁREA EXTERNA','GLOBAL MINERAÇÃO','2021-06-18','IVAN MARTINS',0.10,0.15,0.12,0.12,0.15,'PROJET JULIANA & IVAN','2024-05-17 12:53:32',NULL,NULL,NULL,NULL,NULL),(5,1,20,1000,'PLANTA DE BERNEFICIAMENTO EM SABARÁ','ARQUITETURA, LAY-OUT, ÁREA EXTERNA','GLOBAL MINERAÇÃO','2021-06-18','IVAN MARTINS',0.10,0.15,0.12,0.12,0.15,'PROJET JULIANA & IVAN','2024-05-21 14:19:28',NULL,NULL,NULL,NULL,NULL),(6,1,4,800,'JDIJKZSDKLJBJS','ASDDAS','AMR','2024-05-21','EU',0.19,0.09,0.10,0.12,0.30,'IVAN','2024-05-21 14:36:39',NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `tb_projetos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tb_tipologia`
--

DROP TABLE IF EXISTS `tb_tipologia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tb_tipologia` (
  `ti_id` int(11) NOT NULL AUTO_INCREMENT,
  `ti_descricao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ti_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tb_tipologia`
--

LOCK TABLES `tb_tipologia` WRITE;
/*!40000 ALTER TABLE `tb_tipologia` DISABLE KEYS */;
INSERT INTO `tb_tipologia` VALUES (2,'COMERCIAL'),(3,'RESIDENCIAL'),(4,'RESIDENCIAL UNIFAMILIAR'),(5,'RESIDENCIAL MULTI-FAMILIAR'),(6,'USO MISTO'),(7,'INDUSTRIAL'),(8,'INSTITUCIONAL'),(10,'CORPORATIVO'),(11,'INFRA ESTRUTURA'),(12,'URBANISMO'),(13,'DESIGN DE INTERIORES'),(14,'LUMINOTECNICO'),(15,'ACUSTICA'),(16,'INSTALAÇÃO ELETRICA'),(17,'CALCULO ESTRUTURAL'),(18,'FUNDAÇÕES'),(19,'INSTALAÇÕES HIDRO SANITARIAS'),(20,'ARQUITETURA');
/*!40000 ALTER TABLE `tb_tipologia` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-28 18:41:24
