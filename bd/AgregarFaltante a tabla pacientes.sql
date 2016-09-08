

insert into Hemo_Pac(Pac_Id, Pac_Sel, Pac_cErr)  select distinct proc_pac_id, 0,0  from Hemo_Proc1 
Where not exists ( select * from  Hemo_Pac where Hemo_Pac.Pac_id = Hemo_Proc1.Proc_Pac_Id)

insert into Hemo_Pac(Pac_Id, Pac_Sel, Pac_cErr)  select distinct clin_pac_id, 0,0  from Hemo_clin1 
Where not exists ( select * from  Hemo_Pac where Hemo_Pac.Pac_id = Hemo_clin1.clin_pac_id)

insert into Hemo_Pac(Pac_Id, Pac_Sel, Pac_cErr)  select distinct Comp_Pac_Id, 0,0  from Hemo_Comp
Where not exists (select * from  Hemo_Pac where Hemo_Pac.Pac_Id = Hemo_Comp.Comp_Pac_Id)

 insert into Hemo_Proc1(Proc_Id, Proc_Pac_Id, Proc_cErr, Proc_Fin_B) select distinct Clin_Proc_Id, clin_pac_id,0,0 from Hemo_Clin1
Where not exists (select * from  Hemo_Proc1 where Hemo_Proc1.Proc_Id = Hemo_clin1.Clin_Proc_Id)

insert into Hemo_Proc1(Proc_Id, Proc_Pac_Id, Proc_cErr, Proc_Fin_B) select distinct Comp_Proc_Id, Comp_Pac_Id,0,0 from Hemo_Comp
Where not exists (select * from  Hemo_Proc1 where Hemo_Proc1.Proc_Id = Hemo_Comp.Comp_Proc_Id)


