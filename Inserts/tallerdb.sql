-- Inserts Taller--
USE tallerdb;

INSERT INTO Brands
	(Code,Name,Description)

VALUES ('mercedesbenz','MercedesBenz','Mercedes-Benz es una empresa alemana fabricante de vehículos');
VALUES ('chevy','Chevrolet','Chevrolet es una marca de automóviles y camiones con sede en Detroit');
VALUES ('toyota','Toyota','Toyota Motor Corporation ​es una empresa japonesa de fabricación de automóviles. Fundada en 1933 por Kiichiro Toyoda');
VALUES ('volkswagen','Volkswagen','Volkswagen es un fabricante de automóviles con sede en Wolfsburgo, Baja Sajonia, Alemania');
VALUES ('hyundai','Hyundai','Hyundai Motor Company es el mayor fabricante surcoreano de automóviles');

INSERT INTO Enterprises
	(Id,QuantityAttending,RateProductivity,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,0.5,GETDATE(),GETDATE(),True);
VALUES (2,1,0.6,GETDATE(),GETDATE(),True);
VALUES (3,2,0.1,GETDATE(),GETDATE(),True);
VALUES (4,3,0.2,GETDATE(),GETDATE(),True);
VALUES (5,1,0.7,GETDATE(),GETDATE(),True);

INSERT INTO BrandsEnterprise
	(BrandsCode,EnterprisesId)

VALUES (toyota,1);
VALUES (mercedesbenz,2);
VALUES (volkswagen,3);
VALUES (chevy,4);
VALUES (hyundai,5);

INSERT INTO Users
	(Id,LdapID,FirstName,LastName,Email,EnterpriseId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,'William','Jimenez','Wiwi@gmail.com',1,GETDATE(),GETDATE(),True);
VALUES (2,2,'Ursula','Tapia','UrTa@gmail.com',2,GETDATE(),GETDATE(),True);
VALUES (3,3,'Pablo','Salazar','PaSala@gmail.com',3,GETDATE(),GETDATE(),True);
VALUES (4,4,'Estefano','Torres','ETorre@gmail.com',4,GETDATE(),GETDATE(),True);
VALUES (5,5,'Edward','Holmes','Edes@gmail.com',5,GETDATE(),GETDATE(),True);

INSERT INTO Quotations
	(Id,QuantityToRepair,Total,NumberOfDays,StartDate,EndDate,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,200,2,'2022-06-28','2022-06-30',GETDATE(),GETDATE(),True);
VALUES (2,1,150,4,'2022-06-29','2022-07-03',GETDATE(),GETDATE(),True);
VALUES (3,2,50,3,'2022-06-28','2022-07-01',GETDATE(),GETDATE(),True);
VALUES (4,1,34,3,'2022-06-29','2022-07-02',GETDATE(),GETDATE(),True);
VALUES (5,1,80,5,'2022-06-29','2022-07-04',GETDATE(),GETDATE(),True);
VALUES (6,1,100,2,'2022-06-28','2022-07-30',GETDATE(),GETDATE(),True);
VALUES (7,1,110,3,'2022-06-29','2022-07-02',GETDATE(),GETDATE(),True);

INSERT INTO RepairRequests
	(Id,Status,VehicleId,PolicyId,IncidentId,QuotationId)

VALUES (1,1,1,1,3);
VALUES (2,1,2,2,1);
VALUES (3,1,3,3,2);
VALUES (4,1,4,4,5);
VALUES (5,0,5,5,4);

INSERT INTO Parts
	(Id,Name,Status,Quantity,RepairRequestId)

VALUES (1,'Faro Der',0,1,1);
VALUES (2,'Retrovisor Der',0,1,1);
VALUES (3,'Frenos',0,2,2);
VALUES (4,'Puerta izq',0,1,3);
VALUES (5,'Carroceria parte izq',0,1,3);
VALUES (6,'Faro trasero derecho',0,1,4);
VALUES (7,'Cristal delantero',0,1,5);