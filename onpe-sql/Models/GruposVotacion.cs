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
}
