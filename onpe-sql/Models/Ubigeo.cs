namespace onpe_sql.Models
{
    public class Ubigeo
    {
        public int id { get; set; }
        public string detalle { get; set; }

        public Ubigeo() { }

        public Ubigeo(string[] aRegistro)
        {
            setRegistro(aRegistro);
        }

        internal void setRegistro(string[] aRegistro)
        {
            id = int.Parse(aRegistro[0]);
            detalle = aRegistro[1];

        }

        internal List<Ubigeo> getList(string[][] mRegistros)
        {
            if (mRegistros == null) return new List<Ubigeo>();
            List<Ubigeo> lstUbigeo = new List<Ubigeo>();
            foreach (string[] aRegistro in mRegistros)
                lstUbigeo.Add(new Ubigeo(aRegistro));

            return lstUbigeo;
        }
    }
}
