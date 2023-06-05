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
   public class CarClassService:ICarClassService
    {
		public List<CarClassDTO> Get()
		{
			List<CarClassDTO> classDTO = new List<CarClassDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.CarClassRepository.Get())
				{
					CarClassDTO carClassDTO = new CarClassDTO();

					carClassDTO.Id = item.Id;
					carClassDTO.Name = item.Name;
					carClassDTO.CreatedBy = item.CreatedBy;
					carClassDTO.CreatedOn = item.CreatedOn;
					carClassDTO.UpdatedOn = item.UpdatedOn;
					carClassDTO.UpdatedBy = item.UpdatedBy;
					classDTO.Add(carClassDTO);

				}
			}

			return classDTO;
		}

		public CarClassDTO GetById(int id)
		{
			CarClassDTO classDTO = new CarClassDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				CarClass carClass = unitOfWork.CarClassRepository.GetByID(id);

				if (carClass != null)
				{
					classDTO.Name = carClass.Name;
					classDTO.CreatedBy = carClass.CreatedBy;
					classDTO.CreatedOn = carClass.CreatedOn;
					classDTO.UpdatedOn = carClass.UpdatedOn;
					classDTO.UpdatedBy = carClass.UpdatedBy;
				}

				return classDTO;
			}
		}

		public bool Save(CarClassDTO classDTO)
		{
			CarClass carClass = new CarClass
			{
				Name = classDTO.Name,
				CreatedBy = classDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = classDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.CarClassRepository.Insert(carClass);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(CarClassDTO carClassDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					CarClass currentClass = unitOfWork.CarClassRepository.GetByID(carClassDTO.Id);
					currentClass.Name = carClassDTO.Name;
					currentClass.UpdatedOn = DateTime.Now;
					currentClass.UpdatedBy = carClassDTO.UpdatedBy;

					unitOfWork.CarClassRepository.Update(currentClass);
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
					unitOfWork.CarClassRepository.Delete(id);
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
