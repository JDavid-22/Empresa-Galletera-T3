/* ------------------------------------------------------------------ */
/*  Base de datos: DBIncidencias  -  Tabla: Incidencia                */
/*  Mantenedor (Crear - Listar - Editar - Deshabilitar)               */
/*  Ejecutar completo en SQL Server Management Studio                 */
/* ------------------------------------------------------------------ */

IF DB_ID('DBIncidencias') IS NULL
    CREATE DATABASE DBIncidencias;
GO

USE DBIncidencias;
GO

/* ---------- TABLA ---------- */
IF OBJECT_ID('dbo.Incidencia', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Incidencia
    (
        IncidenciaID    int IDENTITY(1,1) NOT NULL,
        codigo          varchar(10)   NOT NULL,
        valor_observado decimal(10,2) NOT NULL,
        nivel_gravedad  varchar(10)   NOT NULL,                              -- Leve, Moderada o Critica
        fecha_hora      datetime      NOT NULL CONSTRAINT DF_Incidencia_fecha DEFAULT (GETDATE()),
        observacion     varchar(100)  NULL,
        estIncidencia   bit           NOT NULL CONSTRAINT DF_Incidencia_est   DEFAULT (1),  -- 1 = habilitada, 0 = deshabilitada
        CONSTRAINT PK_Incidencia PRIMARY KEY CLUSTERED (IncidenciaID ASC),
        CONSTRAINT UQ_Incidencia_codigo UNIQUE (codigo)
    );
END
GO

/* ---------- LISTAR ---------- */
IF OBJECT_ID('dbo.spListarIncidencia', 'P') IS NOT NULL DROP PROCEDURE dbo.spListarIncidencia;
GO
CREATE PROCEDURE dbo.spListarIncidencia
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IncidenciaID, codigo, valor_observado, nivel_gravedad, fecha_hora, observacion, estIncidencia
    FROM Incidencia
    WHERE estIncidencia = 1
    ORDER BY IncidenciaID DESC;
END
GO

/* ---------- INSERTAR (el codigo INC-0001, INC-0002... se genera solo) ---------- */
IF OBJECT_ID('dbo.spInsertarIncidencia', 'P') IS NOT NULL DROP PROCEDURE dbo.spInsertarIncidencia;
GO
CREATE PROCEDURE dbo.spInsertarIncidencia
(
    @valor_observado decimal(10,2),
    @nivel_gravedad  varchar(10),
    @fecha_hora      datetime,
    @observacion     varchar(100),
    @estIncidencia   bit
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @sig int = ISNULL((SELECT MAX(IncidenciaID) FROM Incidencia), 0) + 1;
    DECLARE @codigo varchar(10) = 'INC-' + RIGHT('0000' + CAST(@sig AS varchar(10)), 4);

    INSERT INTO Incidencia (codigo, valor_observado, nivel_gravedad, fecha_hora, observacion, estIncidencia)
    VALUES (@codigo, @valor_observado, @nivel_gravedad, @fecha_hora, @observacion, @estIncidencia);
END
GO

/* ---------- EDITAR (no cambia ni el codigo ni la fecha de registro) ---------- */
IF OBJECT_ID('dbo.spEditarIncidencia', 'P') IS NOT NULL DROP PROCEDURE dbo.spEditarIncidencia;
GO
CREATE PROCEDURE dbo.spEditarIncidencia
(
    @IncidenciaID    int,
    @valor_observado decimal(10,2),
    @nivel_gravedad  varchar(10),
    @observacion     varchar(100),
    @estIncidencia   bit
)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Incidencia
    SET valor_observado = @valor_observado,
        nivel_gravedad  = @nivel_gravedad,
        observacion     = @observacion,
        estIncidencia   = @estIncidencia
    WHERE IncidenciaID = @IncidenciaID;
END
GO

/* ---------- DESHABILITAR (borrado logico) ---------- */
IF OBJECT_ID('dbo.spDeshabilitarIncidencia', 'P') IS NOT NULL DROP PROCEDURE dbo.spDeshabilitarIncidencia;
GO
CREATE PROCEDURE dbo.spDeshabilitarIncidencia
(
    @IncidenciaID int
)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Incidencia SET estIncidencia = 0 WHERE IncidenciaID = @IncidenciaID;
END
GO

/* ---------- PRUEBA RAPIDA (opcional) ---------- */
-- EXEC spInsertarIncidencia 85.50, 'Moderada', '2026-11-12 08:30', 'Temperatura alta en horno', 1;
-- EXEC spListarIncidencia;
