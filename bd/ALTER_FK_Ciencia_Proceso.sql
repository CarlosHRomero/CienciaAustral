ALTER TABLE Ciencia_Procesos
ADD Proc_Usr_Id INTEGER,
FOREIGN KEY(Proc_Usr_Id, ModuloId) REFERENCES Usuario([User_Id], Modulo_Id);