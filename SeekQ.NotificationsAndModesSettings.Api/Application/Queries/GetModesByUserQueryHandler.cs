using App.Common.SeedWork;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Queries
{
    public class GetModesByUserQueryHandler
    {
        public class Query : IRequest<IEnumerable<GetModesByUserViewModel>>
        {
            public Query(Guid idUser)
            {
                IdUser = idUser;
            }

            public Guid IdUser { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<GetModesByUserViewModel>>
        {
            private CommonGlobalAppSingleSettings _commonGlobalAppSingleSettings;

            public Handler(CommonGlobalAppSingleSettings commonGlobalAppSingleSettings)
            {
                _commonGlobalAppSingleSettings = commonGlobalAppSingleSettings;
            }

            public async Task<IEnumerable<GetModesByUserViewModel>> Handle(
                Query query,
                CancellationToken cancellationToken)
            {
                using (IDbConnection conn = new SqlConnection(_commonGlobalAppSingleSettings.MssqlConnectionString))
                {
                    string sql =
                        @"
                        SELECT 
	                        umt.Id as IdMode, mt.Name as NotificationName, umt.Active
                        FROM 
	                        ModeTypes mt INNER JOIN UserModeTypes umt
		                        ON mt.Id = umt.IdModeType
		                WHERE umt.IdUser = @IdUser";

                    var result = await conn.QueryAsync<GetModesByUserViewModel>(sql, new { IdUser = query.IdUser });

                    return result;
                }
            }
        }
    }
}
