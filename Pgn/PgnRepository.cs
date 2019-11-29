using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

namespace Pgn
{
    public class PgnRepository
    {
        private readonly string _connectionString = @"Server=(localdb)\localJooce;Integrated Security=true";

        public PgnRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> Save(Pgn pgn)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                var parameters = new
                {
                    code = pgn.Code,
                    source = pgn.Source
                };
                var sql = @"
                    INSERT INTO pgn (code, source)
                    SELECT
	                    @code,
	                    @source
                    WHERE NOT EXISTS (
	                    SELECT	
		                    1
	                    FROM
		                    pgn
	                    WHERE
		                    code = @code
                    )

                    SELECT
	                    id Id
                    FROM
	                    pgn
                    WHERE
	                    code = @code
                    ";

                return await conn.ExecuteScalarAsync<int>(new CommandDefinition(sql, parameters));
            }
        }
    }
}
