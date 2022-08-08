-- Inserts administrador--
USE adminsitradordb;

INSERT INTO BrandsEnterprise
	(BrandsCode,EnterprisesId)

VALUES (toyota,1);
VALUES (mercedesbenz,2);
VALUES (volkswagen,3);
VALUES (chevy,4);
VALUES (hyundai,5);

INSERT INTO Brands
	(Code,Name,Description)

VALUES ('mercedesbenz','MercedesBenz','Mercedes-Benz es una empresa alemana fabricante de vehículos');
VALUES ('chevy','Chevrolet','Chevrolet es una marca de automóviles y camiones con sede en Detroit');
VALUES ('toyota','Toyota','Toyota Motor Corporation ​es una empresa japonesa de fabricación de automóviles. Fundada en 1933 por Kiichiro Toyoda');
VALUES ('volkswagen','Volkswagen','Volkswagen es un fabricante de automóviles con sede en Wolfsburgo, Baja Sajonia, Alemania');
VALUES ('hyundai','Hyundai','Hyundai Motor Company es el mayor fabricante surcoreano de automóviles');

INSERT INTO Enterprises
	(Id,Rif,Name,Email,Phone,Address,EnterpriseType,ParishId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,'655824569','FastFix','FFix@gmail.com',04124884567,0,15,GETDATE(),GETDATE(),True);
VALUES (2,'954124569','SupCar','SupC@gmail.com',04244884789,1,24,GETDATE(),GETDATE(),True);
VALUES (3,'1045685211','GoldMechs','Gme@gmail.com',04264884268,0,24,GETDATE(),GETDATE(),True);
VALUES (4,'115648240','BestParts','BpM@gmail.com',04126695478,1,15,GETDATE(),GETDATE(),True);
VALUES (5,'93571547','Allparts','Allp@gmail.com',04246352887,1,24,GETDATE(),GETDATE(),True);

INSERT INTO Incidents
	(Id,Date,Description,Status,Address,ParishId,PolicyId,ThirdPolicyId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,GETDATE(),'Choque en parte trasera',0,'Altamira',24,1,null,GETDATE(),GETDATE(),True);
VALUES (2,GETDATE(),'Vidrio delantero destruido',0,'Lidice',15,3,null,GETDATE(),GETDATE(),True);
VALUES (3,GETDATE(),'Carroceria del parachoque',0,'Montalban',15,4,null,GETDATE(),GETDATE(),True);
VALUES (4,GETDATE(),'Retrovisores afectados',0,'Palos Grande',24,6,2,GETDATE(),GETDATE(),True);
VALUES (5,GETDATE(),'Faros de luces perjudicado',0,'El Paraiso',15,7,5,GETDATE(),GETDATE(),True);

INSERT INTO Insureds
	(Id,InsuredTypeIdentification,Identification,FirstName,LastName,Email,Phone,Birthday,CreatedAt,UpdatedAt,IsActive)

VALUES (1,0,'18303554','Pedro','Camacaro','Pecama@gmail.com','04128545965','1985-04-30',GETDATE(),GETDATE(),True);
VALUES (2,0,'14268554','Alicia','Leoni','ALeo@gmail.com','04248548945','1980-12-10',GETDATE(),GETDATE(),True);
VALUES (3,0,'20458326','Walter','Pietro','Wawa@gmail.com','04261758236','1990-01-14',GETDATE(),GETDATE(),True);
VALUES (4,1,'10456321','Jose','Gomes','Jogo@gmail.com','04142364545','1970-08-26',GETDATE(),GETDATE(),True);
VALUES (5,0,'21002458','Ricardo','Garcia','Rikia@gmail.com','04125551213','1994-06-17',GETDATE(),GETDATE(),True);

INSERT INTO States
	(Id,Name)

VALUES (1,'Amazonas');
VALUES (2,'Anzoategui');
VALUES (3,'Apure');
VALUES (4,'Aragua');
VALUES (5,'Barinas');
VALUES (6,'	Bolivar');
VALUES (7,'Carabobo');
VALUES (8,'Cojedes');
VALUES (9,'Distrito Capital');
VALUES (10,'Delta Amacuro');
VALUES (11,'Falcon');
VALUES (12,'Guarico');
VALUES (13,'Lara');
VALUES (14,'Merida');
VALUES (15,'Miranda');
VALUES (16,'Monagas');
VALUES (17,'Nueva Esparta');
VALUES (18,'Portuguesa');
VALUES (19,'Sucre');
VALUES (20,'Tachira');
VALUES (21,'Trujillo');
VALUES (22,'Vargas');
VALUES (23,'Yaracuy');
VALUES (24,'Zulia');

INSERT INTO Municipalities
	(Id,Name,StateId)

VALUES (1,'Maroa',1);
VALUES (2,'Bruzual',2);
VALUES (3,'Achaguas',3);
VALUES (4,'Tovar',4);
VALUES (5,'Torrealba',5);
VALUES (6,'Angostura',6);
VALUES (7,'Guacara',7);
VALUES (8,'Tinaco',8);
VALUES (9,'Libertador',9);
VALUES (10,'Tucupita',10);
VALUES (11,'Punto Fijo',11);
VALUES (12,'Calabozo',12);
VALUES (13,'Palavecino',13);
VALUES (14,'Rivas Davila',14);
VALUES (15,'Chacao',15);
VALUES (16,'Uracao',16);
VALUES (17,'Tubores',17);
VALUES (18,'Araure',18);
VALUES (19,'Bermudez',19);
VALUES (20,'San Cristobal',20);
VALUES (21,'Araure',21);
VALUES (22,'La Guaira',22);
VALUES (23,'Nirgua',23);
VALUES (24,'Catatumbo',24);

INSERT INTO Parishes
	(Id,Name,MunicipalityId)

VALUES (1,'Maroa',1);
VALUES (2,'Victorino',1);
VALUES (3,'Clarines',2);
VALUES (4,'Guarape',2);
VALUES (5,'Achaguas',3);
VALUES (6,'Apurito',3);
VALUES (7,'Colonia Tovar',4);
VALUES (8,'Sabaneta',5);
VALUES (9,'Veguitas',5);
VALUES (10,'Barceloneta',6);
VALUES (11,'Santa Barbara',6);
VALUES (12,'Guacara',7);
VALUES (13,'Yagua',7);
VALUES (14,'Laurencio',8);
VALUES (15,'La Pastora',9);
VALUES (15,'La Vega',9);
VALUES (16,'San Jose',10);
VALUES (17,'San Rafael',10);
VALUES (18,'Carirubana',11);
VALUES (19,'Santa Ana',11);
VALUES (20,'Guardatinajas',12);
VALUES (21,'El Rastro',12);
VALUES (22,'Cabudare',13);
VALUES (23,'Bailadores',14);
VALUES (24,'Chacao',15);
VALUES (25,'Uracao',16);
VALUES (26,'Tubores',17);
VALUES (27,'Araure',18);
VALUES (28,'Macarapana',19);
VALUES (29,'Santa Catalina',19);
VALUES (30,'San Sebastian',20);
VALUES (31,'La Concordia',20);
VALUES (32,'Araure',21);
VALUES (33,'Rio Acarigua',21);
VALUES (34,'Macuto',22);
VALUES (35,'Caruao',22);
VALUES (36,'Nirgua',23);
VALUES (37,'Salom',23);
VALUES (38,'Encontrados',24);
VALUES (39,'Udon Perez',24);

INSERT INTO PartQuotations
	(Id,Quantity,Original,UnitPrice,discount_percentage,Status,DeliveryTime,PartId,EnterpriseId)

VALUES (1,1,True,100,10,0,48,1,1);
VALUES (2,1,True,150,20,0,26,1,2);
VALUES (3,2,True,80,0,0,30,2,2);
VALUES (4,1,True,200,3,0,48,3,4);
VALUES (5,1,True,50,0,0,36,3,5);
VALUES (6,1,False,60,5,0,48,4,1);
VALUES (7,1,True,120,0,0,20,5,3);

INSERT INTO Parts
	(Id,Name,Status,Quantity,RepairRequestId)

VALUES (1,'Faro Der',0,1,1);
VALUES (2,'Retrovisor Der',0,1,1);
VALUES (3,'Frenos',0,2,2);
VALUES (4,'Puerta izq',0,1,3);
VALUES (5,'Carroceria parte izq',0,1,3);
VALUES (6,'Faro trasero derecho',0,1,4);
VALUES (7,'Cristal delantero',0,1,5);

INSERT INTO Policies
	(Id,PolicyType,StartDate,EndDate,VehicleId,InsuredId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,'CompleteCover','2022-06-29','2023-06-30',1,4,GETDATE(),GETDATE(),True);
VALUES (2,'ThirdSupporter','2022-06-30','2023-06-30',4,3,GETDATE(),GETDATE(),True);
VALUES (3,'CompleteCover','2022-07-29','2023-07-30',3,2,GETDATE(),GETDATE(),True);
VALUES (4,'CompleteCover','2022-08-29','2023-08-30',2,5,GETDATE(),GETDATE(),True);
VALUES (5,'ThirdSupporter','2022-09-29','2023-09-30',5,1,GETDATE(),GETDATE(),True);
VALUES (6,'CompleteCover','2022-08-28','2023-08-28',6,6,GETDATE(),GETDATE(),True);
VALUES (7,'CompleteCover','2022-08-29','2023-08-29',7,7,GETDATE(),GETDATE(),True);

INSERT INTO RepairRequests
	(Id,QuotationId,Status,VehicleId,IncidentId,EnterpriseId)

VALUES (1,3,0,1,3,2);
VALUES (2,1,0,2,1,5);
VALUES (3,2,0,3,2,4);
VALUES (4,5,0,4,5,1);
VALUES (5,4,0,5,4,3);

INSERT INTO Users
	(Id,LdapID,FirstName,LastName,Email,Password,Role,IdentificationType,Identification,Phone,EnterpriseId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,'Miriam','Garcia','Miga@gmail.com',1234,1,7304154,04124534567,1,GETDATE(),GETDATE(),True);
VALUES (2,2,'Marcelo','Soteldo','MarcSo@gmail.com',1234,2,6543764,04266784578,2,GETDATE(),GETDATE(),True);
VALUES (3,3,'Santiago','Diaz','Santd@gmail.com',1234,3,15235748,04246752244,3,GETDATE(),GETDATE(),True);
VALUES (4,4,'Pedro','Leon','PeLe@gmail.com',1234,4,11543897,04140030079,4,GETDATE(),GETDATE(),True);
VALUES (5,5,'Andrea','Pirlo','Anpir@gmail.com',1234,4,9764678,04140905543,5,GETDATE(),GETDATE(),True);

INSERT INTO Vehicles
	(Id,Plate,Year,SerialMotorNumber,SerialChasisNumber,Color,BodyworkType,InsuredId,BrandCode,CreatedAt,UpdatedAt,IsActive)

VALUES (1,'SDFEER3','2008','52WVC10335','1HGBH41JXMN109186','negro',3,1,'toyota',GETDATE(),GETDATE(),True);
VALUES (2,'ASD4LKJ','2020','11DLS12202','WLQBH41SFFN102CV6','blanco',0,2,'chevy',GETDATE(),GETDATE(),True);
VALUES (3,'KIRB321','2012','25CFG10223','1RGBH41GLDD101233','plata',4,3,'hyundai',GETDATE(),GETDATE(),True);
VALUES (4,'ASATL57','2014','6GL4FDDF42','FLF4241JECLH4L186','rojo',3,4,'chevy',GETDATE(),GETDATE(),True);
VALUES (5,'FLS21EE','2006','V2WV22C335','DL2DH41CLPW12PDD1','amarillo',3,5,'volkswagen',GETDATE(),GETDATE(),True);
VALUES (6,'DL321EE','2017','DM3L22DL25','DPY2S31CLPW10SL1S','verde',3,6,'toyota',GETDATE(),GETDATE(),True);
VALUES (7,'FKL3A2E','2009','FL3PSS2CM2','KKF2SO2ASWXMM21LS','blanco',3,7,'chevy',GETDATE(),GETDATE(),True);












