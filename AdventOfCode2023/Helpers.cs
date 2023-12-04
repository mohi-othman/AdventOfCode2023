using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    public static class Helpers
    {
        public static List<string> ParseToLines(this string input) =>
            input.Split("\n")
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim())                
                .ToList();

        public static string ReadFile(int day, int part)
        {
            var assembly = Assembly.GetCallingAssembly();            
            var fileName = $"{AssemblyName.GetAssemblyName(assembly.Location).Name}.Data.Day{day.ToString("00")}{part.ToString("00")}.txt";
            
            using var stream = assembly.GetManifestResourceStream(fileName);
            if(stream == null)
            {
                throw new Exception($"File {fileName} not found.");
            }
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }


}
