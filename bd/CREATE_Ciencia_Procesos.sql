CREATE TABLE Ciencia_Procesos
(
	ProcId int NOT NULL PRIMARY KEY,
	ModuloId int FOREIGN KEY REFERENCES Ciencia_Modulo(ModuloId),
	Proc_ini_F datetime,
	Proc_fin_F datetime,
	Proc_Maq_T varchar(100)
);

