using Dapper;
using System;
using System.Data.SqlClient;

namespace DevOpsTechChallenge.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly string _connectionString;

        public TestRepository(string connectionString)
        {
            _connectionString = connectionString;
            InitialiseDatabase();
        }

        private void InitialiseDatabase()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    var rows = conn.Execute(@"if not exists (select * from sys.tables where [name] = 'Test')
                                            Begin
                                                CREATE TABLE Test (
                                                Id int not null,
                                                Test nvarchar(max) null
                                                )
                                                Insert Into Test (Id, Test) Values (1 , 'Testing 123')
                                            End");

                }
            }
            catch { }
        }

        public string GetTest()
        {
            var result = string.Empty;
            using (var conn = new SqlConnection(_connectionString))
            {
                result = conn.ExecuteScalar<string>("Select Test from Test where Id = 1");
            }
            return result;
        }
        public void SetTest(string testValue)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var rows = conn.Execute(@"Update Test Set Test = @Test Where Id  = 1", new { @Test = testValue });
            }
        }
    }
}
