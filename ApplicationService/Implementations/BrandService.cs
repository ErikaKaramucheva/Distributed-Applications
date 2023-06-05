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
    public class BrandService:IBrandService
    {
		public List<BrandDTO> Get()
		{
			List<BrandDTO> brandDTO = new List<BrandDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.BrandRepository.Get())
				{
					BrandDTO brDTO = new BrandDTO();

					brDTO.Id = item.Id;
					brDTO.Name = item.Name;
					brDTO.CreatedBy = item.CreatedBy;
					brDTO.CreatedOn = item.CreatedOn;
					brDTO.UpdatedOn = item.UpdatedOn;
					brDTO.UpdatedBy = item.UpdatedBy;
					brandDTO.Add(brDTO);

				}
			}

			return brandDTO;
		}

		public BrandDTO GetById(int id)
		{
			BrandDTO brandDTO = new BrandDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Brand brand = unitOfWork.BrandRepository.GetByID(id);

				if (brand != null)
				{
					brandDTO.Name = brand.Name;
					brandDTO.CreatedBy = brand.CreatedBy;
					brandDTO.CreatedOn = brand.CreatedOn;
					brandDTO.UpdatedOn = brand.UpdatedOn;
					brandDTO.UpdatedBy = brand.UpdatedBy;
				}

				return brandDTO;
			}
		}

		public bool Save(BrandDTO brandDTO)
		{
			Brand brand = new Brand
			{
				Id=brandDTO.Id,
				Name = brandDTO.Name,
				CreatedBy = brandDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = brandDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.BrandRepository.Insert(brand);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(BrandDTO brandDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					Brand currentBrand = unitOfWork.BrandRepository.GetByID(brandDTO.Id);
					currentBrand.Name = brandDTO.Name;
					currentBrand.UpdatedOn = DateTime.Now;
					currentBrand.UpdatedBy = brandDTO.UpdatedBy;

					unitOfWork.BrandRepository.Update(currentBrand);
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
					unitOfWork.BrandRepository.Delete(id);
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
