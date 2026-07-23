using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HorarioMedico
    {
        private int Id_Horario_HM;
        private int Legajo_HM;
        private string Dia_HM;
        private TimeSpan Horario_Inicio_HM;
        private TimeSpan Horario_Fin_HM;

        public HorarioMedico() { }

        /*getId_Horario_HM
        Devuelve el Id del horario del médico.*/
        public int getId_Horario_HM() { return Id_Horario_HM; }

        /*setId_Horario_HM
        Asigna el Id del horario del médico.*/
        public void setId_Horario_HM(int id) { Id_Horario_HM = id; }

        /*getLegajo_HM
        Devuelve el legajo del médico asociado al horario.*/
        public int getLegajo_HM() { return Legajo_HM; }

        /*setLegajo_HM
        Asigna el legajo del médico asociado al horario.*/
        public void setLegajo_HM(int legajo) { Legajo_HM = legajo; }

        /*getDia_HM
        Devuelve el día de la semana del horario.*/
        public string getDia_HM() { return Dia_HM; }

        /*setDia_HM
        Asigna el día de la semana del horario.*/
        public void setDia_HM(string dia) { Dia_HM = dia; }

        /*getHorario_Inicio_HM
        Devuelve la hora de inicio del horario.*/
        public TimeSpan getHorario_Inicio_HM() { return Horario_Inicio_HM; }

        /*setHorario_Inicio_HM
        Asigna la hora de inicio del horario.*/
        public void setHorario_Inicio_HM(TimeSpan inicio) { Horario_Inicio_HM = inicio; }

        /*getHorario_Fin_HM
        Devuelve la hora de fin del horario.*/
        public TimeSpan getHorario_Fin_HM() { return Horario_Fin_HM; }

        /*setHorario_Fin_HM
        Asigna la hora de fin del horario.*/
        public void setHorario_Fin_HM(TimeSpan fin) { Horario_Fin_HM = fin; }
    }
}