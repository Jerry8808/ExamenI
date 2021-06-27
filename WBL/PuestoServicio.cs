using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IPuestoServicio
    {
        Task<DBEntity> Create(PuestoEntity entity);
        Task<DBEntity> Delete(PuestoEntity entity);
        Task<IEnumerable<PuestoEntity>> Get();
        Task<PuestoEntity> GetById(PuestoEntity entity);
        Task<DBEntity> Update(PuestoEntity entity);
    }

    public class PuestoServicio : IPuestoServicio
    {
        private readonly IDataAccess sql;

        public PuestoServicio(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<PuestoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<PuestoEntity>(sp: "PuestoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PuestoEntity> GetById(PuestoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<PuestoEntity>(sp: "PuestoObtener", Param: new
                {
                    entity.Id_Puesto
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(PuestoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "PuestoInsertar", Param: new
                {
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(PuestoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "PuestoActualizar", Param: new
                {
                    entity.Id_Puesto,
                    entity.Nombre,
                    entity.Salario,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(PuestoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "PuestoEliminar", Param: new
                {
                    entity.Id_Puesto
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
