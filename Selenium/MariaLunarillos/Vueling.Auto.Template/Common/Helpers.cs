using System;
using System.Linq;
using System.Text;

namespace MariaLunarillos.Selenium.Common
{
    class Helpers
    {
        private static Random random = new Random();
        public const string CORRESPONDENCIA = "TRWAGMYFPDXBNJZSQVHLCKE";
        public const string Test = "TEST";

        public static char GetRandomLetter()
        {
            string seats = "ABCDEF";
            Random random = new Random();
            int num = random.Next(0, seats.Length - 1);
            return seats[num];
        }

        public static int GetRandomDay()
        {
            Random random = new Random();
            int randomDay = random.Next(1, 31);
            return randomDay;
        }

        public static string GetRandomString(int length)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            var chars = Enumerable.Range(0, length)
                .Select(x => letters[random.Next(0, letters.Length)]);
            return new string(chars.ToArray());
        }

        public static char GetNifLetter(string dni)
        {
            int n;

            if ((dni == null) || (!int.TryParse(dni.Substring(0, 8), out n)))
            {
                throw new ArgumentException("Dni should be 8 digits");
            }

            return CORRESPONDENCIA[n % 23];
        }

        public static string GetRandomDniDigits()
        {
            const string digits = "0123456789";
            Random random = new Random();
            var chars = Enumerable.Range(0, 8)
                .Select(x => digits[random.Next(0, digits.Length)]);
            return new string(chars.ToArray());
        }

        public static string GetRandomDni()
        {
            string dniDigits = GetRandomDniDigits();
            char dniLetter = GetNifLetter(dniDigits);
            string dni = dniDigits + dniLetter.ToString();
            return dni;
        }

        public static int GetRandomNumberBetween(int start, int end)
        {
            Random random = new Random();
            int randomNumber = random.Next(start, end);
            return randomNumber;
        }

        public static int GetRandomPhoneNumber()
        {
            Random random = new Random();
            int randomPhoneNumber = random.Next(100000000, 999999999);
            return randomPhoneNumber;
        }

        public static String GetRandomDate()
        {
            Random random = new Random();
            DateTime start = new DateTime(1900, 1, 1);
            int range = (DateTime.Today - start).Days;
            DateTime randomDate = start.AddDays(random.Next(range));
            return randomDate.ToString("yyyy-MM-dd");
        }

        public static string GetRandomFirstName()
        {
            string[] firstNames = {
                "John", "Jane", "Mike", "Emily", "Alex",
                "Oliver", "Sophia", "William", "Emma", "Liam",
                "Ava", "James", "Mia", "Benjamin", "Charlotte",
                "Lucas", "Amelia", "Henry", "Harper", "Alexander",
                "Evelyn", "Daniel", "Abigail", "Matthew", "Elizabeth",
                "Michael", "Sofia", "David", "Grace", "Joseph",
                "Chloe", "Samuel", "Ella", "Jacob", "Victoria"
            };
            return firstNames[random.Next(firstNames.Length)];
        }

        public static string GetRandomLastName()
        {
            string[] lastNames = { 
                "Smith", "Johnson", "Williams", "Brown", "Jones",
                "Davis", "Miller", "Wilson", "Moore", "Taylor",
                "Anderson", "Thomas", "Jackson", "White", "Harris",
                "Clark", "Lewis", "Walker", "Hall", "Young",
                "Allen", "King", "Wright", "Scott", "Turner",
                "Parker", "Collins", "Cook", "Murphy", "Rogers" 
            };
            return lastNames[random.Next(lastNames.Length)];
        }

        public static string GetRandomFullName()
        {
            return GetRandomFirstName() + " " + GetRandomLastName();
        }

        public static string GetRandomMail()
        {
            return GetRandomFirstName().ToLower() + "@mailinator.com";
        }

        public static string GetRandomPassword(int length)
        {
            string AvailableCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
            
            StringBuilder passwordBuilder = new StringBuilder();
            
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(AvailableCharacters.Length);
                char randomCharacter = AvailableCharacters[randomIndex];
                passwordBuilder.Append(randomCharacter);
            }

            return passwordBuilder.ToString();

        }
        public static string GetRandomCityName()
        {
            string[] cityNames = {
                "Seattle", "Denver", "Portland", "Austin", "Atlanta",
                "Sacramento", "Nashville", "Raleigh", "Tucson", "Charlotte",
                "Albuquerque", "Omaha", "Memphis", "Boise", "Milwaukee",
                "Reno", "Spokane", "Tulsa"
            };
            return cityNames[random.Next(cityNames.Length)];
        }

        public static string GetRandomAddress()
        {

            string[] streets = {
                "Main Street", "First Avenue", "Oak Street", "Elm Avenue", "Maple Drive",
                "Cedar Lane", "Pine Street", "Birch Avenue", "Willow Drive", "Spruce Lane"
            };

            return GetRandomCityName()+", "+streets[random.Next(streets.Length)]+", "+GetRandomNumberBetween(1,300);
        }
        public static string GetRandomPostalCode()
        {
            return ""+random.Next(10)+ random.Next(10)+ random.Next(10)+ random.Next(10)+ random.Next(10);
        }

        public static string GetRandomNumberVer2()
        {
            return "" + random.Next(10) + random.Next(10) + random.Next(10) + random.Next(10) + random.Next(10)+ random.Next(10)+ random.Next(10)+ random.Next(10) + random.Next(10);
        }
    }
}
