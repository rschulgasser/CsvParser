using CsvHelper;
using CSVParser.Web.Models;
using CVSParser.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVParser.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private string _connectionString;

        public PeopleController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }


        [HttpPost]
        [Route("upload")]
        public void Upload(UploadViewModel viewModel)
        {
            int index = viewModel.Base64Image.IndexOf(",") + 1;
            string base64 = viewModel.Base64Image.Substring(index);
            byte[] peopleBytes = Convert.FromBase64String(base64);

            var people = GetfromCsvBytes(peopleBytes);
            var repo = new PeopleRepository(_connectionString);
            repo.AddPeople(people);
        }
        [HttpGet]
        [Route("generatecsv")]
        public IActionResult GenerateCsv(int amount)
        {
            var repo = new PeopleRepository(_connectionString);

            var people = repo.GetPeople(amount);
            string csv = GenerateCSV(people);

            byte[] bytes = Encoding.UTF8.GetBytes(csv);
            return File(bytes, "text/csv", "people.csv");

        }
        [HttpGet]
        [Route("getpeople")]
        public List<Person> GetPeople()
        {
            var repo = new PeopleRepository(_connectionString);
            return repo.GetAllPeople();
        }
        [HttpPost]
        [Route("deleteallpeople")]
        public void DeletePeople()
        {
            var repo = new PeopleRepository(_connectionString);
            repo.DeletePeople();
        }
        private string GenerateCSV(List<Person> people)
        {
            var builder = new StringBuilder();
            using var writer = new StringWriter(builder);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(people);
            return builder.ToString();
        }
        private List<Person> GetfromCsvBytes(byte[] csvBytes)
        {
            using var memoryStream = new MemoryStream(csvBytes);
            var streamReader = new StreamReader(memoryStream);
            using var reader = new CsvReader(streamReader, CultureInfo.InvariantCulture);
            return reader.GetRecords<Person>().ToList();
        }

    }
}
