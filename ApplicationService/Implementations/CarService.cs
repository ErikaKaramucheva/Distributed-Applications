using ApplicationService.DTOs;
using ApplicationService.Interfaces;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class CarService:ICarService
    {
		public List<CarDTO> Get()
		{
			List<CarDTO> carDTO = new List<CarDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.CarRepository.Get())
				{
					CarDTO cDTO = new CarDTO();

					cDTO.Id = item.Id;
					cDTO.Brand_id = item.Brand_id;
					cDTO.Class_id = item.Class_id;
					cDTO.Color = item.Color;
					cDTO.Fuel_id = item.Fuel_id;
					cDTO.User_id = item.User_id;
					cDTO.Mileage = item.Mileage;
					cDTO.Model_id = item.Model_id;
					cDTO.Price = item.Price;
					cDTO.Year = item.Year;
					cDTO.Transmission_id = item.Transmission_id;
					cDTO.ImageURL = item.ImageURL;
					cDTO.Town_id = item.Town_id;
					cDTO.CarStatus_id = item.CarStatus_id;
					cDTO.Description = item.Description;
					cDTO.CreatedBy = item.CreatedBy;
					cDTO.CreatedOn = item.CreatedOn;
					cDTO.UpdatedOn = item.UpdatedOn;
					cDTO.UpdatedBy = item.UpdatedBy;
					carDTO.Add(cDTO);

				}
			}

			return carDTO;
		}

		public CarDTO GetById(int id)
		{
			CarDTO carDTO = new CarDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Data.Entities.Car car = unitOfWork.CarRepository.GetByID(id);

				if (car != null)
				{
					carDTO.Brand_id = car.Brand_id;
					carDTO.Class_id = car.Class_id;
					carDTO.Color = car.Color;
					carDTO.Fuel_id = car.Fuel_id;
					carDTO.Mileage = car.Mileage;
					carDTO.Model_id = car.Model_id;
					carDTO.Price = car.Price;
					carDTO.Year = car.Year;
					carDTO.ImageURL = car.ImageURL;
					carDTO.Transmission_id = car.Transmission_id;
					carDTO.Town_id = car.Town_id;
					carDTO.User_id = car.User_id;
					carDTO.CarStatus_id = car.CarStatus_id;
					carDTO.Description = car.Description;
					carDTO.CreatedBy = car.CreatedBy;
					carDTO.CreatedOn = car.CreatedOn;
					carDTO.UpdatedOn = car.UpdatedOn;
					carDTO.UpdatedBy = car.UpdatedBy;
				}

				return carDTO;
			}
		}

		public List<CarDTO> GetByUserId(string id)
		{
			List<CarDTO> carDTO = new List<CarDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.CarRepository.Get())
				{
					if (item.User_id == Int32.Parse(id))
					{
						CarDTO cDTO = new CarDTO();

						cDTO.Id = item.Id;
						cDTO.Brand_id = item.Brand_id;
						cDTO.Class_id = item.Class_id;
						cDTO.Color = item.Color;
						cDTO.Fuel_id = item.Fuel_id;
						cDTO.User_id = item.User_id;
						cDTO.Mileage = item.Mileage;
						cDTO.Model_id = item.Model_id;
						cDTO.Price = item.Price;
						cDTO.Year = item.Year;
						cDTO.Transmission_id = item.Transmission_id;
						cDTO.ImageURL = item.ImageURL;
						cDTO.Town_id = item.Town_id;
						cDTO.CarStatus_id = item.CarStatus_id;
						cDTO.Description = item.Description;
						cDTO.CreatedBy = item.CreatedBy;
						cDTO.CreatedOn = item.CreatedOn;
						cDTO.UpdatedOn = item.UpdatedOn;
						cDTO.UpdatedBy = item.UpdatedBy;
						carDTO.Add(cDTO);
                    }
				}
			}

			return carDTO;
		}

		public bool Save(CarDTO carDTO)
		{
			Data.Entities.Car car = new Data.Entities.Car
			{
				Brand_id = carDTO.Brand_id,
				Class_id = carDTO.Class_id,
				Color = carDTO.Color,
				Fuel_id = carDTO.Fuel_id,
				Mileage = carDTO.Mileage,
				Model_id = carDTO.Model_id,
				User_id=carDTO.User_id,
				Price = carDTO.Price,
				Year = carDTO.Year,
				Transmission_id = carDTO.Transmission_id,
				Town_id = carDTO.Town_id,
				ImageURL=carDTO.ImageURL,
				CarStatus_id = carDTO.CarStatus_id,
				Description = carDTO.Description,
				CreatedBy = carDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = carDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.CarRepository.Insert(car);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(CarDTO carDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					Data.Entities.Car currentCar = unitOfWork.CarRepository.GetByID(carDTO.Id);
					currentCar.Brand_id = carDTO.Brand_id;
					currentCar.Class_id = carDTO.Class_id;
					currentCar.Color = carDTO.Color;
					currentCar.Fuel_id = carDTO.Fuel_id;
					currentCar.Mileage = carDTO.Mileage;
					currentCar.Model_id= carDTO.Model_id;
					currentCar.User_id= carDTO.User_id;
					currentCar.Price= carDTO.Price;
					currentCar.Year= carDTO.Year;
					currentCar.ImageURL= carDTO.ImageURL;
					currentCar.Transmission_id= carDTO.Transmission_id;
					currentCar.Town_id= carDTO.Town_id;
					currentCar.CarStatus_id= carDTO.CarStatus_id;
					currentCar.Description= carDTO.Description;
					currentCar.UpdatedOn = DateTime.Now;
					currentCar.UpdatedBy = carDTO.UpdatedBy;

					unitOfWork.CarRepository.Update(currentCar);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}


		}
		public bool Delete(int id)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.CarRepository.Delete(id);
					unitOfWork.Save();
				}
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
