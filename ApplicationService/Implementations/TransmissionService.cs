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
    public class TransmissionService:ITransmissionService
    {
		public List<TransmissionDTO> Get()
		{
			List<TransmissionDTO> transmissionDTO = new List<TransmissionDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.TransmissionRepository.Get())
				{
					TransmissionDTO transDTO = new TransmissionDTO();

					transDTO.Id = item.Id;
					transDTO.Name = item.Name;
					transDTO.CreatedBy = item.CreatedBy;
					transDTO.CreatedOn = item.CreatedOn;
					transDTO.UpdatedOn = item.UpdatedOn;
					transDTO.UpdatedBy = item.UpdatedBy;
					transmissionDTO.Add(transDTO);

				}
			}

			return transmissionDTO;
		}

		public TransmissionDTO GetById(int id)
		{
			TransmissionDTO transDTO = new TransmissionDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Transmission transmission = unitOfWork.TransmissionRepository.GetByID(id);

				if (transmission != null)
				{
					transDTO.Name = transmission.Name;
					transDTO.CreatedBy = transmission.CreatedBy;
					transDTO.CreatedOn = transmission.CreatedOn;
					transDTO.UpdatedOn = transmission.UpdatedOn;
					transDTO.UpdatedBy = transmission.UpdatedBy;
				}

				return transDTO;
			}
		}

		public bool Save(TransmissionDTO transmissionDTO)
		{
			Transmission trans = new Transmission
			{
				Name = transmissionDTO.Name,
				CreatedBy = transmissionDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = transmissionDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.TransmissionRepository.Insert(trans);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(TransmissionDTO transmissionDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					Transmission currentTrans = unitOfWork.TransmissionRepository.GetByID(transmissionDTO.Id);
					currentTrans.Name = transmissionDTO.Name;
					currentTrans.UpdatedOn = DateTime.Now;
					currentTrans.UpdatedBy = transmissionDTO.UpdatedBy;

                    if (transmissionDTO.CreatedOn ==DateTime.MinValue)
                    {
						currentTrans.CreatedOn = DateTime.Now;
                    }
					unitOfWork.TransmissionRepository.Update(currentTrans);
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
					unitOfWork.TransmissionRepository.Delete(id);
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
