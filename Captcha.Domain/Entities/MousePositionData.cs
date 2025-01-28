using Captcha.Domain.ValueObjects;

namespace Captcha.Domain.Entities
{
    public class MousePositionData : BaseEntity
    {
        public PositionsData PositionsData { get; set; }
    }
}
