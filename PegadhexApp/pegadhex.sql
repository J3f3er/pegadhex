--
-- Archivo generado con SQLiteStudio v3.4.6 el vie. nov. 29 10:52:59 2024
--
-- Codificación de texto usada: System
--
PRAGMA foreign_keys = off;
BEGIN TRANSACTION;

-- Tabla: niveles
CREATE TABLE IF NOT EXISTS niveles (idNivel INTEGER PRIMARY KEY AUTOINCREMENT, nombreNivel TEXT, descriptionNivel TEXT);

-- Tabla: proveedores
CREATE TABLE IF NOT EXISTS proveedores (idProveedores INTEGER PRIMARY KEY AUTOINCREMENT, nombreProveedores TEXT, empresaProveedores TEXT, RIFProveedores TEXT UNIQUE, productoProveedores TEXT, fechaProveedores TEXT);

-- Tabla: usuarios
CREATE TABLE IF NOT EXISTS usuarios (idUsuario INTEGER PRIMARY KEY AUTOINCREMENT, nombreUusuario TEXT, apellidoUsuario TEXT, correoUsuario TEXT, contrasenaUsuario TEXT, nivelUsuario TEXT);

COMMIT TRANSACTION;
PRAGMA foreign_keys = on;
