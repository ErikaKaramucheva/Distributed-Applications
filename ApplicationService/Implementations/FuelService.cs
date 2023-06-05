using ApplicationService.DTOs;
using ApplicationService.Interfaces;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class FuelService:IFuelService
    {
		public List<FuelDTO> Get()
		{
			List<FuelDTO> fuelDTO = new List<FuelDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.FuelRepository.Get())
				{
					FuelDTO fDTO = new FuelDTO();

					fDTO.Id = item.Id;
					fDTO.Name = item.Name;
					fDTO.CreatedOn = item.CreatedOn;
					fDTO.CreatedBy = item.CreatedBy;
					fDTO.UpdatedBy = item.UpdatedBy;
					fDTO.UpdatedOn = item.UpdatedOn;
					fuelDTO.Add(fDTO);

				}
			}

			return fuelDTO;
		}

		public FuelDTO GetById(int id)
		{
			FuelDTO fuelDTO = new FuelDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Fuel fuel = unitOfWork.FuelRepository.GetByID(id);

				if (fuel != null)
				{
					fuelDTO.Name = fuel.Name;
					fuelDTO.UpdatedBy = fuel.UpdatedBy;
					fuelDTO.UpdatedOn = fuel.UpdatedOn;
					fuelDTO.CreatedBy = fuel.CreatedBy;
					fuelDTO.CreatedOn = fuel.CreatedOn;
				}

				return fuelDTO;
			}
		}

		public bool Save(FuelDTO fuelDTO)
		{
			Fuel fuel = new Fuel
			{
				Name = fuelDTO.Name,
				CreatedBy=fuelDTO.CreatedBy,
				CreatedOn=DateTime.Now,
				UpdatedBy=fuelDTO.UpdatedBy,
				UpdatedOn=DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.FuelRepository.Insert(fuel);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(FuelDTO fuelDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					Fuel currentFuel = unitOfWork.FuelRepository.GetByID(fuelDTO.Id);
					currentFuel.Name = fuelDTO.Name;
					currentFuel.UpdatedOn = DateTime.Now;
					currentFuel.UpdatedBy = fuelDTO.UpdatedBy;

					unitOfWork.FuelRepository.Update(currentFuel);
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
					unitOfWork.FuelRepository.Delete(id);
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
