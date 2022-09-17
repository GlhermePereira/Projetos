insert into tipo_usuario (cd_tipo_usuario, nm_tipo_usuario) values (1,'Responsavel');
insert into tipo_usuario (cd_tipo_usuario, nm_tipo_usuario) values (2,'Funcionario');

insert into tipo_nota (cd_tipo_nota,nm_tipo_nota) values (1,'Observação');
insert into tipo_nota (cd_tipo_nota,nm_tipo_nota) values (2,'Atividades de sala');
insert into tipo_nota (cd_tipo_nota,nm_tipo_nota) values (3,'Provas');
insert into tipo_nota (cd_tipo_nota,nm_tipo_nota) values (4,'Nota trimestral');
insert into tipo_nota (cd_tipo_nota,nm_tipo_nota) values (5,'Atividades para casa');

insert into tipo_recado (cd_tipo_recado,nm_tipo_recado) values(1,'Imagens e links');
insert into tipo_recado (cd_tipo_recado,nm_tipo_recado) values(2,'Pedido de permissão para saída de aluno');
insert into tipo_recado (cd_tipo_recado,nm_tipo_recado) values(3,'Registro de observação do professor');
insert into tipo_recado (cd_tipo_recado,nm_tipo_recado) values(4,'Envio de comunicados');
insert into tipo_recado (cd_tipo_recado,nm_tipo_recado) values(5,'Agendar reunião com funcionários');
insert into tipo_recado (cd_tipo_recado,nm_tipo_recado) values(6,'Envio de recados à escola');
insert into tipo_recado (cd_tipo_recado,nm_tipo_recado) values(7,'Resposta permissão de saída');

insert into usuario(cd_tipo_usuario,nm_usuario,nm_senha_usuario,
cd_telefone_usuario,nm_email_usuario) values(1,'Marcelo Farias','123','5513988070934','marcelo.farias@gmail.com');
insert into usuario(cd_tipo_usuario,nm_usuario,nm_senha_usuario,
cd_telefone_usuario,nm_email_usuario) values(1,'Fernanda Rocha','123','5513988070695','fernanda.rocha@gmail.com');
insert into usuario(cd_tipo_usuario,nm_usuario,nm_senha_usuario,
cd_telefone_usuario,nm_email_usuario) values(1,'Guilherme Aprigio','123','5513988070395','guilherme.aprigio@gmail.com');

insert into usuario(cd_tipo_usuario,nm_usuario,nm_senha_usuario,
cd_telefone_usuario,nm_email_usuario) values(2,'Cristian Paxur','123','5513988070123','cristian.paxur@gmail.com');
insert into usuario(cd_tipo_usuario,nm_usuario,nm_senha_usuario,
cd_telefone_usuario,nm_email_usuario) values(2,'Guilherme Pereira','123','5513967070695','guilherme.pereria@gmail.com');

insert into turma(cd_turma,aa_turma,cd_sg_turma,img_horario) values(1,2020,'1A',null);
insert into turma(cd_turma,aa_turma,cd_sg_turma,img_horario) values(2,2020,'1B',null);
insert into turma(cd_turma,aa_turma,cd_sg_turma,img_horario) values(3,2020,'1C',null);
insert into turma(cd_turma,aa_turma,cd_sg_turma,img_horario) values(4,2020,'2A',null);
insert into turma(cd_turma,aa_turma,cd_sg_turma,img_horario) values(5,2020,'2B',null);
insert into turma(cd_turma,aa_turma,cd_sg_turma,img_horario) values(6,2020,'2C',null);

insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia, nm_materia) 
values(1,72,2,25,'Geografia');
insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia,nm_materia) 
values(2,72,5,25,'Matemática');
insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia,nm_materia) 
values(3,72,3,25,'História');
insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia,nm_materia) 
values(4,72,3,25,'Educação Artística');
insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia,nm_materia) 
values(5,72,3,25,'Educação Física');
insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia,nm_materia) 
values(6,72,2,25,'Ciências');
insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia,nm_materia) 
values(7,72,5,25,'Língua Portuguêsa');
insert into materia (cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,qt_trimestre_aula_materia,nm_materia) 
values(8,72,2,24,'Língua Inglesa');

insert into aluno (cd_aluno,nm_aluno,nm_email_responsavel) values (1,'Jonas de Morais','marcelo.farias@gmail.com');
insert into aluno (cd_aluno,nm_aluno,nm_email_responsavel) values (2,'Wagner dos Santos','fernanda.rocha@gmail.com');
insert into aluno (cd_aluno,nm_aluno,nm_email_responsavel) values (3,'Wallace de Morais','guilherme.aprigio@gmail.com');

insert into recado (cd_tipo_recado,nm_email_remetente,nm_email_destinatario,dt_recado,ds_recado,
cd_aluno,img_recado,titulo_recado,ic_recado_respondido,ic_recado_lido) 
values (1,'cristian.paxur@gmail.com','marcelo.farias@gmail.com','2020-07-10 12:20:01.533000','Você permite seu filho sair?',1,null,'Saida do aluno',0,0);

insert into recado (cd_tipo_recado,nm_email_remetente,nm_email_destinatario,dt_recado,ds_recado,cd_aluno,img_recado,titulo_recado,ic_recado_respondido,ic_recado_lido) 
values (2,'guilherme.pereria@gmail.com','marcelo.farias@gmail.com','2012-10-12 13:54:00.533000','Você permite seu filho sair?',1,null,'Saida do aluno',0,0);

insert into recado (cd_tipo_recado,nm_email_remetente,nm_email_destinatario,dt_recado,ds_recado,cd_aluno,img_recado,titulo_recado,ic_recado_respondido,ic_recado_lido) 
values (7,'fernanda.rocha@gmail.com','cristian.paxur@gmail.com','2020-07-10 12:20:08.533000','Eu Fernanda Rocha permito meu filho sair',2,null,'Permissão saida aluno',0,0);
insert into recado (cd_tipo_recado,nm_email_remetente,nm_email_destinatario,dt_recado,ds_recado,cd_aluno,img_recado,titulo_recado,ic_recado_respondido,ic_recado_lido) 
values (7,'fernanda.rocha@gmail.com','guilherme.pereria@gmail.com','2020-07-10 12:20:05.533000','Eu Fernanda Rocha permito meu filho sair',2,null,'Permissão saida aluno',0,0);
insert into recado (cd_tipo_recado,nm_email_remetente,nm_email_destinatario,dt_recado,ds_recado,cd_aluno,img_recado,titulo_recado,ic_recado_respondido,ic_recado_lido) 
values (7,'marcelo.farias@gmail.com','guilherme.pereria@gmail.com','2020-07-10 12:19:05.533000','Eu Marcelo Farias permito meu filho sair',2,null,'Permissão saida aluno',0,0);

insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-04-30',4,1,'nota sem descrição','4','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(2,'2020-04-30',4,1,'nota sem descrição','4','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',4,2,'nota sem descrição','10','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',4,3,'nota sem descrição','6','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',4,4,'nota sem descrição','7','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',4,5,'nota sem descrição','8','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',4,6,'nota sem descrição','7','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',4,7,'nota sem descrição','8','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',4,8,'nota sem descrição','10','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',1,1,'Aluno conversa muito e não possui foco nas aulas.','3','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',2,1,'Muitas vezes não consegue fazer as atividades por ficar brincando','5','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-27',3,1,'nota sem descrição','7','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-03-30',5,1,'Deixou de entregar algumas atividades','5','1');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-24',4,1,'nota sem descrição','8','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-30',4,2,'nota sem descrição','9','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-24',4,3,'nota sem descrição','7','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-30',4,4,'nota sem descrição','10','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-30',4,5,'nota sem descrição','10','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-30',4,6,'nota sem descrição','6','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-30',4,7,'nota sem descrição','7','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(1,'2020-09-30',4,8,'nota sem descrição','8','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(2,'2020-03-30',4,6,'nota sem descrição','7','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(2,'2020-03-30',4,7,'nota sem descrição','8','2');
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_nota_atribuida,cd_trimestre_nota) 
values(2,'2020-03-30',4,8,'nota sem descrição','10','2');

insert into lista_aluno (cd_aluno,cd_turma,aa_turma) values (1,1,2020); 
insert into lista_aluno (cd_aluno,cd_turma,aa_turma) values (2,1,2020);
insert into lista_aluno (cd_aluno,cd_turma,aa_turma) values (3,1,2020);

insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-24',1,1,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(2,'2020-02-24',1,1,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-03-24',1,1,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-04-24',1,1,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-09-24',1,2,2,2);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-12-24',1,0,1,3);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-24',2,1,2,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-24',7,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-24',3,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-25',7,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-25',2,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-25',1,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-25',6,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-25',5,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-26',3,0,2,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-26',7,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-26',2,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-26',8,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-27',4,2,3,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-27',7,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-27',2,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-28',5,0,2,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-28',7,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-28',6,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-28',8,0,1,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-02-02',3,0,2,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-03-03',1,0,2,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-03-04',2,0,2,1);
insert into aula (cd_aluno,dt_aula,cd_materia,qt_falta_dia,qt_aula_dia,cd_trimestre_aula) 
values(1,'2020-03-05',3,0,2,1);