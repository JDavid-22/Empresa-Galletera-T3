CREATE DATABASE AccionesPreventivas
use AccionesPreventivas
--Agrega una columna si no existe---
IF COL_LENGTH('CatálogoDeComponentes','Codigo') IS NULL ALTER TABLE [CatálogoDeComponentes] ADD [Codigo] varchar(10) NULL
IF COL_LENGTH('CatálogoDeComponentes','Nombre') IS NULL ALTER TABLE [CatálogoDeComponentes] ADD [Nombre] varchar(60) NULL
IF COL_LENGTH('CatálogoDeComponentes','Tipo') IS NULL ALTER TABLE [CatálogoDeComponentes] ADD [Tipo] varchar(30) NULL
GO
IF COL_LENGTH('Equipo','Nombre') IS NULL ALTER TABLE [Equipo] ADD [Nombre] varchar(60) NULL
IF COL_LENGTH('Equipo','Ubicacion') IS NULL ALTER TABLE [Equipo] ADD [Ubicacion] varchar(60) NULL
GO
IF COL_LENGTH('AnalisisDeFallas','Fecha') IS NULL ALTER TABLE [AnalisisDeFallas] ADD [Fecha] date NULL
IF COL_LENGTH('AnalisisDeFallas','Descripcion') IS NULL ALTER TABLE [AnalisisDeFallas] ADD [Descripcion] varchar(120) NULL
IF COL_LENGTH('AnalisisDeFallas','Estado') IS NULL ALTER TABLE [AnalisisDeFallas] ADD [Estado] varchar(20) NULL
GO
IF COL_LENGTH('ObservacionesDeAjustes','Fecha') IS NULL ALTER TABLE [ObservacionesDeAjustes] ADD [Fecha] date NULL
IF COL_LENGTH('ObservacionesDeAjustes','Observacion') IS NULL ALTER TABLE [ObservacionesDeAjustes] ADD [Observacion] varchar(150) NULL
GO
--Comprueba que las comlumnas quedaron---
SELECT TABLE_NAME, COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE COLUMN_NAME IN ('Codigo','Nombre','Tipo','Ubicacion','Fecha','Descripcion','Estado','Observacion')
  AND TABLE_NAME <> 'PlanDeMantenimiento'
ORDER BY TABLE_NAME, COLUMN_NAME
--Insertamos Datos----
DELETE FROM [ObservacionesDeAjustes]
DELETE FROM [PlanDeMantenimiento]
DELETE FROM [AnalisisDeFallas]
DELETE FROM [Equipo]
DELETE FROM [CatálogoDeComponentes]
GO

INSERT INTO [CatálogoDeComponentes] ([CatálogoDeComponentesID], [Codigo], [Nombre], [Tipo])
VALUES
    (1, 'CMP-001', 'Rodamiento 6205',       'Mecánico'),
    (2, 'CMP-002', 'Motor eléctrico 5 HP',  'Eléctrico'),
    (3, 'CMP-003', 'Banda transportadora',  'Mecánico'),
    (4, 'CMP-004', 'Sensor de temperatura', 'Electrónico'),
    (5, 'CMP-005', 'Válvula neumática',     'Neumático')
GO

INSERT INTO [Equipo] ([EquipoID], [CatálogoDeComponentesID], [Nombre], [Ubicacion])
VALUES
    (1, 1, 'Compresor 01',           'Planta A'),
    (2, 1, 'Bomba de agua 02',       'Planta A'),
    (3, 2, 'Molino 03',              'Planta B'),
    (4, 3, 'Faja transportadora 04', 'Planta B'),
    (5, 4, 'Horno 05',               'Planta C'),
    (6, 5, 'Prensa neumática 06',    'Planta C')
GO

INSERT INTO [AnalisisDeFallas] ([AnalisisDeFallasID], [EquipoID], [Fecha], [Descripcion], [Estado])
VALUES
    (1, 1, '2026-10-20', 'Desgaste de rodamientos por vibración', 'Atendido'),
    (2, 1, '2026-11-02', 'Sobrecalentamiento del compresor',      'Pendiente'),
    (3, 2, '2026-10-28', 'Fuga en el sello mecánico',             'Atendido'),
    (4, 3, '2026-11-05', 'Ruido anormal en el motor',             'Pendiente'),
    (5, 5, '2026-11-08', 'Lectura de temperatura inestable',      'Pendiente'),
    (6, 6, '2026-10-15', 'Pérdida de presión en la válvula',      'Atendido')
GO

INSERT INTO [PlanDeMantenimiento]
    ([PlanDeMantenimientoID], [EquipoID], [Prioridad], [FechaInicio], [FechaFin], [TiempoParada], [Estado])
VALUES
    (1, 1, 'Alta',  '2026-11-16', '2026-11-18', 6.00, 1),
    (2, 2, 'Media', '2026-11-20', '2026-11-21', 4.50, 1),
    (3, 3, 'Alta',  '2026-11-25', '2026-11-27', 8.00, 1),
    (4, 4, 'Baja',  '2026-12-02', '2026-12-02', 2.00, 1),
    (5, 5, 'Media', '2026-12-09', '2026-12-10', 5.00, 1),
    (6, 6, 'Baja',  '2026-10-05', '2026-10-06', 3.00, 0)
GO

INSERT INTO [ObservacionesDeAjustes] ([ObservacionesDeAjustesID], [PlanDeMantenimientoID], [Fecha], [Observacion])
VALUES
    (1, 2, '2026-11-10', 'Falta de repuesto; reprogramar para la semana siguiente'),
    (2, 4, '2026-11-11', 'La parada de máquina excede el tiempo disponible'),
    (3, 5, '2026-11-11', 'Se requiere validar materiales con almacén')
GO

-- LISTAR PLANES
CREATE PROCEDURE spListarPlanDeMantenimiento
AS
BEGIN
    SELECT
        PlanDeMantenimientoID,
        EquipoID,
        Prioridad,
        FechaInicio,
        FechaFin,
        TiempoParada,
        Estado
    FROM PlanDeMantenimiento;
END
GO

-- INSERTAR PLAN
CREATE PROCEDURE spInsertarPlanDeMantenimiento
    @PlanDeMantenimientoID INT,
    @EquipoID INT,
    @Prioridad VARCHAR(10),
    @FechaInicio DATE,
    @FechaFin DATE,
    @TiempoParada DECIMAL(6,2),
    @Estado BIT
AS
BEGIN
    INSERT INTO PlanDeMantenimiento
    (
        PlanDeMantenimientoID,
        EquipoID,
        Prioridad,
        FechaInicio,
        FechaFin,
        TiempoParada,
        Estado
    )
    VALUES
    (
        @PlanDeMantenimientoID,
        @EquipoID,
        @Prioridad,
        @FechaInicio,
        @FechaFin,
        @TiempoParada,
        @Estado
    );
END
GO

-- EDITAR PLAN
CREATE PROCEDURE spEditarPlanDeMantenimiento
    @PlanDeMantenimientoID INT,
    @EquipoID INT,
    @Prioridad VARCHAR(10),
    @FechaInicio DATE,
    @FechaFin DATE,
    @TiempoParada DECIMAL(6,2),
    @Estado BIT
AS
BEGIN
    UPDATE PlanDeMantenimiento
    SET
        EquipoID = @EquipoID,
        Prioridad = @Prioridad,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        TiempoParada = @TiempoParada,
        Estado = @Estado
    WHERE PlanDeMantenimientoID = @PlanDeMantenimientoID;
END
GO

-- INHABILITAR PLAN
CREATE PROCEDURE spDeshabilitarPlanDeMantenimiento
    @PlanDeMantenimientoID INT
AS
BEGIN
    UPDATE PlanDeMantenimiento
    SET Estado = 0
    WHERE PlanDeMantenimientoID = @PlanDeMantenimientoID;
END
GO
--Comprobar si funciona--
SELECT name FROM sys.procedures;
SELECT DB_NAME() AS BaseActual;
USE AccionesPreventivas;
SELECT DB_NAME() AS BaseActual;
SELECT name FROM sys.procedures;
USE master;
DROP PROCEDURE IF EXISTS dbo.spListarPlanDeMantenimiento;
DROP PROCEDURE IF EXISTS dbo.spInsertarPlanDeMantenimiento;
DROP PROCEDURE IF EXISTS dbo.spEditarPlanDeMantenimiento;
DROP PROCEDURE IF EXISTS dbo.spDeshabilitarPlanDeMantenimiento;