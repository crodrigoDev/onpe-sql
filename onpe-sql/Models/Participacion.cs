using System.Data;

namespace onpe_sql.Models
{
    public class Participacion
    {
        public string detalle { get; set; }
        public int TV { get; set; }
        public string PTV { get; set; }
        public int TA { get; set; }
        public string PTA { get; set; }
        public int EH { get; set; }

        public Participacion() { }

        public Participacion(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }

        private void setRegistro(string[] aRegistro)
        {

            detalle = aRegistro[0];
            TV = int.Parse(aRegistro[1]);
            PTV = aRegistro[2];
            TA = int.Parse(aRegistro[3]);
            PTA = aRegistro[4];
            EH = int.Parse(aRegistro[5]);

        }

        internal List<Participacion> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return new List<Participacion>();
            List<Participacion> lstParticipacion = new List<Participacion>();
            foreach(string[] aRegistro in mRegistros)
                lstParticipacion.Add(new Participacion(aRegistro));
   
            return lstParticipacion;
        }
    }
}
