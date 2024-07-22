// small note - sometimes it is worth returning type as a span instead of a string, especially when you are going to use it in a method that will be called multiple times.`
// The user of the function can convert to strin gas needed but of course can furhter use spane to pick out details.

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace NCSpanExplianed
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchy>();
        }
             

        [MemoryDiagnoser]
        public class Benchy
        {
            private static readonly string _dateAsText = "08 07 2021";

            [Benchmark]
            public (int day, int month, int year) DateWithStringAndSpan()
            {
                ReadOnlySpan<char> dateAsSpan = _dateAsText;//.AsSpan();
                var dayAsText = dateAsSpan.Slice(0, 2);
                var monthAsText = dateAsSpan.Slice(3, 2);
                var yearAsText = dateAsSpan.Slice(6);

                var day = int.Parse(dayAsText);
                var month = int.Parse(monthAsText);
                var year = int.Parse(yearAsText);

                return (day, month, year);
            }

            [Benchmark]
            public (int day, int month, int year) DateWithStringAndSubstring()
            {
                var dayAsText = _dateAsText.Substring(0, 2);
                var monthAsText = _dateAsText.Substring(3, 2);
                var yearAsText = _dateAsText.Substring(6);

                var day = int.Parse(dayAsText);
                var month = int.Parse(monthAsText);
                var year = int.Parse(yearAsText);

                return (day, month, year);
            }
        }
    }
}
