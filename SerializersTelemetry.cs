using System.Text.Json;
using BenchmarkDotNet.Attributes;
using MessagePack;
using MessagePack.Resolvers;

namespace SerializationBenchmarks
{
    public class SerializersTelemetry
    {
        #region General Configuration
        private static string dbFile = "Firebird_PATH";
        private static string connectionString = $"Firebird_connectionString={dbFile}";
        private static string targetFolder = "C:\\Your_Target_Folder";
        private  string query = "SELECT * FROM YourTable"; 
        private List<Dictionary<string, string>> list_items_2_200_000;
        #endregion

        #region MessagePack Configuration
        private static IFormatterResolver formatterResolver = CompositeResolver.Create(
                                                                                            StandardResolver.Instance,
                                                                                            ContractlessStandardResolver.Instance
                                                                                       );
        private MessagePackSerializerOptions messagePackSerializerOptions = MessagePackSerializerOptions.Standard
                                                                                                            .WithResolver(formatterResolver)
                                                                                                            .WithCompression(MessagePackCompression.Lz4BlockArray);

        private string messagePackFile = Path.Combine(targetFolder, "message-msgpck.msgpck");
        #endregion

        #region JSON Configuration
        private JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = false
        };
        private string jsonFile = Path.Combine(targetFolder, "message-json.json");
        #endregion

        public SerializersTelemetry()
        {
            list_items_2_200_000 = new FirebirdHelper(connectionString).QueryAllRecords(query);
        }

        [Benchmark]
        public void SerializeMessagePack()
        {
            var serializedFile = MessagePackSerializer.Serialize(list_items_2_200_000, options: messagePackSerializerOptions);

            File.WriteAllBytes(messagePackFile, serializedFile);
        }

        [Benchmark(Baseline = true)]
        public void SerializeJson()
        {
            var json = JsonSerializer.Serialize(list_items_2_200_000, jsonSerializerOptions);

            File.WriteAllText(jsonFile, json);
        }

    }
}
