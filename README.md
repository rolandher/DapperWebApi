# DapperWebApi
Proyecto con Dapper

Se realiza modelo entidad relacion de un paciente, un doctor y una receta medica

![image](https://user-images.githubusercontent.com/98430956/226715194-2f1e2cb7-e3f2-4254-9b7c-a2f1af2abce6.png)


Script de la base de datos:

IF EXISTS (SELECT * FROM sysdatabases WHERE (name = 'tratamientoPaciente')) 
  DROP DATABASE tratamientoPaciente;   

CREATE DATABASE tratamientoPaciente;
GO

-- Seleccionar la base de datos
USE tratamientoPaciente;
GO

-- Crear la tabla de pacientes
CREATE TABLE pacientes (
  id INT PRIMARY KEY IDENTITY,
  nombre VARCHAR(50) NOT NULL,
  fecha_nacimiento DATE NOT NULL,
  sexo VARCHAR(50) NOT NULL
);
GO

-- Crear la tabla de Doctores
CREATE TABLE Doctores (
  id INT PRIMARY KEY IDENTITY,
  nombre_doctor VARCHAR(50) NOT NULL,
  correo VARCHAR(50) NOT NULL,
  Direccion VARCHAR(50) NOT NULL
 
);
GO

-- Crear la tabla de recetaMedica
CREATE TABLE recetaMedica (
  id INT PRIMARY KEY IDENTITY,
  nombre_medicina VARCHAR(100) NOT NULL,
  cantidad VARCHAR(50) NOT NULL,
  id_paciente INT NOT NULL,
  id_doctor INT NOT NULL,
  CONSTRAINT fk_pacientes FOREIGN KEY (id_paciente)
    REFERENCES pacientes(id), CONSTRAINT fk_doctores FOREIGN KEY (id_doctor)
    REFERENCES doctores(id)  
);
GO

