using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;

namespace WBL
{
    public interface ITituloServicio
    {
        Task<DBEntity> Create(TituloEntity entity);
        Task<DBEntity> Delete(TituloEntity entity);
        Task<IEnumerable<TituloEntity>> Get();
        Task<TituloEntity> GetById(TituloEntity entity);
        Task<DBEntity> Update(TituloEntity entity);
    }

    public class TituloServicio : ITituloServicio
    {
        private readonly IDataAccess sql;

        public TituloServicio(IDataAccess _sql)
        {
            sql = _sql;
        }
        //Metodo de Obtencion de datos en general
        public async Task<IEnumerable<TituloEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<TituloEntity>(sp: "TituloObtener");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Metodo de obtencion de datos por Filtro
        public async Task<TituloEntity> GetById(TituloEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<TituloEntity>(sp: "TituloObtener", Param: new
                {
                    entity.Id_Titulo
                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Metodo de agregar un nuevo registro a la base de datos
        public async Task<DBEntity> Create(TituloEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "TituloInsertar", Param: new
                {
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
        //Metodo de actualizacion de un registro en la base de datos
        public async Task<DBEntity> Update(TituloEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "TituloActualizar", Param: new
                {
                    entity.Id_Titulo,
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
        //Metodo de Eliminacion de un registro
        public async Task<DBEntity> Delete(TituloEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "TituloEliminar", Param: new
                {
                    entity.Id_Titulo
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
