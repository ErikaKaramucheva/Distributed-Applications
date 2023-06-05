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
    public class UserService:IUserService
    {
		public List<UserDTO> Get()
		{
			List<UserDTO> userDTO = new List<UserDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.UserRepository.Get())
				{
					UserDTO uDTO = new UserDTO();

					uDTO.Id = item.Id;
					uDTO.Email = item.Email;
					uDTO.Username = item.Username;
					uDTO.Password = item.Password;
					uDTO.FirstName = item.FirstName;
					uDTO.LastName = item.LastName;
					uDTO.Phone = item.Phone;
					uDTO.Town_id = item.Town_id;
					uDTO.CreatedBy = item.CreatedBy;
					uDTO.CreatedOn = item.CreatedOn;
					uDTO.UpdatedOn = item.UpdatedOn;
					uDTO.UpdatedBy = item.UpdatedBy;
					userDTO.Add(uDTO);

				}
			}

			return userDTO;
		}

		public UserDTO GetById(int id)
		{
			UserDTO userDTO = new UserDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				User user = unitOfWork.UserRepository.GetByID(id);

				if (user != null)
				{
					userDTO.Username = user.Username;
					userDTO.Email = user.Email;
					userDTO.Password = user.Password;
					userDTO.FirstName = user.FirstName;
					userDTO.LastName = user.LastName;
					userDTO.Phone = user.Phone;
					userDTO.Town_id = user.Town_id;
					userDTO.CreatedBy = user.CreatedBy;
					userDTO.CreatedOn = user.CreatedOn;
					userDTO.UpdatedOn = user.UpdatedOn;
					userDTO.UpdatedBy = user.UpdatedBy;
				}

				return userDTO;
			}
		}
		public bool Login(LoginDTO userDto)
		{
			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				User user = unitOfWork.UserRepository.GetByUserName(userDto.Username,userDto.Password);
				if (user == null || (userDto.Password!=user.Password))
				{
					return false;
				}

				return true;
			}

		}

		public bool Save(UserDTO userDTO)
		{
			User user = new User
			{
				Id = userDTO.Id,
				Username = userDTO.Username,
				Email = userDTO.Email,
				Password = userDTO.Password,
				FirstName = userDTO.FirstName,
				LastName = userDTO.LastName,
				Phone = userDTO.Phone,
				Town_id = userDTO.Town_id,
				CreatedBy = userDTO.CreatedBy,
				CreatedOn = DateTime.Now,
				UpdatedBy = userDTO.UpdatedBy,
				UpdatedOn = DateTime.Now

			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					unitOfWork.UserRepository.Insert(user);
					unitOfWork.Save();
				}

				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Update(UserDTO userDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					User currentUser = unitOfWork.UserRepository.GetByID(userDTO.Id);
					currentUser.Username = userDTO.Username;
					currentUser.Password = userDTO.Password;
					currentUser.Email = userDTO.Email;
					currentUser.FirstName = userDTO.FirstName;
					currentUser.LastName = userDTO.LastName;
					currentUser.Phone = userDTO.Phone;
					currentUser.Town_id = userDTO.Town_id;
					currentUser.UpdatedOn = DateTime.Now;
					currentUser.UpdatedBy = userDTO.UpdatedBy;

					unitOfWork.UserRepository.Update(currentUser);
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
					unitOfWork.UserRepository.Delete(id);
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
