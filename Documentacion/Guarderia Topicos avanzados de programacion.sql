-- Creacion de la base de datos
CREATE DATABASE Guarderia;

-- Uso de la base de datos
USE Guarderia;

-- Tabla Nino
CREATE TABLE Nino (
    num_matricula INT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    fecha_nacimiento DATE NOT NULL,
    fecha_ingreso DATE NOT NULL,
    fecha_baja DATE not NULL
);
go
-- Tabla PersonaAutorizada
CREATE TABLE PersonaAutorizada (
    CURP VARCHAR(18) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(255) NOT NULL,
    telefono VARCHAR(15) NOT NULL
);
go
-- Tabla RelacionAutorizacion
CREATE TABLE RelacionAutorizacion (
    num_matricula INT,
    CURP VARCHAR(18),
    relacion VARCHAR(50),
    PRIMARY KEY (num_matricula, CURP),
    FOREIGN KEY (num_matricula) REFERENCES Nino(num_matricula),
    FOREIGN KEY (CURP) REFERENCES PersonaAutorizada(CURP)
);
go
-- Tabla Pagador
CREATE TABLE Pagador (
    DNI VARCHAR(9) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    direccion VARCHAR(255) NOT NULL,
    telefono VARCHAR(15) NOT NULL,
    cuenta_corriente VARCHAR(20) NOT NULL
);
go
-- Tabla Pagos
CREATE TABLE Pagos (
    num_matricula INT,
    DNI VARCHAR(9),
    PRIMARY KEY (num_matricula, DNI),
    FOREIGN KEY (num_matricula) REFERENCES Nino(num_matricula),
    FOREIGN KEY (DNI) REFERENCES Pagador(DNI)
);
go
-- Tabla Alergia
CREATE TABLE Alergia (
    num_matricula INT,
    nombre_ingrediente VARCHAR(100),
    PRIMARY KEY (num_matricula, nombre_ingrediente),
    FOREIGN KEY (num_matricula) REFERENCES Nino(num_matricula)
);
go
-- Tabla AsistenciaComida
CREATE TABLE AsistenciaComida (
    num_matricula INT,
    fecha DATE,
    num_menu INT,
    PRIMARY KEY (num_matricula, fecha),
    FOREIGN KEY (num_matricula) REFERENCES Nino(num_matricula)
);
go
-- Tabla CostoMensual
CREATE TABLE CostoMensual (
    num_matricula INT,
    mes INT,
    anio INT,
    costo_fijo DECIMAL(10, 2) NOT NULL,
    costo_comidas DECIMAL(10, 2) NOT NULL,
    PRIMARY KEY (num_matricula, mes, anio),
    FOREIGN KEY (num_matricula) REFERENCES Nino(num_matricula)
);
go

select*from Nino

