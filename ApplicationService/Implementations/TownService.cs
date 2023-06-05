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
    public class TownService:ITownService
    {
		public List<TownDTO> Get()
		{
			List<TownDTO> townDTO = new List<TownDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.TownRepository.Get())
				{
					TownDTO twDTO = new TownDTO();

					twDTO.Id = item.Id;
					twDTO.Name = item.Name;
					twDTO.CreatedBy = item.CreatedBy;
					twDTO.CreatedOn = item.CreatedOn;
					twDTO.UpdatedOn = item.UpdatedOn;
					twDTO.UpdatedBy = item.UpdatedBy;
					townDTO.Add(twDTO);

				}
			}

			return townDTO;
		}

		public TownDTO GetById(int id)
		{
			TownDTO townDTO = new TownDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Town town = unitOfWork.TownRepository.GetByID(id);

				if (town != null)
				{
					townDTO.Name = town.Name;
					townDTO.CreatedBy = town.CreatedBy;
					townDTO.CreatedOn = town.CreatedOn;
					townDTO.UpdatedOn = town.UpdatedOn;
					townDTO.UpdatedBy = town.UpdatedBy;
				}

				return townDTO;
			}
		}

		public bool Save(TownDTO townDTO)
		{
			Town town = new Town
			{
				Id = townDTO.Id,
				Name = townDTO.Name,
				CreatedBy = townDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = townDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.TownRepository.Insert(town);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(TownDTO townDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					Town currentTown = unitOfWork.TownRepository.GetByID(townDTO.Id);
					currentTown.Name = townDTO.Name;
					currentTown.UpdatedOn = DateTime.Now;
					currentTown.UpdatedBy = townDTO.UpdatedBy;

					unitOfWork.TownRepository.Update(currentTown);
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
					unitOfWork.TownRepository.Delete(id);
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
