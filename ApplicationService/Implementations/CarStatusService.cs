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
    public class CarStatusService:ICarStatus
    {
		public List<CarStatusDTO> Get()
		{
			List<CarStatusDTO> statusDTO = new List<CarStatusDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.CarStatusRepository.Get())
				{
					CarStatusDTO carStatusDTO = new CarStatusDTO();

					carStatusDTO.Id = item.Id;
					carStatusDTO.Name = item.Name;
					carStatusDTO.CreatedBy = item.CreatedBy;
					carStatusDTO.CreatedOn = item.CreatedOn;
					carStatusDTO.UpdatedOn = item.UpdatedOn;
					carStatusDTO.UpdatedBy = item.UpdatedBy;
					statusDTO.Add(carStatusDTO);

				}
			}

			return statusDTO;
		}

		public CarStatusDTO GetById(int id)
		{
			CarStatusDTO statusDTO = new CarStatusDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				CarStatus carStatus = unitOfWork.CarStatusRepository.GetByID(id);

				if (carStatus != null)
				{
					statusDTO.Name = carStatus.Name;
					statusDTO.CreatedBy = carStatus.CreatedBy;
					statusDTO.CreatedOn = carStatus.CreatedOn;
					statusDTO.UpdatedOn = carStatus.UpdatedOn;
					statusDTO.UpdatedBy = carStatus.UpdatedBy;
				}

				return statusDTO;
			}
		}

		public bool Save(CarStatusDTO statusDTO)
		{
			CarStatus carStatus = new CarStatus
			{
				Name = statusDTO.Name,
				CreatedBy = statusDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = statusDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.CarStatusRepository.Insert(carStatus);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(CarStatusDTO carStatusDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					CarStatus currentStatus = unitOfWork.CarStatusRepository.GetByID(carStatusDTO.Id);
					currentStatus.Name = carStatusDTO.Name;
					currentStatus.UpdatedOn = DateTime.Now;
					currentStatus.UpdatedBy = carStatusDTO.UpdatedBy;

					unitOfWork.CarStatusRepository.Update(currentStatus);
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
					unitOfWork.CarStatusRepository.Delete(id);
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
