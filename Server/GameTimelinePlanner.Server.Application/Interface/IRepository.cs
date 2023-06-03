using GameTimelinePlanner.Shared.Domain.Entity;

namespace GameTimePlanner.Application.Interface;

public interface IRepository<TypeEntity, TypeId>
{
    Task<IList<TypeEntity>> Get();
    Task<TypeEntity> GetById(TypeId id);
}
