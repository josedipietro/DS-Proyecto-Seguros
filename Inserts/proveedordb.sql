-- Inserts Proveedor--
USE proveedordb;

INSERT INTO Enterprises
	(Id,CreatedAt,UpdatedAt,IsActive)

VALUES (1,GETDATE(),GETDATE(),True);
VALUES (2,GETDATE(),GETDATE(),True);
VALUES (3,GETDATE(),GETDATE(),True);
VALUES (4,GETDATE(),GETDATE(),True);
VALUES (5,GETDATE(),GETDATE(),True);

INSERT INTO Users
	(Id,LdapID,FirstName,LastName,Email,EnterpriseId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,'Alberto','Balboa','Alba@gmail.com',1,GETDATE(),GETDATE(),True);
VALUES (2,2,'Mariam','Prieti','MariPri@gmail.com',2,GETDATE(),GETDATE(),True);
VALUES (3,3,'Laura','Hernandez','LauH@gmail.com',3,GETDATE(),GETDATE(),True);
VALUES (4,4,'Norman','Wallas','Nowa@gmail.com',4,GETDATE(),GETDATE(),True);
VALUES (5,5,'Ash','Ketchup','Ash@gmail.com',5,GETDATE(),GETDATE(),True);

INSERT INTO RepairRequests
	(Id)

VALUES (1);
VALUES (2);
VALUES (3);
VALUES (4);
VALUES (5);

INSERT INTO Parts
	(Id,Name,RepairRequestId)

VALUES (1,'Faro Der',1);
VALUES (2,'Retrovisor Der',1);
VALUES (3,'Frenos',2);
VALUES (4,'Puerta izq',3);
VALUES (5,'Carroceria parte izq',3);
VALUES (6,'Faro trasero derecho',4);
VALUES (7,'Cristal delantero',5);

INSERT INTO PartQuotations
	(Id,Quantity,UnitPrice,Original,Status,DeliveryTime,discount_percentage,DeliveryStartDate,DeliveryEndDate,PartId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,100,True,1,48,10,'2022-06-28','2022-06-30',1,GETDATE(),GETDATE(),True);
VALUES (2,1,150,True,1,26,20,'2022-06-29','2022-07-03',1,GETDATE(),GETDATE(),True);
VALUES (3,2,80,True,1,30,5,'2022-06-28','2022-07-01',2,GETDATE(),GETDATE(),True);
VALUES (4,1,200,True,1,48,0,'2022-06-29','2022-07-02',3,GETDATE(),GETDATE(),True);
VALUES (5,1,50,True,1,36,4,'2022-06-29','2022-07-04',3,GETDATE(),GETDATE(),True);
VALUES (6,1,60,False,1,48,1,'2022-06-28','2022-07-30',4,GETDATE(),GETDATE(),True);
VALUES (7,1,120,True,1,20,2,'2022-06-29','2022-07-02',5,GETDATE(),GETDATE(),True);

INSERT INTO Participations
	(Id,RepairRequestId,EnterpriseId,Status,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,1,1,GETDATE(),GETDATE(),True);
VALUES (2,2,2,1,GETDATE(),GETDATE(),True);
VALUES (3,3,3,1,GETDATE(),GETDATE(),True);
VALUES (4,4,4,1,GETDATE(),GETDATE(),True);
VALUES (5,5,5,1,GETDATE(),GETDATE(),True);

INSERT INTO Brands
	(Code,Name,Description)

VALUES ('Mbenz','MercedesBenz','');
VALUES ('Chevy','Chevrolet','');
VALUES ('Tyt','Toyota','');
VALUES ('Volks','Volkswagen','');
VALUES ('Hyun','Hyundai','');

INSERT INTO BrandsEnterprise
	(BrandsCode,EnterprisesId)

VALUES (Tyt,1);
VALUES (Mbenz,2);
VALUES (Volks,3);
VALUES (Chevy,4);
VALUES (Hyun,5);
