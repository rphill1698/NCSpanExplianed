
namespace NCSpanExplianed
{
    internal class Program
    {
        private static readonly string _dateAsText = "08 07 2021";
        static void Main(string[] args)
        {
            var date = DateWithStringAndSubsctring();
            Console.WriteLine(date);
        }

        private static (int day, int month, int year) DateWithStringAndSubsctring()
        {
            var dayAsText = _dateAsText.Substring(0, 2);
            var monthAsText = _dateAsText.Substring(3, 2);
            var yearAsText = _dateAsText.Substring(6);

            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);

            return (day, month, year);

            //return (8, 7, 2021);
        }
    }
}
