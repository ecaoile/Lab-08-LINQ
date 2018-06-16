using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Lab_08_LINQ.Classes;

namespace Lab_08_LINQ
{
    /// <summary>
    /// The main program class that launches the console app
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../data.json";
            FeaturesCollection myFeatures = LoadJson(filePath);
            Console.WriteLine("\n1. Output all of the neighborhoods in this data list");
            ShowAllNeighborhoods(myFeatures);
            Console.WriteLine("\nPress a key for the next list.");
            Console.ReadKey();

            Console.WriteLine("\n2. Filter out all the neighborhoods that do not have any names");
            FilterOutNulls(myFeatures);
            Console.WriteLine("\nPress a key for the next list.");
            Console.ReadKey();

            Console.WriteLine("\n3. Remove the Duplicates");
            FilterOutDuplicates(myFeatures);
            Console.WriteLine("\nPress a key for the next list.");
            Console.ReadKey();

            Console.WriteLine("\n4. Rewrite the queries from above, and consolidate all into one single query.");
            FilterOutDuplicatesPlusNulls(myFeatures);
            Console.WriteLine("\nPress a key for the next list.");
            Console.ReadKey();

            Console.WriteLine("\n5. Rewrite at least one of these questions only using a LINQ query (without lambda statement)");
            FilterComboNoLambda(myFeatures);

            Console.WriteLine("\nThank you for playing! Press any button to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// loads the JSON file and saves it to an object
        /// </summary>
        /// <param name="filePath">the file path to the JSON file</param>
        /// <returns></returns>
        public static FeaturesCollection LoadJson(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                FeaturesCollection myFeatures = JsonConvert.DeserializeObject<FeaturesCollection>(json);
                return myFeatures;
            }
        }

        /// <summary>
        /// displays all of the neighborhoods from an object
        /// </summary>
        /// <param name="myFeatures">the object from which to display all neighborhoods</param>
        public static void ShowAllNeighborhoods(FeaturesCollection myFeatures)
        {
            var results = from i in myFeatures.Features
                          select i.Properties.Neighborhood;
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// filter out nulls from an object
        /// </summary>
        /// <param name="myFeatures">the object from which to filter nulls</param>
        public static void FilterOutNulls(FeaturesCollection myFeatures)
        {
            var results = from i in myFeatures.Features
                          where i.Properties.Neighborhood != ""
                          select i.Properties.Neighborhood;
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// filters out duplicates from an object
        /// </summary>
        /// <param name="myFeatures">the object from which to filter out duplicates</param>
        public static void FilterOutDuplicates(FeaturesCollection myFeatures)
        {
            var results = from i in myFeatures.Features
                          group i.Properties.Neighborhood by i.Properties.Neighborhood
                          into uniqueHoods
                          select uniqueHoods.Key;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// shows a list without duplicates or nulls
        /// </summary>
        /// <param name="myFeatures">The object to filter</param>
        public static void FilterOutDuplicatesPlusNulls(FeaturesCollection myFeatures)
        {
            var results = myFeatures.Features.Where(x => x.Properties.Neighborhood != "")
                                .GroupBy(g => g.Properties.Neighborhood)
                                .Select(y => y.Key);

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// does the above filteres without lambda statements
        /// </summary>
        /// <param name="myFeatures"></param>
        public static void FilterComboNoLambda(FeaturesCollection myFeatures)
        {
            var results = from i in myFeatures.Features
                          where i.Properties.Neighborhood != ""
                          group i.Properties.Neighborhood by i.Properties.Neighborhood
                          into filteredNeighborhoods
                          select filteredNeighborhoods.Key;

            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
        }
    }
}
