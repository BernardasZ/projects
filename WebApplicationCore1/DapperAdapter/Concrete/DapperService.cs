using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataModels.Models;
using Microsoft.Extensions.Configuration;
using Z.Dapper.Plus;

namespace DapperAdapter.Concrete
{
    public class DapperService : IDapperService
    {
        private readonly IConfiguration _configuration;
        public DapperService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void Update<T, U>(string procedureName, U param) where T : class
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("IgnitisDB")))
            {
                db.Query<T>(
                        procedureName,
                        param,
                        null,
                        true,
                        null,
                        CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> SelectList<T, U>(string procedureName, U regPozId) where T : class
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("IgnitisDB")))
            {
                return db
                    .Query<T>(
                        procedureName,
                        regPozId, 
                        null, 
                        true, 
                        null, 
                        CommandType.StoredProcedure);
            }
        }

        public void UpdateList<T>(List<T> listEntities) where T : class
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("IgnitisDB")))
            {
                db.BulkUpdate(listEntities);
            }
        }
	}
}
