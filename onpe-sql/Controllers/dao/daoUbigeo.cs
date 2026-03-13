using onpe_sql.Controllers.bd;
using onpe_sql.Models;

namespace onpe_sql.Controllers.dao
{
    public class daoUbigeo
    {
        private readonly clsBD _db;

        public daoUbigeo(clsBD db)
        {
            _db = db;
        }

        internal List<Ubigeo> getDepartamentos(int inicio, int fin)
        {
            _db.Sentencia($"EXEC usp_getDepartamentos {inicio}, {fin}");
            return new Ubigeo().getList(_db.getRegistros());
        }
        internal List<Ubigeo> getProvincias(int id)
        {
            _db.Sentencia($"EXEC usp_getProvincias {id}");
            return new Ubigeo().getList(_db.getRegistros());
        }
        internal List<Ubigeo> getDistritos(int id)
        {
            _db.Sentencia($"EXEC usp_getDistritos {id}");
            return new Ubigeo().getList(_db.getRegistros());
        }
        internal List<Ubigeo> getLocales(int id)
        {
            _db.Sentencia($"EXEC usp_getLocalesVotacion {id}");
            return new Ubigeo().getList(_db.getRegistros());
        }
    }
}
