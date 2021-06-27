using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface IDepartamentoServicio
    {
        Task<DBEntity> Create(DepartamentoEntity entity);
        Task<DBEntity> Delete(DepartamentoEntity entity);
        Task<IEnumerable<DepartamentoEntity>> Get();
        Task<DepartamentoEntity> GetById(DepartamentoEntity entity);
        Task<DBEntity> Update(DepartamentoEntity entity);
    }

    public class DepartamentoServicio : IDepartamentoServicio
    {
        private readonly IDataAccess sql;

        public DepartamentoServicio(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<IEnumerable<DepartamentoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<DepartamentoEntity>(sp: "DepartamentoObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DepartamentoEntity> GetById(DepartamentoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<DepartamentoEntity>(sp: "DepartamentoObtener", Param: new
                {
                    entity.Id_Departamento
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Create(DepartamentoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "DepartamentoInsertar", Param: new
                {
                    entity.Ubicacion,
                    entity.Descripcion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Update(DepartamentoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "DepartamentoActualizar", Param: new
                {
                    entity.Id_Departamento,
                    entity.Descripcion,
                    entity.Ubicacion,
                    entity.Estado
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<DBEntity> Delete(DepartamentoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "DepartamentoEliminar", Param: new
                {
                    entity.Id_Departamento
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
