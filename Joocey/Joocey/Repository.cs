using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using Core;

namespace Joocey
{
    public class Repository
    {
        private readonly string _connectionString = @"Server=(localdb)\localJooce;Integrated Security=true";

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task SaveEvaluation(int pgnId, EvaluationType type, IEnumerable<Evaluation> eval)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                var parameters = new
                {
                    pgnId,
                    evalType = type
                };

                await conn.ExecuteAsync(
                    @"CREATE TABLE #tmp (
                        pgn_id int,
	                    side tinyint,
	                    depth int,
	                    move_number int,
	                    fen varchar(86),
	                    engine_move varchar(8),
	                    engine_score int,
	                    engine_mate_in int,
	                    engine_variation varchar(1024),
	                    eval_move varchar(8),
	                    eval_score int,
	                    eval_mate_in int,
	                    eval_variation varchar(1024),
                        eval_type_id tinyint
                    )");

                using (var bc = new SqlBulkCopy(conn))
                {
                    bc.ColumnMappings.Add("EvaluatingSide", "side");
                    bc.ColumnMappings.Add("Depth", "depth");
                    bc.ColumnMappings.Add("MoveNumber", "move_number");
                    bc.ColumnMappings.Add("Fen", "fen");
                    bc.ColumnMappings.Add("EngineMove", "engine_move");
                    bc.ColumnMappings.Add("EngineScore", "engine_score");
                    bc.ColumnMappings.Add("EngineMateIn", "engine_mate_in");
                    bc.ColumnMappings.Add("EngineVariation", "engine_variation");
                    bc.ColumnMappings.Add("EvaluationMove", "eval_move");
                    bc.ColumnMappings.Add("EvaluationScore", "eval_score");
                    bc.ColumnMappings.Add("EvaluationMateIn", "eval_mate_in");
                    bc.ColumnMappings.Add("EvaluationVariation", "eval_variation");

                    bc.DestinationTableName = "#tmp";
                    await bc.WriteToServerAsync(new GenericListDataReader<Evaluation>(eval));
                    await conn.ExecuteAsync("UPDATE #tmp SET pgn_id = @pgnId, eval_type_id = @evalType", parameters);
                }
                var sql = @"
                    UPDATE evaluation 
                    SET
	                    depth = tmp.depth,
	                    move_number = tmp.move_number,
	                    fen = tmp.fen,
	                    engine_move = tmp.engine_move,
	                    engine_score = tmp.engine_score,
	                    engine_mate_in = tmp.engine_mate_in,
	                    engine_variation = tmp.engine_variation,
	                    eval_move = tmp.eval_move,
	                    eval_score = tmp.eval_score,
	                    eval_mate_in = tmp.eval_mate_in,
	                    eval_variation = tmp.eval_variation
                    FROM
                        evaluation e
                        INNER JOIN #tmp tmp
                            ON(e.pgn_id = tmp.pgn_id
                                AND e.side = tmp.side
                                AND e.move_number = tmp.move_number
                                AND e.eval_type_id = tmp.eval_type_id)
   
                    INSERT INTO evaluation (
                        pgn_id,
	                    side,
	                    depth,
	                    move_number,
	                    fen,
	                    engine_move,
	                    engine_score,
	                    engine_mate_in,
	                    engine_variation,
	                    eval_move,
	                    eval_score,
	                    eval_mate_in,
	                    eval_variation,
                        eval_type_id 
                     )
                     SELECT
                        pgn_id,
	                    side,
	                    depth,
	                    move_number,
	                    fen,
	                    engine_move,
	                    engine_score,
	                    engine_mate_in,
	                    engine_variation,
	                    eval_move,
	                    eval_score,
	                    eval_mate_in,
	                    eval_variation,
                        eval_type_id 
                    FROM
                        #tmp tmp
                    WHERE NOT EXISTS (
                        SELECT
                            1
                        FROM
                            evaluation
                        WHERE
                            pgn_id = tmp.pgn_id
                            AND side = tmp.side
                            AND move_number = tmp.move_number
                            AND eval_type_id = tmp.eval_type_id
					)";
                await conn.ExecuteAsync(new CommandDefinition(sql, parameters));
            }
        }
    }
}
