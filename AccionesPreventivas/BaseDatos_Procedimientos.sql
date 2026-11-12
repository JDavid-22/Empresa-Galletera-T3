USE AccionesPreventivas;
GO

CREATE OR ALTER PROCEDURE dbo.spListarPlanDeMantenimiento
AS
BEGIN
    SET NOCOUNT ON;
    SELECT PlanDeMantenimientoID, EquipoID, Prioridad, FechaInicio,
           FechaFin, TiempoParada, Estado
    FROM dbo.PlanDeMantenimiento
    ORDER BY PlanDeMantenimientoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spInsertarPlanDeMantenimiento
    @PlanDeMantenimientoID INT,
    @EquipoID INT,
    @Prioridad VARCHAR(10),
    @FechaInicio DATE,
    @FechaFin DATE,
    @TiempoParada DECIMAL(6,2) = NULL,
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.PlanDeMantenimiento
        (PlanDeMantenimientoID, EquipoID, Prioridad, FechaInicio, FechaFin, TiempoParada, Estado)
    VALUES
        (@PlanDeMantenimientoID, @EquipoID, @Prioridad, @FechaInicio, @FechaFin, @TiempoParada, @Estado);
END;
GO

CREATE OR ALTER PROCEDURE dbo.spEditarPlanDeMantenimiento
    @PlanDeMantenimientoID INT,
    @EquipoID INT,
    @Prioridad VARCHAR(10),
    @FechaInicio DATE,
    @FechaFin DATE,
    @TiempoParada DECIMAL(6,2) = NULL,
    @Estado BIT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PlanDeMantenimiento
    SET EquipoID = @EquipoID,
        Prioridad = @Prioridad,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        TiempoParada = @TiempoParada,
        Estado = @Estado
    WHERE PlanDeMantenimientoID = @PlanDeMantenimientoID;
END;
GO

CREATE OR ALTER PROCEDURE dbo.spDeshabilitarPlanDeMantenimiento
    @PlanDeMantenimientoID INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.PlanDeMantenimiento
    SET Estado = 0
    WHERE PlanDeMantenimientoID = @PlanDeMantenimientoID;
END;
GO
USE AccionesPreventivas;
SELECT name FROM sys.procedures;
SELECT PlanDeMantenimientoID, EquipoID, Prioridad, FechaInicio, FechaFin, TiempoParada, Estado
FROM dbo.PlanDeMantenimiento
ORDER BY PlanDeMantenimientoID;