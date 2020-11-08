using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleManager.Application.Interfaces;
using VehicleManager.Application.ViewModels.UserModels;
using VehicleManager.Domain.Interfaces;

namespace VehicleManager.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ListUserCarsForList GetUserVehicles(string userId)
        {
            var userCars = _userRepository.GetAllUserVehicles(userId)
                 .ProjectTo<UserCarsForList>(_mapper.ConfigurationProvider).ToList();

            var listUserCars = new ListUserCarsForList()
            {
                UserCars = userCars
            };

            return listUserCars;
        }

    }
}
