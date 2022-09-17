delimiter $$

drop procedure if exists login$$


drop procedure if exists inserir_notas$$
drop procedure if exists verificar_notas$$
drop procedure if exists verificar_alunos$$
drop procedure if exists todos_recados_recebidos_func$$
drop procedure if exists recado_especifico_recebido_func$$
drop procedure if exists todos_recados_enviados_func$$
drop procedure if exists recado_especifico_enviado_func$$
drop procedure if exists mostrar_turmas$$
drop procedure if exists mostrar_alunos$$
drop procedure if exists datas_recados$$
drop procedure if exists inserir_recado$$
drop procedure if exists todos_recados_recebidos_responsavel$$
drop procedure if exists recado_especifico_recebido_responsavel$$
drop procedure if exists todos_recados_enviados_responsavel$$
drop procedure if exists recado_especifico_enviado_responsavel$$
drop procedure if exists mostrar_funcionarios$$
drop procedure if exists inserir_aluno$$
drop procedure if exists inserir_materia$$
drop procedure if exists verificar_materia$$
drop procedure if exists inserir_pai$$
drop procedure if exists verificar_tipo_usuario$$
drop procedure if exists inserir_funcionario$$
drop procedure if exists inserir_lista_aluno$$
drop procedure if exists selecionar_nota_trimestral$$
drop procedure if exists nota_especifico$$

create procedure verificar_tipo_usuario(vEmail varchar(45))
begin
select cd_tipo_usuario from usuario where nm_email_usuario=vEmail;

end$$


create procedure verificar_materia(vCodigo_Materia int(11),vNome_Materia varchar(100))
begin
SELECT 
		cd_materia,qt_total_aula_materia,qt_semanal_aula_materia,nm_materia
	FROM 
		materia
	WHERE 
		cd_materia=vCodigo_Materia and vNome_Materia=vNome_Materia;

end$$

create procedure inserir_materia(vCodigo_Materia int(11),vQt_Total_Aula_Materia int(11), vTrimestre  INT,vQt_Semanal_Aula_Materia int(11),vNome_Materia varchar(100))
begin
insert into materia(cd_materia,qt_total_aula_materia,qt_trimestre_aula_materia,qt_semanal_aula_materia,nm_materia) 
values(vCodigo_Materia,vQt_Total_Aula_Materia,vTrimestre,vQt_Semanal_Aula_Materia,vNome_Materia);
end$$

create procedure inserir_pai(vCodigoTipoUsuario int(11),vNomeUsuario varchar(100),vNomeSenha varchar(100),vCodigoTelefone varchar(13),vNomeEmail  varchar(100))
begin
insert into usuario(cd_tipo_usuario,nm_usuario,nm_senha_usuario,cd_telefone_usuario,nm_email_usuario) 
values(vCodigoTipoUsuario,vNomeUsuario,vNomeSenha,vCodigoTelefone,vNomeEmail);
end$$


create procedure verificar_alunos(vCodigo_Aluno int(11),vCodigo_Turma int(11),vAno_Turma int(11))
begin
SELECT 
		cd_aluno,cd_turma,aa_turma
	FROM 
		lista_aluno
	WHERE 
		cd_aluno=vCodigo_Aluno and cd_turma=vCodigo_Turma and aa_turma=vAno_Turma;

end$$




create procedure inserir_aluno(vCodigo_Aluno int(11),vNome_aluno varchar(100),vNome_Email_Responsavel varchar(45))
begin
insert into aluno(cd_aluno,nm_aluno,nm_email_responsavel) values(vCodigo_Aluno,vNome_aluno,vNome_Email_Responsavel);

end$$

create procedure inserir_lista_aluno(vCodigo_Aluno int(11),vCodigo_Turma int(11),vAno_Turma int(11))
begin
insert into lista_aluno(cd_aluno,cd_turma,aa_turma) values(vCodigo_Aluno,vCodigo_Turma,vAno_Turma);
end$$



/*/Inserir Notas 1,'2020-01-8',3,1,'Como vc n foi muito bem na prova sua note é 5 melhore','5'/*/
create procedure inserir_notas(vCodigo_aluno int (11),vData_Nota date,vCodigo_Nota int(11),vCodigo_Materia int(11), vDs_Nota text, vTrimestre INT, vNota_Atribuida varchar(5))
begin
insert into nota(cd_aluno,dt_nota,cd_tipo_nota,cd_materia,ds_nota,cd_trimestre_nota,cd_nota_atribuida)
 values(vCodigo_aluno,vData_Nota,vCodigo_Nota,vCodigo_Materia,vDs_Nota, vTrimestre,vNota_Atribuida);
end$$


/*/Faz o login no sistema/*/
create procedure verificar_notas(vCodigo_Materia int(11),vCodigo_Aluno varchar(11),vData_Nota date)
begin
	SELECT 
		cd_materia,cd_aluno,dt_nota 
	FROM 
		nota 
	WHERE 
		cd_materia=vCodigo_Materia AND cd_aluno=vCodigo_Aluno and dt_nota=vData_Nota;
end$$

/*/Importar notas/*/
create procedure login(vEmail varchar(45),vSenha varchar(45))
begin
	SELECT 
		nm_email_usuario,nm_senha_usuario 
	FROM 
		usuario 
	WHERE 
		nm_email_usuario=vEmail AND nm_senha_usuario=vSenha;
end$$

/*/Mostrar o nome do pai/*/
drop procedure if exists Nome_Pai$$
create procedure Nome_Pai(vCodigo_Aluno int(11))
begin
	select us.nm_usuario from aluno al join usuario us on (al.nm_email_responsavel=us.nm_email_usuario) where cd_aluno=vCodigo_Aluno;
end$$


/*/Inserir Recado/*/
create procedure inserir_recado(vCodigo_Recado int (11),vNome_Email_Remetente varchar(45),
vNome_Email_Destinario varchar(45),vData_Recado datetime(6),vDs_Recado text, vImagen_Recado blob, 
vCodigo_aluno int(11),vTituloRecado varchar(45),vRecadoRespondido tinyint,vRecadoLido tinyint)
begin
insert into recado (cd_tipo_recado,nm_email_remetente,nm_email_destinatario,dt_recado,ds_recado,
cd_aluno,img_recado,titulo_recado,ic_recado_respondido,ic_recado_lido) 
values (vCodigo_Recado,vNome_Email_Remetente,vNome_Email_Destinario,vData_Recado,vDs_Recado,
vCodigo_aluno,vImagen_Recado,vTituloRecado,vRecadoRespondido,vRecadoLido);
end$$


/*/Mostra todos os recados recebidos de um determinado funcionário/*/
create procedure todos_recados_recebidos_func(vEmail_Funcionario varchar(45))
begin
	SELECT
		rc.titulo_recado,
us.nm_usuario,
rc.ds_recado, 
	rc.dt_recado, 
	rc.nm_email_destinatario,
rc.nm_email_remetente,
rc.ic_recado_lido


	FROM
		recado rc JOIN usuario us ON (rc.nm_email_remetente = us.nm_email_usuario) 
	WHERE 
		rc.nm_email_destinatario=vEmail_Funcionario  AND us.cd_tipo_usuario= 1 ORDER BY dt_recado DESC;
end$$


/*/Mostra os dados mais avançados do recado que foi recebdido/*/
create procedure recado_especifico_recebido_func(vEmail_Funcionario varchar(45),vData_Recado datetime(6))
begin
	SELECT  
	rc.titulo_recado,
us.nm_usuario,
rc.ds_recado, 
	rc.dt_recado, 
	rc.nm_email_destinatario,
rc.nm_email_remetente,
rc.cd_tipo_recado,
	rc.img_recado,
rc.ic_recado_lido,
rc.ic_recado_respondido
	FROM
		recado rc JOIN usuario us ON (rc.nm_email_remetente = us.nm_email_usuario) 
	WHERE
		rc.nm_email_destinatario=vEmail_Funcionario AND rc.dt_recado=vData_Recado ;
end$$


/*/Mostra todos os recados enviados de um determinado funcionário/*/
create procedure todos_recados_enviados_func(vEmail_Funcionario varchar(45))
begin
	SELECT  
rc.titulo_recado,
us.nm_usuario,
rc.ds_recado, 
	rc.dt_recado, 
	rc.nm_email_destinatario,
rc.nm_email_remetente
	FROM 
		recado rc JOIN usuario us ON (rc.nm_email_destinatario = us.nm_email_usuario) 
	WHERE 
		rc.nm_email_remetente= vEmail_Funcionario
group by rc.dt_recado desc
;
end$$


/*/Mostra os dados mais avançados do recado que foi enviado/*/
create procedure recado_especifico_enviado_func(vEmail_Funcionario varchar(45),vData_Recado datetime(6))
begin
	SELECT 
	rc.titulo_recado,
us.nm_usuario,
rc.ds_recado, 
	rc.dt_recado, 
	rc.nm_email_destinatario,
rc.nm_email_remetente,
rc.cd_tipo_recado,
rc.img_recado
	FROM 
		recado rc JOIN usuario us ON (rc.nm_email_destinatario = us.nm_email_usuario) 
	WHERE 
		rc.nm_email_remetente=vEmail_Funcionario AND rc.dt_recado= vData_Recado  group by rc.dt_recado desc;
end$$


/*/Mostra todas as turmas existentes no sistema de um ano específico/*/
create procedure mostrar_turmas(vAno_Turma int(11))
begin
	SELECT 
		cd_sg_turma 
	FROM 
		turma 
	WHERE 
		aa_turma = vAno_Turma;
end$$


/*/Mostra todos os alunos existentes no sistema/*/
create procedure mostrar_alunos(vCodigo_Aluno int(11),vEmail_Responsavel varchar(45))
begin
	SELECT 
		al.nm_aluno, 
		al.cd_aluno, 
		al.nm_email_responsavel 
	FROM 
		turma t JOIN lista_aluno ls ON (t.cd_turma=ls.cd_turma) JOIN aluno al ON (ls.cd_aluno=al.cd_aluno) 
	WHERE
		ls.cd_aluno = vCodigo_Aluno AND nm_email_responsavel = vEmail_Responsavel ;
end$$

create procedure datas_recados(vEmail_Funcionario varchar(45))
begin
	SELECT 
		dt_recado
	FROM 
		recado
	WHERE
		nm_email_destinatario=vEmail_Funcionario;
end$$


/*/

/*/

/*/
-
-
-
-
App Pais
-
-
-
-
/*/


/*/Mostra todos os recados recebidos de um determinadi responsável/*/
create procedure todos_recados_recebidos_responsavel(vNome_Email varchar(45))
begin
	SELECT
	rc.titulo_recado,
us.nm_usuario,
rc.ds_recado, 
	rc.dt_recado, 
	rc.nm_email_destinatario,
rc.nm_email_remetente
	FROM 
		recado rc JOIN usuario us ON (rc.nm_email_remetente = us.nm_email_usuario) 
	WHERE 
		rc.nm_email_destinatario=vNome_Email 
	ORDER BY dt_recado desc;
end$$


/*/Mostra os dados mais avançados de um determinado recado/*/
create procedure recado_especifico_recebido_responsavel(vNome_Email varchar(45),Data_Recado datetime(6))
begin
	SELECT
rc.titulo_recado,
		us.nm_usuario,
rc.ds_recado, 
		rc.dt_recado, 
		rc.nm_email_destinatario,
rc.nm_email_remetente,
rc.cd_tipo_recado,
		rc.img_recado,
rc.ic_recado_lido,
rc.ic_recado_respondido
	FROM 
		recado rc JOIN usuario us ON (rc.nm_email_remetente = us.nm_email_usuario) 
	WHERE 
		rc.nm_email_destinatario=vNome_Email AND rc.dt_recado=Data_Recado
ORDER BY dt_recado DESC;
end$$


/*/inserir funcionario/*/
create procedure inserir_funcionario(vCodigoTipoUsuario int(11),vNomeUsuario varchar(100),vNomeSenha varchar(100),vNomeEmail  varchar(100))
begin
insert into usuario(cd_tipo_usuario,nm_usuario,nm_senha_usuario,nm_email_usuario) 
values(vCodigoTipoUsuario,vNomeUsuario,vNomeSenha,vNomeEmail);
end$$
/*/Mostra todos os recados enviados de um determinado responsável/*/


create procedure nota_especifico(vCodigoAluno int(11),vCodigoMateria int,vCodigoTrimestre int)
begin

select 
tn.nm_tipo_nota as 'Instrumento',
date_format(nt.dt_nota, '%d/%m/%Y') as 'Data',
nt.cd_nota_atribuida as 'Nota',
nt.ds_nota as 'Observação'
from nota nt
join tipo_nota tn ON (nt.cd_tipo_nota = tn.cd_tipo_nota)
 where nt.cd_aluno=vCodigoAluno
and nt.cd_materia=vCodigoMateria
and nt.cd_trimestre_nota= vCodigoTrimestre;

	
end$$


create procedure selecionar_nota_trimestral(vCodigoAluno int(11), vAno INT)
begin
select 
ma.cd_materia,
ma.nm_materia as 'Matéria',
case when trim1.cd_nota_atribuida is null then '-'
 when trim1.cd_nota_atribuida is not null then trim1.cd_nota_atribuida end '1º Trimestre',
case when trim2.cd_nota_atribuida is null then '-'
 when trim2.cd_nota_atribuida is not null then trim2.cd_nota_atribuida end '2º Trimestre',
case when trim3.cd_nota_atribuida is null then '-'
 when trim3.cd_nota_atribuida is not null then trim3.cd_nota_atribuida end '3º Trimestre',
   
concat(abs(round(sum(au.qt_aula_dia - au.qt_falta_dia)*100/ma.qt_total_aula_materia -100, 2)), '%') as 'Frequência'
from materia ma left join(select
nt.cd_materia, 
nt.cd_nota_atribuida
from nota nt
   
where nt.cd_aluno=vCodigoAluno
and cd_tipo_nota=4
and cd_trimestre_nota = 1) trim1 ON ma.cd_materia=trim1.cd_materia
left join (select
nt.cd_materia, 
nt.cd_nota_atribuida
from nota nt
   
where nt.cd_aluno=vCodigoAluno
and cd_tipo_nota=4
and cd_trimestre_nota = 2) trim2 ON ma.cd_materia = trim2.cd_materia
 left join (select
nt.cd_materia, 
nt.cd_nota_atribuida
from nota nt
   
where nt.cd_aluno=vCodigoAluno
and cd_tipo_nota=4
and cd_trimestre_nota = 3) trim3 ON ma.cd_materia = trim3.cd_materia

 join aula au ON (ma.cd_materia = au.cd_materia) 

 where au.cd_aluno = vCodigoAluno and year(au.dt_aula) = vAno group by 
cd_materia;
end$$





/*/Mostra todos os recados enviados de um determinado responsável/*/
create procedure todos_recados_enviados_responsavel(vNome_Email varchar(45))
begin
	SELECT
rc.titulo_recado,
us.nm_usuario,
rc.ds_recado, 
	rc.dt_recado, 
	rc.nm_email_destinatario,
rc.nm_email_remetente
	FROM
		recado rc JOIN usuario us ON (rc.nm_email_destinatario = us.nm_email_usuario) 
	WHERE 
		rc.nm_email_remetente=vNome_Email and us.cd_tipo_usuario=2
	ORDER BY dt_recado DESC;
end$$


/*/Mostra os dados avançados de um determinado recado enviado pelo responsavel/*/
create procedure recado_especifico_enviado_responsavel(vNome_Email varchar(45),Data_Recado datetime(6))
begin
	SELECT
	rc.titulo_recado,
		us.nm_usuario,
rc.ds_recado, 
		rc.dt_recado, 
		rc.nm_email_destinatario,
rc.nm_email_remetente,
rc.cd_tipo_recado,
		rc.img_recado 
	FROM
		recado rc JOIN usuario us ON (rc.nm_email_destinatario = us.nm_email_usuario) 
	WHERE 
		rc.nm_email_remetente=vNome_Email AND dt_recado = Data_Recado 
	ORDER BY dt_recado DESC;
end$$


/*/Mostra todos os funcionários existentes no sistema/*/
create procedure mostrar_funcionarios(vCodigo_Usuario int(11))
begin
	SELECT
		nm_usuario 
	FROM 
		usuario 
	WHERE 
		cd_tipo_usuario = vCodigo_Usuario
	ORDER BY nm_usuario DESC;
end$$

delimiter ; 
/*/call inserir_aluno(4,'Jorje de Carvalho','guilherme.aprigio@gmail.com');/*/
/*/call inserir_lista_aluno(4,1,2020);/*/
/*/call inserir_notas(1,'2020-01-23',3,1,'Como vc n foi muito bem na prova sua note é 5 melhore','5');/*/
/*/call inserir_materia(1,100,4,'Geografia');/*/
call verificar_materia(1,'Geografia');
call verificar_alunos(1,1,2020);
call verificar_notas(1,1,'2020-03-3');
call mostrar_funcionarios(2);
/*call inserir_recado(7,'fernanda.rocha@gmail.com','guilherme.pereria@gmail.com','2020-07-10 12:20:10','Eu Fernanda Rocha permito meu filho sair',2,null);/*/
call Nome_Pai(1);
call todos_recados_recebidos_func('guilherme.pereria@gmail.com');
call recado_especifico_recebido_func('guilherme.pereria@gmail.com','2020-07-10 12:20:07');
call todos_recados_enviados_func ('guilherme.pereria@gmail.com');
call recado_especifico_enviado_func ('guilherme.pereria@gmail.com','2020-07-10 12:20:02' );
call mostrar_turmas (2020);
call mostrar_alunos (1,'marcelo.farias@gmail.com');

/*/ call select_importar_notas ('2020-01-9'); /*/



