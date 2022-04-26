using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public interface IMessageReceiversCreatorService
    {
        Task<List<string>> GetAdminsByCarWash(int carWashId);

        List<string> GetMobilesByPhone(string phone);
    }
}
