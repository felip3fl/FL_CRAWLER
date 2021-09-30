using Dapper;
using Puan.Business.Interfaces.Repositories.Dapper;
using Puan.Infra.Data.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Repositorios.Dapper.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly IContexto _contexto;
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var type = typeof(T);
            var tabela = GetTableName(type);

            string query = $"SELECT * FROM {tabela}";

            using (var cn = _contexto.Connection())
            {
                try
                {
                    cn.Open();
                    var obj = await cn.QueryAsync<T>(query);
                    cn.Close();
                    return obj;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public RepositoryBase(IContexto contexto)
        {
            _contexto = contexto;
        }

        public async virtual Task<T> Add(T obj)
        {
            return await Task.FromResult<T>(null);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(long id)
        {
            var type = typeof(T);
            var tabela = GetTableName(type);

            string where = $"WHERE {GetPrimaryKey(type)} = {id}";

            string query = $"SELECT * FROM {tabela} {where}";

            using (var cn = _contexto.Connection())
            {
                try
                {
                    cn.Open();
                    var obj = await cn.QueryAsync<T>(query);
                    cn.Close();
                    return obj.FirstOrDefault();
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        public async virtual Task<T> Update(T obj)
        {
            return await Task.FromResult<T>(null);
        }

        private static string GetTableName(Type type)
        {
            dynamic tableattr = type.GetCustomAttributes(false).SingleOrDefault(attr => attr.GetType().Name == "TableAttribute");
            var name = string.Empty;

            if (tableattr != null)
                name = tableattr.Name;

            return name;
        }

        private static string GetPrimaryKey(Type type)
        {
            string name = string.Empty;
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(type);

            foreach(PropertyDescriptor property in properties)
                return property.DisplayName;

            return null;
        }
    }
}
