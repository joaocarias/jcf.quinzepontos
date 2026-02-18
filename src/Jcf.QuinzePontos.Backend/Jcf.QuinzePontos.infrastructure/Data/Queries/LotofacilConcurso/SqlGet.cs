namespace Jcf.QuinzePontos.infrastructure.Data.Queries.LotofacilConcurso
{
    public static class SqlGet
    {
        public const string _LAST_ = @"
                                SELECT * FROM loto_facil.""Concursos""
                                ORDER BY ""Numero"" DESC
                                LIMIT 1;

                                SELECT * FROM loto_facil.""Dezenas""
                                WHERE ""LotofacilConcursoId"" = (
                                    SELECT ""Id"" FROM loto_facil.""Concursos""
                                    ORDER BY ""Numero"" DESC
                                    LIMIT 1
                                );

                                SELECT * FROM loto_facil.""Rateios""
                                WHERE ""LotofacilConcursoId"" = (
                                    SELECT ""Id"" FROM loto_facil.""Concursos""
                                    ORDER BY ""Numero"" DESC
                                    LIMIT 1
                                );

                                SELECT * FROM loto_facil.""GanhadoresUF""
                                WHERE ""LotofacilConcursoId"" = (
                                    SELECT ""Id"" FROM loto_facil.""Concursos""
                                    ORDER BY ""Numero"" DESC
                                    LIMIT 1
                                );
                            ";
    }
}
