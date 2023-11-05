using MotoAPp.DataProvicers.Extensions;
using MotoAPp.Entities;
using MotoAPp.Repositories;
using System;
using System.Linq;
using System.Text;

namespace MotoAPp.DataProvicers
{
    public class CarsProvider : ICarsProvider
    {
        private readonly IRepository<Car> _carsRepository;

        public CarsProvider(IRepository<Car> carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public string AnonymousCLass()
        {

            var cars = _carsRepository.GetAll().Select(car => new { Identifier = car.Id, ProductName = car.Name, ProductSize = car.Type }).ToList();

            StringBuilder sb = new();
            foreach(var car in cars)
            {
                sb.AppendLine($"Product Identifier: {car.Identifier}");
                sb.AppendLine($"    Product ProductName: {car.ProductName}");
                sb.AppendLine($"    Product ProductSize: {car.ProductSize}");
            }
            return sb.ToString();
        }        

        public decimal GetMinimumPriceOfAllCars()
        {
            return _carsRepository.GetAll().Min(c => c.ListPrice);
        }

        public List<Car> GetSpecifiedColumns()
        {
            return _carsRepository.GetAll().Select(car => new Car { Id = car.Id, Name = car.Name, Type = car.Type}).ToList();
        }

        public List<string> GetUniqueCarColors()
        {
            return _carsRepository.GetAll().Select(x => x.Color).Distinct().ToList();
        }

        public List<Car> OrderByColorAndName()
        {
            return _carsRepository.GetAll().OrderBy(x => x.Color).ThenBy(x=>x.Name).ToList();
        }

        public List<Car> OrderByColorAndNameDesc()
        {
            return _carsRepository.GetAll().OrderByDescending(x => x.Color).ThenBy(x => x.Name).ToList();
        }

        public List<Car> OrderByNameDescending()
        {
            return _carsRepository.GetAll().OrderByDescending(x => x.Name).ToList();
        }

        public List<Car> OrderByName()
        {
            return _carsRepository.GetAll().OrderBy(x => x.Name).ToList();
        }

        public List<Car> WhereStartsWith(string prefix)
        {
            return _carsRepository.GetAll().Where(x=>x.Name.StartsWith(prefix)).ToList();
        }

        public List<Car> WhereStartsWithAndCostIsGreaterThan(string prefix, decimal cost)
        {
            return _carsRepository.GetAll().Where(x => x.Name.StartsWith(prefix) && x.StandardCost > cost).ToList();
        }

        public List<Car> WhereColorIs(string color)
        {
            return _carsRepository.GetAll().ByColor(color).ToList();
        }

        public Car FirstByColor(string color)
        {
            return _carsRepository.GetAll().First(x=>x.Color == color);
        }

        public Car? FirstOrDefaultByColor(string color)
        {
            return _carsRepository.GetAll().FirstOrDefault(x => x.Color == color);
        }

        public Car? FirstOrDefaultByColorWithDefault(string color)
        {
            return _carsRepository.GetAll().FirstOrDefault(x => x.Color == color, new Car { Id=-1, Name = "NOT FOUND"});
        }

        public Car LastByColor(string color)
        {
            return _carsRepository.GetAll().Last(x => x.Color == color);
        }

        public Car SingleById(int id)
        {
            return _carsRepository.GetAll().Single(x=>x.Id == id);
        }

        public Car? SingleOrDefaultById(int id)
        {
            return _carsRepository.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public List<Car> TakeCars(int howMany)
        {
            return _carsRepository.GetAll().OrderBy(x=>x.Name).Take(howMany).ToList();
        }

        public List<Car> TakeCars(Range range)
        {
            return _carsRepository.GetAll().OrderBy(x => x.Name).Take(range).ToList();
        }

        public List<Car> TakeCarsWhileNameStartsWith(string prefix)
        {
            return _carsRepository.GetAll().OrderBy(x => x.Name).TakeWhile(x=>x.Name.StartsWith(prefix)).ToList();
        }

        public List<Car> SkipCars(int howMany)
        {
            return _carsRepository.GetAll().Skip(howMany).ToList();
        }

        public List<Car> SkipCarsWhileNameStartsWith(string prefix)
        {
            return _carsRepository.GetAll().SkipWhile(x=>x.Name.StartsWith(prefix)).ToList();
        }

        public List<string> DistinctAllCollors()
        {
            return _carsRepository.GetAll().Select(x => x.Color).Distinct().OrderBy(x => x).ToList();
        }

        public List<Car> DistinctHByColors()
        {
            return _carsRepository.GetAll().Distinct().OrderBy(x => x).ToList();
        }

        public List<Car[]> ChunkCars(int size)
        {
            return _carsRepository.GetAll().Chunk(size).ToList();
        }
    }
}
