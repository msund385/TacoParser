using System;
using System.Reflection.Metadata.Ecma335;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            if (line == null)
            {
                logger.LogWarning("Line was null");

                return null;
            }
            

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3 || cells.Length > 3)
            {
                logger.LogError("Array length is less than 3", new System.Exception());
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            var lat = cells[0];
            // grab the longitude from your array at index 1
            var lon = cells[1];
            // grab the name from your array at index 2
            var name = cells[2];

            Console.WriteLine("Latitude:" + (lat));
            Console.WriteLine("Longitude:" + (lon));
            Console.WriteLine("Name:"+ (name));


            // Your going to need to parse your string as a `double`
            var doublelot = double.Parse(lat);
            var doublelon = double.Parse(lon);
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            TacoBell tacobell = new TacoBell();
            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var point = new Point();
            point.Latitude = doublelot;
            point.Longitude = doublelon;
            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacoBell;
        }
    }
}