using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.DTOs.Users;
using api.Models;

namespace api.Mappers
{
    public static class UsersMappers
    {
        public static UsersDto ToUsersDto(this Users usersModel)
        {
            return new UsersDto
            {
                UserID = usersModel.UserID,
                FullNames = usersModel.FullNames,
                EmailAddress = usersModel.EmailAddress,
                Password = usersModel.Password,
                ConfirmPassword = usersModel.ConfirmPassword,
                IsActive = usersModel.IsActive,
            };
        }
        
        public static Users ToUsersFromCreateDTO(this CreateUsersRequestDto usersDto)
        {
            return new Users
            {
                FullNames = usersDto.FullNames,
                EmailAddress = usersDto.EmailAddress,
                Password = usersDto.Password,
                ConfirmPassword = usersDto.ConfirmPassword,
                IsActive = usersDto.IsActive,
            };
        }
    }
}