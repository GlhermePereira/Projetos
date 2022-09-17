DROP SCHEMA IF EXISTS prjSchoon;

CREATE SCHEMA prjSchoon;
USE prjSchoon;

CREATE TABLE tipo_usuario
(
	cd_tipo_usuario INT(11),
	nm_tipo_usuario VARCHAR(45),
	CONSTRAINT pk_tipo_usuario PRIMARY KEY (cd_tipo_usuario)
);


CREATE TABLE usuario
(
	cd_tipo_usuario INT(11),
	nm_usuario VARCHAR(100),
	nm_senha_usuario VARCHAR(100),
	cd_telefone_usuario VARCHAR(13),
	nm_email_usuario VARCHAR(45),
	CONSTRAINT pk_usuario PRIMARY KEY (nm_email_usuario) 
);

CREATE TABLE aluno
(
	cd_aluno INT(11),
	nm_aluno VARCHAR(100),
	nm_email_responsavel VARCHAR(45),
	CONSTRAINT pk_aluno PRIMARY KEY (cd_aluno),
	CONSTRAINT fk_aluno FOREIGN KEY (nm_email_responsavel)
	REFERENCES usuario (nm_email_usuario)
);

CREATE TABLE tipo_recado
(
	cd_tipo_recado INT(11),
	nm_tipo_recado VARCHAR(45),
	CONSTRAINT pk_tipo_recado PRIMARY KEY (cd_tipo_recado)
);

CREATE TABLE recado
(
    cd_tipo_recado int(11),
	nm_email_remetente VARCHAR(45),
	nm_email_destinatario VARCHAR(45),

	dt_recado DATETIME(6),
	ds_recado TEXT,
cd_aluno INT(11),
	img_recado longblob,
titulo_recado VARCHAR(45),
ic_recado_respondido tinyint,
ic_recado_lido tinyint,
	CONSTRAINT pk_recado PRIMARY KEY (cd_tipo_recado,nm_email_remetente, nm_email_destinatario,dt_recado),
	CONSTRAINT fk_recado FOREIGN KEY (cd_tipo_recado)
	REFERENCES tipo_recado(cd_tipo_recado),
	CONSTRAINT fk_recado_usuario FOREIGN KEY (nm_email_remetente)
	REFERENCES usuario (nm_email_usuario),
	CONSTRAINT fk_recado_usuario_sec FOREIGN KEY (nm_email_destinatario)
	REFERENCES usuario (nm_email_usuario),
	CONSTRAINT fk_recado_aluno FOREIGN KEY (cd_aluno)
	REFERENCES aluno (cd_aluno)
);

CREATE TABLE turma
(
	cd_turma INT(11),
	aa_turma INT(11),
	cd_sg_turma VARCHAR(10),
	img_horario longblob,
	CONSTRAINT pk_turma PRIMARY KEY (cd_turma, aa_turma)
);

CREATE TABLE lista_aluno
(
	cd_aluno INT(11),
	cd_turma INT(11),
	aa_turma INT(11),
	CONSTRAINT pk_lista_aluno PRIMARY KEY (cd_aluno, cd_turma, aa_turma),
	CONSTRAINT fk_lista_aluno FOREIGN KEY(cd_aluno)
	REFERENCES aluno (cd_aluno),
	CONSTRAINT fk_lista_alun_turma FOREIGN KEY (cd_turma, aa_turma)
	REFERENCES turma (cd_turma, aa_turma)
	
);

CREATE TABLE materia
(
	cd_materia INT,
	qt_total_aula_materia INT(11),
    qt_trimestre_aula_materia INT(11),
	qt_semanal_aula_materia INT(11),
	nm_materia VARCHAR(100),
	CONSTRAINT pk_materia PRIMARY KEY (cd_materia)
);

CREATE TABLE aula
(
	cd_aluno INT(11),
	dt_aula DATE,
	cd_materia INT(11),
	qt_falta_dia INT(11),
	qt_aula_dia VARCHAR(45),
    cd_trimestre_aula int(11),
	CONSTRAINT pk_aula PRIMARY KEY (cd_aluno, dt_aula, cd_materia),
	CONSTRAINT fk_aula_aluno FOREIGN KEY(cd_aluno)
	REFERENCES aluno (cd_aluno),
	CONSTRAINT fk_aula_materia FOREIGN KEY(cd_materia)
	REFERENCES materia (cd_materia)
);

CREATE TABLE tipo_nota
(
	cd_tipo_nota INT(11),
	nm_tipo_nota VARCHAR(100),
	CONSTRAINT pk_tipo_nota PRIMARY KEY (cd_tipo_nota)
);

CREATE TABLE nota
(
	cd_aluno INT(11),
	dt_nota DATE,
	cd_tipo_nota INT(11),
	cd_materia INT(11),
	ds_nota TEXT,
cd_trimestre_nota varchar(2),
	cd_nota_atribuida varchar(5),

	CONSTRAINT pk_nota PRIMARY KEY (cd_aluno, dt_nota, cd_tipo_nota, cd_materia),
	CONSTRAINT fk_nota_aluno FOREIGN KEY (cd_aluno)
	REFERENCES aluno(cd_aluno),
	CONSTRAINT fk_nota FOREIGN KEY (cd_tipo_nota)
	REFERENCES tipo_nota(cd_tipo_nota),
	CONSTRAINT fk_nota_materia FOREIGN KEY (cd_materia)
	REFERENCES materia(cd_materia)
);











