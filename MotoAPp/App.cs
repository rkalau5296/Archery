using MotoAPp.Components.CsvReader;

namespace MotoAPp
{
    public class App : IApp
    {
        private readonly ICsvReader _csvReader;

        public App(ICsvReader csvReader)
        {
            _csvReader = csvReader;
        }

        public void Run()
        {
            var cars = _csvReader.ProcessCars("Resources\\Files\\fuel.csv");
            var manufacturers = _csvReader.ProcessManufacturer("Resources\\Files\\manufacturers.csv");
        }
    }
}

