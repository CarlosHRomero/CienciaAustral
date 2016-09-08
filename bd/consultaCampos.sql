insert Into [ICBA Cirugia 2003].cirugia.CienciaEquiv (TablaId, CampoOriginal, CampoEquivalente)
SELECT 
41, c.name, c.name
FROM 
sys.columns c
WHERE
c.object_id = OBJECT_ID('Frag_Comp')




select *
from
sys.columns
where
name = 'ingr_id'

select DATA_TYPE
from INFORMATION_SCHEMA.COLUMNS
where TABLE_NAME='Car_Ingr'
and COLUMN_NAME ='Ingr_id'

object_id = object_id('Car_Ingr')



-Ingreso tipo de datos sql server en los campos de tipo desplegable

update CienciaEquiv
set TipoDatoSqlServer = 'int'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 4 and ce.CampoOriginal like '%_Id' and cte.TablaId = 41


update CienciaEquiv
set TipoDatoSqlServer = 'nvarchar(100)'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 4 and ce.CampoOriginal like '%_D' and cte.TablaId = 41


--Ingreso tipo de datos sql server en los campos de tipo NoSi para elf

update CienciaEquiv
set TipoDatoSqlServer = 'nvarchar(4)'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 4 and ce.CampoOriginal like '%_B' and cte.TablaId = 41

--Ingreso tipo de datos sql server en los campos de tipo Fecha para elf

update CienciaEquiv
set TipoDatoSqlServer = 'datetime'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 4 and ce.CampoOriginal like '%_F' and cte.TablaId = 41

--Ingreso tipo de datos sql server en los campos de tipo Numero para elf

update CienciaEquiv
set TipoDatoSqlServer = 'int'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 4 and ce.CampoOriginal like '%_N' and cte.TablaId = 41

--Ingreso tipo de datos sql server en los campos de tipo Hora para elf

update CienciaEquiv
set TipoDatoSqlServer = 'datetime'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 4 and ce.CampoOriginal like '%_H' and cte.TablaId = 41

--Ingreso tipo de datos sql server en los campos de tipo TEXTO para elf

update CienciaEquiv
set TipoDatoSqlServer = 'nvarchar(100)'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 4 and ce.CampoOriginal like '%_T' and cte.TablaId = 41


--Ingreso tipo de datos sql server en los campos de tipo Observacion para elf

update CienciaEquiv
set TipoDatoSqlServer = 'nvarchar(150)'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_Obs' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoSqlServer = 'datetime'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 1 and ce.CampoOriginal like '%_Fj'


--Borrar datos administrativos para elf

delete ce from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_cErr' and cte.TablaId = 33


delete ce from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_ABM' and cte.TablaId = 33


delete ce from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_Maq' and cte.TablaId = 33


-- Agregar corchetes a las columnas CampoOriginal con barra media 

update CienciaEquiv
set CampoOriginal = '['+ce.CampoOriginal +']'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 1 and ce.CampoOriginal like '%-%'

-- Agregar corchetes a las columnas CampoEquivalente con barra media 

update CienciaEquiv
set CampoEquivalente = '['+ce.CampoEquivalente +']' 
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 1 and ce.CampoOriginal like '%-%' and cte.TablaId = 27


update CienciaEquiv
set CampoEquivalente = REPLACE(ce.CampoEquivalente,'[','')
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 1 and ce.CampoOriginal like '%-%' and cte.TablaId = 13


update CienciaEquiv
set CampoEquivalente = REPLACE(ce.CampoEquivalente,']','')
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 1 and ce.CampoOriginal like '%-%' and cte.TablaId = 13


update CienciaEquiv
set CampoEquivalente = REPLACE(ce.CampoEquivalente,'-','_')
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 1 and ce.CampoOriginal like '%-%' and cte.TablaId = 13






update CienciaEquiv
set TipoDeDato = 'NoSi'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoEquivalente like '%_D' and cte.TablaId = 40




update CienciaEquiv
set  TipoDatoAccess = 'Text'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoEquivalente like '%_D' and cte.TablaId = 40


update cienciaequiv
set TipoDeDato = 'Tabla'
where CampoEquivalente like '%_D' AND TablaId = 40


update cienciaequiv
set ValorPorDefecto = 'f/dato'
where TipoDeDato = 'Tabla' AND TablaId = 40


update cienciaequiv
set TipoDeDato = 'ID'
where CampoEquivalente like '%_Id' AND TablaId = 40


update cienciaequiv
set TipoDatoAccess = 'Long'
where TipoDeDato = 'ID' AND TablaId = 40



update CienciaEquiv
set TipoDatoAccess = 'Text'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_T' and cte.TablaId = 40



update CienciaEquiv
set TipoDeDato = 'Fecha'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_F' and cte.TablaId = 40



update CienciaEquiv
set TipoDeDato = 'Numero'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_N' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoSqlServer = 'int'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_N' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoAccess = 'Long'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_N' and cte.TablaId = 40



update CienciaEquiv
set TipoDeDato = 'Fecha'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and CE.TipoDatoSqlServer = 'datetime' and cte.TablaId = 40



update CienciaEquiv
set TipoDeDato = 'Fecha'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and CE.TipoDatoSqlServer = 'datetime' and cte.TablaId = 40


select FA_LocalizEsofago_D from dbo.Ciencia_Elf

--Cargar tipos de datos

update CienciaEquiv
set TipoDeDato = 'Fecha'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_F' and cte.TablaId = 40



update CienciaEquiv
set TipoDeDato = 'NoSi'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_B' and cte.TablaId = 40


update CienciaEquiv
set TipoDeDato = 'Tabla'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_D' and cte.TablaId = 40


update CienciaEquiv
set TipoDeDato = 'Numerico'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_N' and cte.TablaId = 40

update CienciaEquiv
set TipoDeDato = 'Texto'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_T' and cte.TablaId = 40


update CienciaEquiv
set TipoDeDato = 'ID'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.CampoOriginal like '%_Id' and cte.TablaId = 40


-- Cargar tipo de datos access 


update CienciaEquiv
set TipoDatoAccess = 'Char(100)'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'Tabla' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoAccess = 'char(4)'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'NoSi' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoAccess = 'DateTime'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'Fecha' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoAccess = 'Long'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'Numero' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoAccess = 'Long'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'ID' and cte.TablaId = 40


update CienciaEquiv
set TipoDatoAccess = 'Char(150)'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'Texto' and cte.TablaId = 40


-- Cargar valor por defecto


update CienciaEquiv
set ValorPorDefecto = 'No'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'NoSi' and cte.TablaId = 40


update CienciaEquiv
set ValorPorDefecto = 'f/dato'
from CienciaEquiv ce
join CienciaTablaEquiv cte on ce.TablaId = cte.TablaId
where cte.ModuloId = 3 and ce.TipoDeDato like 'Tabla' and cte.TablaId = 40
