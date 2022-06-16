using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CVSParser.Data
{
    public class PeopleRepository
    {
        private readonly string _connectionString;

        public PeopleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Person> GetAllPeople()
        {
            using var ctx = new CSVContext(_connectionString);

            return ctx.People.ToList();
        }
        public void DeletePeople()
        {
            using var ctx = new CSVContext(_connectionString);

            ctx.Database.ExecuteSqlInterpolated($"delete from people");
        }
        public void AddPeople(List<Person> people)
        {
            using var ctx = new CSVContext(_connectionString);

            ctx.People.AddRange(people);
            ctx.SaveChanges();
        }
        public List<Person> GetPeople(int count)


        {

            using var ctx = new CSVContext(_connectionString);

            return Enumerable.Range(1, count).Select(_ =>
            {
                return new Person
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Email = Faker.Internet.Email(),
                    Adress = Faker.Address.SecondaryAddress(),
                    Age = Faker.RandomNumber.Next(20, 100)
                };
            }).ToList();
        }

    }
}
