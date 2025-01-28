using Captcha.Application.DTO;
using Captcha.Domain.Entities;
using Captcha.Domain.Interfaces;
using Captcha.Domain.ValueObjects;
using Mapster;

namespace Captcha.Application.Services;

public class MousePositionDataService(IRepository<MousePositionData> repository)
{
    private readonly IRepository<MousePositionData> _repository = repository;

    public virtual async Task AddAsync(MouseMovementData dto)
    {
        var positions = dto.Adapt<PositionsData>();
        var entity = new MousePositionData { PositionsData = positions};
        await _repository.AddEntity(entity);
    }
}
