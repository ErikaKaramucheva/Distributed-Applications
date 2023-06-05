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
   public class ModelService:IModelService
    {
		public List<ModelDTO> Get()
		{
			List<ModelDTO> modelDTO = new List<ModelDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.ModelRepository.Get())
				{
					ModelDTO modDTO = new ModelDTO();

					modDTO.Id = item.Id;
					modDTO.Name = item.Name;
					modDTO.Brand_id = item.Brand_id;
					modDTO.CreatedBy = item.CreatedBy;
					modDTO.CreatedOn = item.CreatedOn;
					modDTO.UpdatedOn = item.UpdatedOn;
					modDTO.UpdatedBy = item.UpdatedBy;
					modelDTO.Add(modDTO);

				}
			}

			return modelDTO;
		}

		public ModelDTO GetById(int id)
		{
			ModelDTO modelDTO = new ModelDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Model model = unitOfWork.ModelRepository.GetByID(id);

				if (model != null)
				{
					modelDTO.Name = model.Name;
					modelDTO.Brand_id = model.Brand_id;
					modelDTO.CreatedBy = model.CreatedBy;
					modelDTO.CreatedOn = model.CreatedOn;
					modelDTO.UpdatedOn = model.UpdatedOn;
					modelDTO.UpdatedBy = model.UpdatedBy;
				}

				return modelDTO;
			}
		}

		public bool Save(ModelDTO modelDTO)
		{
			Model model = new Model
			{
				Name = modelDTO.Name,
				Brand_id=modelDTO.Brand_id,
				CreatedBy = modelDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = modelDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.ModelRepository.Insert(model);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(ModelDTO modelDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					Model currentModel = unitOfWork.ModelRepository.GetByID(modelDTO.Id);
					currentModel.Name = modelDTO.Name;
					currentModel.Brand_id = modelDTO.Brand_id;
					currentModel.UpdatedOn = DateTime.Now;
					currentModel.UpdatedBy = modelDTO.UpdatedBy;

					unitOfWork.ModelRepository.Update(currentModel);
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
					unitOfWork.ModelRepository.Delete(id);
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
