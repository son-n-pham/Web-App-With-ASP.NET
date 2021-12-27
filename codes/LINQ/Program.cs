using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProgrammingLanguages
{
    class Program
    {
        static void Main()
        {
            List<Language> languages = File.ReadAllLines("./languages.tsv")
                .Skip(1)
                .Select(line => Language.FromTsv(line))
                .ToList();

            foreach (Language item in languages)
            {
                Console.WriteLine(item.Prettify());
            }

            
            // Simple LINQ query to select all languages and export out into strings with a specific format
            var languageQuery = languages
                .Select(l => $"{l.Name} was created in year {l.Year} by {l.ChiefDeveloper}");

            foreach (string lang in languageQuery)
            {
                Console.WriteLine(lang);
            }


            // Query languages containing "C#". Since h is Language object, h.Name gives the name as string which we then can check if it contains "C#"
            var languageCSharp = languages
                .Where(h => h.Name.Contains("C#"));
            
            foreach (Language item in languageCSharp)
            {
                Console.WriteLine(item.Prettify());
            }


            // Query languages invented by Microsoft
            var languageMicrosoft = from language in languages
                where language.ChiefDeveloper.Contains("Microsoft")
                select language;

            foreach (Language item in languageMicrosoft)
            {
                Console.WriteLine(item.Prettify());
            }


            // How many languages are in the list
            Console.WriteLine($"There are {languages.Count()} languages in the list.");


            // Find how many languages launched between 1995 and 2005
            var languagePeriod = languages
                .Where(l => (l.Year>=1995) && (l.Year<=2005));

            int langCount = languagePeriod.Count();
            Console.WriteLine($"There are {langCount} languages invented between 1995 and 2005");
        }

        public void PrettyPrintAll(IEnumerable<Language> languages)
        {
            foreach (Language language in languages)
            {
                Console.WriteLine(language.Prettify());
            }
        }
    }

}
