using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Data.Repositories;
namespace DiunsaSCM.Data
{
    public class UserSettingRepository : RepositoryBase<UserSetting>, IUserSettingRepository
    {
        public UserSettingRepository(DiunsaSCMContext context)
            : base(context)
        {
        }
    }
}