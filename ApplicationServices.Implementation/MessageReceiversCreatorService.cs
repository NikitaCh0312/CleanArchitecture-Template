using DataAccess.Interfaces;
using Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ApplicationServices.Implementation
{
    public class MessageReceiversCreatorService : IMessageReceiversCreatorService
    {
        private readonly IRepository<CarWash> _carWashesRepository;
        private readonly IRepository<WashService> _washServicesRepository;
        private readonly UserManager<User> _userManager;

        public MessageReceiversCreatorService(IRepository<CarWash> carWashesRepository,
            IRepository<WashService> washServicesRepository,
            UserManager<User> userManager)
        {
            _carWashesRepository = carWashesRepository;
            _washServicesRepository = washServicesRepository;
            _userManager = userManager;
        }

        public async Task<List<string>> GetAdminsByCarWash(int carWashId)
        {
            CarWash carWash = await _carWashesRepository.GetAsync(item => item.Id == carWashId);
            if (carWash == null)
            {
                return new List<string>();
            }

            return carWash.Users.Select(item => item.Id).ToList();
        }

        public async Task<List<string>> GetAdminsByWashService(int washServiceId)
        {
            var washService = await _washServicesRepository.GetAsync(item => item.Id == washServiceId);
            if (washService == null)
            {
                return new List<string>();
            }

            return await GetAdminsByCarWash(washService.CarWashId);
        }

        public List<string> GetMobilesByPhone(string phone)
        {
            return _userManager.Users.Where(o => o.PhoneNumber == phone).Select(u => u.Id).ToList();
        }
    }
}
