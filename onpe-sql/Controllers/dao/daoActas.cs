using onpe_sql.Controllers.bd;
using onpe_sql.Models;

namespace onpe_sql.Controllers.dao
{
    public class daoActas
    {
        private readonly clsBD _db;

        public daoActas(clsBD db)
        {
            _db = db;
        }

        internal ActaDetalle getDetalle(string id)
        {
            _db.Sentencia($"EXEC usp_getGrupoVotacion '{id}'");
            ActaDetalle acta = new();
            acta.setRegistro(_db.getRegistro());
            return acta;
        }

        internal List<GruposVotacion> getGrupos(int id)
        {
            _db.Sentencia($"EXEC usp_getGruposVotacion {id}");
            return new GruposVotacion().getList(_db.getRegistros());
        }
    }
}
