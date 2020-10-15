using App.Common.SeedWork;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Queries
{
    public class GetNotificationsByUserQueryHandler
    {
        public class Query : IRequest<IEnumerable<GetNotificationsByUserViewModel>>
        {
            public Query(Guid idUser)
            {
                IdUser = idUser;
            }

            public Guid IdUser { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<GetNotificationsByUserViewModel>>
        {
            private CommonGlobalAppSingleSettings _commonGlobalAppSingleSettings;

            public Handler(CommonGlobalAppSingleSettings commonGlobalAppSingleSettings)
            {
                _commonGlobalAppSingleSettings = commonGlobalAppSingleSettings;
            }

            public async Task<IEnumerable<GetNotificationsByUserViewModel>> Handle(
                Query query,
                CancellationToken cancellationToken)
            {
                using (IDbConnection conn = new SqlConnection(_commonGlobalAppSingleSettings.MssqlConnectionString))
                {
                    string sql =
                        @"
                        SELECT 
	                        unt.Id as IdNotification, nt.Name as NotificationName, unt.Active
                        FROM 
	                        NotificationTypes nt INNER JOIN UserNotificationTypes unt
		                        ON nt.Id = unt.IdNotificationType
		                WHERE unt.IdUser = @IdUser";

                    var result = await conn.QueryAsync<GetNotificationsByUserViewModel>(sql, new { IdUser = query.IdUser });

                    return result;
                }
            }
        }
    }
}
