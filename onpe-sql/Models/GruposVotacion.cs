namespace onpe_sql.Models
{
    public class GruposVotacion
    {
        public string id { get; set; }

        public GruposVotacion() { }
        public GruposVotacion(string[] aRegistro) { id = aRegistro[0];  }

        internal List<GruposVotacion> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return new List<GruposVotacion>();
            List<GruposVotacion> lstGrupo = new List<GruposVotacion>();
            foreach (string[] aRegistro in mRegistros)
                lstGrupo.Add(new GruposVotacion(aRegistro));

            return lstGrupo;
        }
    }
    public class ActaDetalle
    {
        public string id { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string razonSocial { get; set; }
        public string direccion { get; set; }
        public int idLocal { get; set; }
        public string nCopia { get; set; }
        public int idEstado { get; set; }
        public int EH { get; set; }
        public int TV { get; set; }
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int VB { get; set; }
        public int VN { get; set; }
        public int VI { get; set; }
        public ActaDetalle() { }
        public ActaDetalle(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }
        internal void setRegistro(string[] aRegistro)
        {
            if(aRegistro == null) return;

            departamento = aRegistro[0];
            provincia = aRegistro[1];
            distrito = aRegistro[2];
            razonSocial = aRegistro[3];
            direccion = aRegistro[4];
            idLocal = int.Parse(aRegistro[5]);
            id = aRegistro[6];
            nCopia = aRegistro[7];
            idEstado = int.Parse(aRegistro[8]);
            EH = int.Parse(aRegistro[9]);
            TV = int.Parse(aRegistro[10]);
            P1 = int.Parse(aRegistro[11]);
            P2 = int.Parse(aRegistro[12]);
            VB = int.Parse(aRegistro[13]);
            VN = int.Parse(aRegistro[14]);
            VI = int.Parse(aRegistro[15]);
        }
        internal List<ActaDetalle> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return [];
            List<ActaDetalle> lstDetalle = new List<ActaDetalle>();
            foreach (string[] aRegistro in mRegistros)
                lstDetalle.Add(new ActaDetalle(aRegistro));
            return lstDetalle;
        }
    }
}
