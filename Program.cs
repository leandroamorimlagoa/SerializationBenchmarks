using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace SerializationBenchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializersTelemetry>(
                DefaultConfig.Instance
                    .AddDiagnoser(MemoryDiagnoser.Default)
                    .WithOptions(ConfigOptions.DisableOptimizationsValidator));

            // If you want just create the files, you can use the code below
            //var serializers = new SerializersTelemetry();
            //serializers.SerializeMessagePack();
            //serializers.SerializeJson();
        }

    }
}
