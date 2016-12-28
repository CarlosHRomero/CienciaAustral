SELECT COLUMN_NAME,  CienciaEquiv.CampoEquivalente
FROM INFORMATION_SCHEMA.COLUMNS 
left join CienciaEquiv on COLUMN_NAME = CienciaEquiv.CampoEquivalente
WHERE TABLE_NAME = 'elf_pac'