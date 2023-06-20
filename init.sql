CREATE DATABASE IF NOT EXISTS `db_app_eleicao_digital`;

USE db_app_eleicao_digital;

DROP TABLE IF EXISTS  `tabUsuario`,`tabPublicacao`;

CREATE TABLE `db_app_eleicao_digital`.`tabUsuario` (
  `Codigo` INT NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(255) NOT NULL,
  `Email` VARCHAR(255) NOT NULL,
  `Senha` VARCHAR(255) NOT NULL,
  `Role` VARCHAR(255) NOT NULL,
  `Instagram` VARCHAR(255) NULL,
  `Telefone` VARCHAR(255) NULL,
  `Logradouro` VARCHAR(255) NOT NULL,
  `Bairro` VARCHAR(255) NOT NULL,
  `DataCadastro` DATETIME NOT NULL,
  `UsuarioCadastroCodigo` INT NULL,
  `DataUltimaAlteracao` DATETIME NULL,
  `UsuarioAlteracaoCodigo` INT NULL,
  PRIMARY KEY (`Codigo`)
);

CREATE TABLE `db_app_eleicao_digital`.`tabPublicacao` (
    `Codigo` INT NOT NULL AUTO_INCREMENT,
    `Titulo` VARCHAR(255) NOT NULL,
    `Texto` VARCHAR(255) NOT NULL,
    `UrlsImagemPublicacao` VARCHAR(255) NOT NULL,
    `PublicacaoTipo` VARCHAR(255) NOT NULL,
    `UsuarioDonoPublicacao` INT NOT NULL,
    `Hierarquia` INT NOT NULL,
    `DataCadastro` DATETIME NOT NULL,
    `UsuarioCadastroCodigo` INT NULL,
    `DataUltimaAlteracao` DATETIME NULL,
    `UsuarioAlteracaoCodigo` INT NULL,
    PRIMARY KEY (`Codigo`),
    CONSTRAINT `UsuarioCadastro`
      FOREIGN KEY (`UsuarioCadastroCodigo`)
      REFERENCES `db_app_eleicao_digital`.`tabUsuario` (`Codigo`)
       ON DELETE CASCADE
       ON UPDATE NO ACTION,
	CONSTRAINT `UsuarioAlteracao`
      FOREIGN KEY (`UsuarioAlteracaoCodigo`)
      REFERENCES `db_app_eleicao_digital`.`tabUsuario` (`Codigo`)
       ON DELETE CASCADE
       ON UPDATE NO ACTION
);

