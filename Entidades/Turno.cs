using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turno
    {
        private int Id_Turno_T;
        private int Id_Paciente_T;
        private int Id_Horario_T;
        private TimeSpan Horario_Turno_T;
        private DateTime Fecha_Turno_T;
        private bool Estado_T;
        private bool Presentismo_T;
        private string Observacion_T;

        public Turno() { }

        /*getId_Turno_T
        Devuelve el Id del turno.*/
        public int getId_Turno_T() { return Id_Turno_T; }

        /*setId_Turno_T
        Asigna el Id del turno.*/
        public void setId_Turno_T(int id) { Id_Turno_T = id; }

        /*getId_Paciente_T
        Devuelve el Id del paciente asociado al turno.*/
        public int getId_Paciente_T() { return Id_Paciente_T; }

        /*setId_Paciente_T
        Asigna el Id del paciente asociado al turno.*/
        public void setId_Paciente_T(int id) { Id_Paciente_T = id; }

        /*getId_Horario_T
        Devuelve el Id del horario asociado al turno.*/
        public int getId_Horario_T() { return Id_Horario_T; }

        /*setId_Horario_T
        Asigna el Id del horario asociado al turno.*/
        public void setId_Horario_T(int id) { Id_Horario_T = id; }

        /*getHorario_Turno_T
        Devuelve la hora del turno.*/
        public TimeSpan getHorario_Turno_T() { return Horario_Turno_T; }

        /*setHorario_Turno_T
        Asigna la hora del turno.*/
        public void setHorario_Turno_T(TimeSpan hora) { Horario_Turno_T = hora; }

        /*getFecha_Turno_T
        Devuelve la fecha del turno.*/
        public DateTime getFecha_Turno_T() { return Fecha_Turno_T; }

        /*setFecha_Turno_T
        Asigna la fecha del turno.*/
        public void setFecha_Turno_T(DateTime fecha) { Fecha_Turno_T = fecha; }

        /*getEstado_T
        Devuelve el estado del turno (true = Activo, false = Inactivo).*/
        public bool getEstado_T() { return Estado_T; }

        /*setEstado_T
        Asigna el estado del turno (true = Activo, false = Inactivo).*/
        public void setEstado_T(bool estado) { Estado_T = estado; }

        /*getPresentismo_T
        Devuelve el estado de presentismo del turno (true = Presente, false = Ausente).*/
        public bool getPresentismo_T() { return Presentismo_T; }

        /*setPresentismo_T
        Asigna el estado de presentismo del turno (true = Presente, false = Ausente).*/
        public void setPresentismo_T(bool presentismo) { Presentismo_T = presentismo; }

        /*getObservacion_T
        Devuelve la observación del turno.*/
        public string getObservacion_T() { return Observacion_T; }

        /*setObservacion_T
        Asigna la observación del turno.*/
        public void setObservacion_T(string observacion) { Observacion_T = observacion; }
    }
}