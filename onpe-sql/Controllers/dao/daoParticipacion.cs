using onpe_sql.Controllers.bd;
using onpe_sql.Models;

namespace onpe_sql.Controllers.dao
{
    public class daoParticipacion
    {
        private readonly clsBD _db;

        public daoParticipacion(clsBD db)
        {
            _db = db;
        }
        internal List<Participacion> getVerParticipaciones(int inicio, int fin)
        {
            _db.Sentencia($"EXEC usp_getVotos {inicio}, {fin}");
            return new Participacion().getList(_db.getRegistros());
        }

        internal List<Participacion> getVerDepartamento(string detalle)
        {
            _db.Sentencia($"EXEC usp_getVotosDepartamento {detalle}");
            return new Participacion().getList(_db.getRegistros());
        }

        internal List<Participacion> getVerProvincia(string detalle)
        {
            _db.Sentencia($"EXEC usp_getVotosProvincia {detalle}");
            return new Participacion().getList(_db.getRegistros());
        }
    }
}

