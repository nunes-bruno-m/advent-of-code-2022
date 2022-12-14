using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days.Shared
{
    public class DataLoader
    {
        public IEnumerable<string> LoadInputs(int day, TypeOfInput typeOfInput)
        {
            var path = $"Day{day}/{typeOfInput.ToString()}.txt";
            return File.ReadLines(path);
        }
    }
}
