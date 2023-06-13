using Common.Models;

namespace CRUD.ActionsTests
{
    public static class PresetTestData
    {
        private static readonly List<Guid> guidsManufacturers = new()
        {
            new Guid("2796CE7B-1299-4CCC-8C23-2F57411D59D5"),
            new Guid("0A41AAA0-C1B0-407A-B1F9-A4EC26C41EE8"),
            new Guid("6C09C877-20B9-4478-AB41-DB487DD1EF53")
        };

        private static readonly List<string> VINCodes = new()
        {
            "0234567890",
            "1987654321",
            "2098765432"
        };

        public static List<Person> GetPersons()
        {
            return new()
            {
                new Person {Id = 1, Name = "John Doe", Rating = 4.5f, },
                new Person {Id = 2, Name = "Jane Smith", Rating = 3.8f },
                new Person {Id = 3, Name = "Peter Parker", Rating = 5.0f }
            };
        }

        public static List<Car> GetCars()
        {
            return new()
            {
                new Car { VINCode = VINCodes[0], Name = "Focus", ManufacturerGuid = guidsManufacturers[0], PersonId = 1},
                new Car { VINCode = VINCodes[1], Name = "Mondeo", ManufacturerGuid = guidsManufacturers[1]},
                new Car { VINCode = VINCodes[2], Name = "Avensis", ManufacturerGuid = guidsManufacturers[2], PersonId = 3}
            };
        }

        public static List<Manufacturer> GetManufacturers()
        {

            return new()
            {
                new Manufacturer { Guid = guidsManufacturers[0], Name = "Ford", Description = "Description0" },
                new Manufacturer { Guid = guidsManufacturers[1], Name = "Ford", Description = "Description1" },
                new Manufacturer { Guid = guidsManufacturers[2], Name = "Toyota", Description = "Description2" },
            };
        }
    }
}
