using Dapper;
using Puan.Business.Interfaces.Repositories.Dapper;
using Puan.Business.Models;
using Puan.Infra.Data.Interfaces.Context;
using Puan.Infra.Data.Repositorios.Dapper.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Puan.Infra.Data.Repositorios.Dapper
{
    public class PointTimeRepositoryDap : RepositoryBase<PointTime>, IPointTimeRepositoryDap
    {
        private readonly IContexto _contexto;

        public PointTimeRepositoryDap(IContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public override async Task<PointTime> Add(PointTime pointTime)
        {
            var query = $@"INSERT INTO [TB_POINT_TIME]
                        (
                        [ID_KIND_POINT_TIME],
                        [DT_INCLUSAO],
                        [ST_ATIVO]
                        )
                        VALUES
                        (
                        @ID_KIND_POINT_TIME,
                        @DT_INCLUSAO,
                        @ST_ATIVO
                        )
                        SELECT CAST(SCOPE_IDENTITY() AS INT)
                        ";

            var sParams = new DynamicParameters();
            sParams.Add("@ID_KIND_POINT_TIME", 1);
            sParams.Add("@DT_INCLUSAO", pointTime.Mark);
            sParams.Add("@ST_ATIVO", pointTime.Activated);

            using (var con = _contexto.Connection())
            {
                con.Open();
                var id = await con.ExecuteScalarAsync<int>(query, sParams);
                pointTime.Id = id;
                con.Close();

                return await Task.FromResult(new PointTime());
            }
        }

        public async Task<IEnumerable<PointTime>> GetByType(int id)
        {
            var query = $@"SELECT * FROM [TB_POINT_TIME]
                        WHERE
                        ID_KIND_POINT_TIME = @ID_KIND_POINT_TIME
                        ";

            var sParams = new DynamicParameters();
            sParams.Add("@ID_KIND_POINT_TIME", id);

            using (var con = _contexto.Connection())
            {
                con.Open();
                var resultado = await con.QueryAsync<PointTime>(query, sParams);
                con.Close();

                return resultado;
            }
        }

        public async Task Delete(int id)
        {
            var query = $@"UPDATE [TB_POINT_TIME]
                        SET ST_ATIVO = 0
                        WHERE
                        ID_POINT_TIME = @ID_POINT_TIME
                        ";

            var sParams = new DynamicParameters();
            sParams.Add("@ID_POINT_TIME", id);

            using (var con = _contexto.Connection())
            {
                con.Open();
                var resultado = await con.ExecuteAsync(query, sParams);
                con.Close();
            }
        }

    }
}
