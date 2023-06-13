using Common.Models;
using CRUD.Actions.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRUD.ActionsTests.Implementation
{
    [TestClass()]
    public class BaseCRUDRepositoryTests
    {
        private TestDbContext Context => new();

        private BaseCrudRepository<Person, long> PersonRepository => new(new TestDbContext());
        private BaseCrudRepository<Car, string> CarsRepository => new(new TestDbContext());
        private BaseCrudRepository<Manufacturer, Guid> ManufacturersRepository => new(new TestDbContext());


        [TestMethod()]
        public async Task CreateTestAsync()
        {
            Assert.IsTrue(Context.People.ToList().Count == 0);
            Assert.IsTrue(Context.Cars.ToList().Count == 0);
            Assert.IsTrue(Context.Manufacturers.ToList().Count == 0);

            ///
            var manufacturer = PresetTestData.GetManufacturers();
            await ManufacturersRepository.Create(manufacturer.ToArray());

            Assert.AreEqual(manufacturer.Count, Context.Manufacturers.ToArray().Count());

            ///
            var persons = PresetTestData.GetPersons();
            await PersonRepository.Create(persons.ToArray());

            Assert.AreEqual(persons.Count, Context.People.AsNoTracking().ToArray().Count());

            ///
            var cars = PresetTestData.GetCars();
            await CarsRepository.Create(cars.ToArray());

            Assert.AreEqual(persons.Count, Context.Cars.AsNoTracking().ToArray().Count());
        }

        [TestMethod()]
        public async Task ReadRange()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            ///
            var manufacturers = PresetTestData.GetManufacturers();
            await ManufacturersRepository.Create(manufacturers.ToArray());

            var receivedManufacturers = await ManufacturersRepository.Read();
            Assert.AreEqual(manufacturers.Count, Context.Manufacturers.ToArray().Count());
            Assert.AreEqual(manufacturers.Count, receivedManufacturers.Count());

            var manufacturer = await Context.Manufacturers.FirstOrDefaultAsync(i => i.Guid == receivedManufacturers[1].Guid);
            Assert.AreEqual(manufacturer.Name, receivedManufacturers[1].Name);
            Assert.AreEqual(manufacturer.Description, receivedManufacturers[1].Description);

            var expectedFirstManufactured = manufacturers.Where(i => i.Guid == receivedManufacturers[1].Guid).First();
            Assert.AreEqual(expectedFirstManufactured.Name, receivedManufacturers[1].Name);
            Assert.AreEqual(expectedFirstManufactured.Description, receivedManufacturers[1].Description);

            var includedManufacturer = await ManufacturersRepository.ReadFirst(m => m.Guid == receivedManufacturers[1].Guid);
            Assert.AreEqual(includedManufacturer.Name, receivedManufacturers[1].Name);
            Assert.AreEqual(includedManufacturer.Description, receivedManufacturers[1].Description);

        }

        [TestMethod]
        public async Task ReadTest()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            ManufacturersInit();
            CarsInit();
            PeopleInit();

            var cars = await CarsRepository.Read();
            Assert.IsNotNull(cars);
            Assert.IsTrue(PresetTestData.GetCars().Count() == cars.Count());

            var carsWithManufacurer = await CarsRepository.Read(include: c => c.Manufacturer);

            foreach (var car in carsWithManufacurer)
            {
                if (car.Manufacturer is null && PresetTestData.GetCars().Find(c => c.VINCode == car.VINCode).Manufacturer is not null)
                {
                    Assert.Fail("included attributes not found");
                }
            }
        }


        [TestMethod()]
        public async Task UpdateTest()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

            ManufacturersInit();
            CarsInit();
            PeopleInit();

            var car = await CarsRepository.ReadFirst(c => c.ManufacturerGuid != null);
            var modifiedCar = new Car()
            {
                Name = car.Name + "modified",
                ManufacturerGuid = car.ManufacturerGuid,
                PersonId = 3,
                VINCode = car.VINCode
            };

            await CarsRepository.Update(modifiedCar);

            car = await CarsRepository.ReadFirst(c => c.VINCode == car.VINCode);

            Assert.AreEqual(car.VINCode, modifiedCar.VINCode);
            Assert.AreEqual(car.Name, modifiedCar.Name);
            Assert.AreEqual(car.PersonId, modifiedCar.PersonId);
        }

        [TestMethod()]
        public async Task UpdateNonExistentRecordTest()
        {
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();


            var cars = PresetTestData.GetCars();

            await CarsRepository.Update(cars.FirstOrDefault());

            Assert.IsTrue((await CarsRepository.Read()).Length is 0);
        }

        private void CarsInit()
        {
            var _context = Context;
            _context.Cars.AddRange(PresetTestData.GetCars());
            _context.SaveChanges();
        }

        private void PeopleInit()
        {
            var _context = Context;
            _context.People.AddRange(PresetTestData.GetPersons());
            _context.SaveChanges();
        }

        private void ManufacturersInit()
        {
            var _context = Context;
            _context.AddRange(PresetTestData.GetManufacturers());
            _context.SaveChanges();
        }
    }
}