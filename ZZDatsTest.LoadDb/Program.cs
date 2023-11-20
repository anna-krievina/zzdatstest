using Npgsql;
using System.Net.Http;

string serverConnectionString = "Host=localhost;Username=postgres;Password=parole";
string databaseConnectionString = "Host=localhost;Database=zzdatstestdb;Username=postgres;Password=parole";

executeScript(serverConnectionString, "01_create_db.sql");
executeScript(databaseConnectionString, "02_create_table.sql");
executeScript(databaseConnectionString, "03_insert_data.sql");
executeScript(databaseConnectionString, "04_update_data.sql");
executeScript(databaseConnectionString, "05_execute_update_data.sql");
executeScript(databaseConnectionString, "06_create_materialized_views.sql");
Console.WriteLine("finished");

void executeScript(string connectionString, string scriptFile)
{
    NpgsqlConnection conn = new NpgsqlConnection(connectionString);
    FileInfo file = new FileInfo($"Scripts/{scriptFile}");
    string script = file.OpenText().ReadToEnd();
    var createdb_cmd = new NpgsqlCommand(script, conn);
    conn.Open();
    createdb_cmd.ExecuteNonQuery();
    conn.Close();
}