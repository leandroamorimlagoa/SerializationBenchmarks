using FirebirdSql.Data.FirebirdClient;

public class FirebirdHelper
{
    private string _connectionString;

    public FirebirdHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Dictionary<string, string>> QueryAllRecords(string query)
    {
        var result = new List<Dictionary<string, string>>();
        using (var connection = new FbConnection(_connectionString))
        {
            connection.Open();
            using (var command = new FbCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, string>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader[i] == DBNull.Value)
                            {
                                row.Add(reader.GetName(i), null);
                            }
                            else
                            {
                                row.Add(reader.GetName(i), reader[i].ToString());
                            }
                        }
                        result.Add(row);
                    }
                }
            }
        }
        return result;
    }
}