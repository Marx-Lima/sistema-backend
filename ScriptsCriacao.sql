-- criar banco de dados
CREATE DATABASE programacao_zero;

-- usar o banco de dados
USE programacao_zero;

-- criar tabela usuário
CREATE TABLE usuario(
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(200) NOT NULL,
	cpf VARCHAR(14) NOT NULL,
	celular VARCHAR(15) NOT NULL,
	genero VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	senha VARCHAR(8) NOT NULL,
	PRIMARY KEY (id)
);

-- criar tabela endereço
CREATE TABLE endereco(
	id INT NOT NULL AUTO_INCREMENT,
    rua VARCHAR(250) NOT NULL,
    numero VARCHAR(10) NOT NULL,
    bairro VARCHAR(150) NOT NULL,
    cidade VARCHAR(250) NOT NULL,
    complemento VARCHAR(150) NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY(id)
);

-- alterar tabela
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

-- adicionar chave estrangeira
ALTER TABLE endereco ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

-- inserir usuário
INSERT INTO usuario(nome, cpf, celular, genero, email, senha) 
VALUES ('Lima', '0123456789', '(77)98820-1900', 'masculino', 'max.supri.max@gmail.com', '654321')

-- selecionar usuario
SELECT * FROM usuario;
SELECT * FROM usuario WHERE email = 'max.supri.max@gmail.com';

-- alterar usuario
UPDATE usuario SET senha = '777123' WHERE id = 2;

-- excluir usuario
DELETE FROM usuario where id = 2
DELETE FROM usuario where id IN (2,3) -- excluir varios
DELETE FROM usuario where id > 2 -- excluir todos após o 2