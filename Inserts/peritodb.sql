-- Inserts Perito--
USE peritodb;

INSERT INTO Users
	(Id,LdapID,FirstName,LastName,Email,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,'Gabriel','Perez','Gp@gmail.com',GETDATE(),GETDATE(),True);
VALUES (2,2,'Daniel','Borgan','Dbor@gmail.com',GETDATE(),GETDATE(),True);
VALUES (3,3,'Alfonso','Carrizal','Aca@gmail.com',GETDATE(),GETDATE(),True);
VALUES (4,4,'Paulo','Dybala','Paulito@gmail.com',GETDATE(),GETDATE(),True);
VALUES (5,5,'Kira','Boa','Kibo@gmail.com',GETDATE(),GETDATE(),True);

INSERT INTO Incidents
	(Id,Status,IsGuilty,RevisionDescription,UserId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,True,'Tren delantero - Frenos',3,GETDATE(),GETDATE(),True);
VALUES (2,0,True,'Carroceria doblada puertas izq',1,GETDATE(),GETDATE(),True);
VALUES (3,1,False,'Faro y retrovisor derechos destruidos',2,GETDATE(),GETDATE(),True);
VALUES (4,0,True,'Rayones y cristal delantero roto',5,GETDATE(),GETDATE(),True);
VALUES (5,1,False,'Abolladura en la esquina derecha',4,GETDATE(),GETDATE(),True);

INSERT INTO RepairRequests
	(Id,VehicleId,PolicyId,Status,IncidentId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,1,1,1,3,GETDATE(),GETDATE(),True);
VALUES (2,2,2,0,1,GETDATE(),GETDATE(),True);
VALUES (3,3,3,0,2,GETDATE(),GETDATE(),True);
VALUES (4,4,4,1,5,GETDATE(),GETDATE(),True);
VALUES (5,5,5,1,4,GETDATE(),GETDATE(),True);

INSERT INTO Parts
	(Id,Name,Status,Quantity,RepairRequestId,CreatedAt,UpdatedAt,IsActive)

VALUES (1,'Faro Der',1,1,1,GETDATE(),GETDATE(),True);
VALUES (2,'Retrovisor Der',1,1,1,GETDATE(),GETDATE(),True);
VALUES (3,'Frenos',1,2,2,GETDATE(),GETDATE(),True);
VALUES (4,'Puerta izq',1,1,3,GETDATE(),GETDATE(),True);
VALUES (5,'Carroceria parte izq',1,1,3,GETDATE(),GETDATE(),True);
VALUES (6,'Faro trasero derecho',1,1,4,GETDATE(),GETDATE(),True);
VALUES (7,'Cristal delantero',1,1,5,GETDATE(),GETDATE(),True);
