using MotoAPp.Components.CsvReader.Models;

namespace MotoAPp.Components.CsvReader
{
    public interface ICsvReader
    {
        List<Car> ProcessCars(string filePath);
        List<Manufacturer> ProcessManufacturer(string filePath);
    }
}
