CREATE DATABASE IF NOT EXISTS `db_eleicaoDigital`;

USE db_eleicaoDigital;

DROP TABLE IF EXISTS `tabPessoa`, `tabUsuario`, `tabPostUsuario`;

CREATE TABLE `db_eleicaoDigital`.`tabPessoa` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `instagram` VARCHAR(255) NULL,
  `telefone` VARCHAR(255) NULL,
  `bairro` VARCHAR(100) NULL,
  `usuarioResponsavelCodigo` INT NULL,
  `dataCadastro` DATETIME NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `db_eleicaoDigital`.`tabUsuario` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `pessoaCodigo` INT NULL,
  `userName` VARCHAR(255) NOT NULL,
  `email` VARCHAR(255) NOT NULL,
  `senha` VARCHAR(255) NOT NULL,
  `role` VARCHAR(45) NOT NULL,
  `dataCadastroUsuario` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `Pessoa`
    FOREIGN KEY (`pessoaCodigo`)
    REFERENCES `db_eleicaoDigital`.`tabPessoa` (`id`)
    ON DELETE CASCADE
    ON UPDATE NO ACTION
);

CREATE TABLE `db_eleicaoDigital`.`tabPostUsuario` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `dataPost` DATETIME NOT NULL,
    `usuarioId` INT NOT NULL,
    `CaminhoArquivoPost` VARCHAR(255) NULL,
    PRIMARY KEY (`id`)
);


ALTER TABLE `tabPessoa`
ADD FOREIGN KEY (`usuarioResponsavelCodigo`) REFERENCES tabUsuario(`id`);

ALTER TABLE `tabUsuario`
ADD FOREIGN KEY (`pessoaCodigo`) REFERENCES tabPessoa(`id`);

ALTER TABLE `tabPostUsuario`
ADD FOREIGN KEY (`usuarioId`) REFERENCES tabUsuario(`id`);

INSERT `tabPessoa` VALUE (NULL,'Samuel','samuel@gmail.com','samukaBarberShop','123456789','Barueri',NULL,NOW());
set @pessoaCodigo = (select id from tabPessoa where nome = 'Samuel');

INSERT `tabUsuario` VALUE (NULL,@pessoaCodigo,'Admin','admin@admin.com','admin1234','admin',NOW());

set @usuarioCodigo = (select id from tabUsuario where pessoaCodigo = pessoaCodigo);
UPDATE `tabPessoa` set usuarioResponsavelCodigo = @usuarioCodigo where id = @pessoaCodigo;
