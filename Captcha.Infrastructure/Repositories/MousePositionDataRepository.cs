using Captcha.Domain.Entities;
using Captcha.Infrastructure.Data;
using Captcha.Infrastructure.Repositories.Common;

namespace Captcha.Infrastructure.Repositories
{
    public class MousePositionDataRepository(Context context) : BaseRepository<MousePositionData>(context)
    {
    }
}
