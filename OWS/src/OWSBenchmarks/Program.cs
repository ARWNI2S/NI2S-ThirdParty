using BenchmarkDotNet.Running;

namespace OWSBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ResponseBenchmarks>();
        }
    }
}
