using System;
using System.Collections.Generic;
using CapaEntidad;
using CapaDatos;

namespace CapaLogica
{
    public class logPlanDeMantenimiento
    {
        private static readonly logPlanDeMantenimiento _instancia =
            new logPlanDeMantenimiento();

        public static logPlanDeMantenimiento Instancia
        {
            get { return _instancia; }
        }

        public List<entPlanDeMantenimiento> ListarPlanDeMantenimiento()
        {
            return datPlanDeMantenimiento.Instancia.ListarPlanDeMantenimiento();
        }

        public bool InsertarPlanDeMantenimiento(entPlanDeMantenimiento plan)
        {
            if (plan == null) throw new ArgumentNullException("plan");
            ValidarPlan(plan);
            return datPlanDeMantenimiento.Instancia.InsertarPlanDeMantenimiento(plan);
        }

        public bool EditarPlanDeMantenimiento(entPlanDeMantenimiento plan)
        {
            if (plan == null) throw new ArgumentNullException("plan");
            ValidarPlan(plan);
            return datPlanDeMantenimiento.Instancia.EditarPlanDeMantenimiento(plan);
        }

        public bool DeshabilitarPlanDeMantenimiento(entPlanDeMantenimiento plan)
        {
            if (plan == null) throw new ArgumentNullException("plan");
            return datPlanDeMantenimiento.Instancia.DeshabilitarPlanDeMantenimiento(plan);
        }

        private void ValidarPlan(entPlanDeMantenimiento plan)
        {
            if (plan.PlanDeMantenimientoID <= 0)
                throw new ArgumentException("El ID del plan debe ser mayor que cero.");
            if (plan.EquipoID <= 0)
                throw new ArgumentException("Debe seleccionar un equipo válido.");
            if (string.IsNullOrWhiteSpace(plan.Prioridad) ||
                !(plan.Prioridad == "Alta" || plan.Prioridad == "Media" || plan.Prioridad == "Baja"))
                throw new ArgumentException("La prioridad debe ser Alta, Media o Baja.");
            if (plan.FechaFin.Date < plan.FechaInicio.Date)
                throw new ArgumentException("La fecha fin no puede ser anterior a la fecha inicio.");
            if (plan.TiempoParada.HasValue && plan.TiempoParada.Value < 0)
                throw new ArgumentException("El tiempo de parada no puede ser negativo.");
        }
    }
}
