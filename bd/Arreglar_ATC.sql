
update Ciencia_Hemo_Mul
set atc_marca4_d = marcaDesc
from
(
select  [ICBA Cirugia 2003].cirugia.Hemo_ATC1.ATC_Id, TipoAtc.tipoDesc, marca.marcaDesc  from [ICBA Cirugia 2003].cirugia.Hemo_ATC1
LEFT join 
(SELECT  [ICBA Cirugia 2003].cirugia.Hemo_Equiv.Eqv_Val, [ICBA Cirugia 2003].cirugia.Hemo_Equiv.Eqv_Desc as tipoDesc, Eqv_Continua as Continua
FROM [ICBA Cirugia 2003].cirugia.Hemo_Equiv 
WHERE ([ICBA Cirugia 2003].cirugia.Hemo_Equiv.Eqv_Tit = 'fD') OR ([ICBA Cirugia 2003].cirugia.Hemo_Equiv.Eqv_Tit = 'St_Tipo')) as TipoAtc
on TipoAtc.Eqv_Val = Hemo_ATC1.atc_st_tipo4_d
LEFT join
(SELECT [Eqv_Val] , Eqv_Desc as marcaDesc,Eqv_Tit   FROM [ICBA Cirugia 2003].[cirugia].[HemoMarcaF]) as marca
on (marca.Eqv_Tit = TipoAtc.Continua or Eqv_Tit = 'fD') and  marca.[Eqv_Val] = Hemo_ATC1.atc_marca4_d
) as subquery
where Ciencia_Hemo_Mul.ATC_Id = subquery.ATC_Id









