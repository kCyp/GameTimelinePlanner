using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimelinePlanner.Shared.Domain.Interface;
using GameTimePlanner.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JsonRepository<TypeEntity, TypeId> : IRepository<TypeEntity, TypeId> 
    where TypeEntity : IIdentifiable<TypeId> 
{
    protected readonly JsonContext _JsonContext;

    public JsonRepository(JsonContext jsonContext)
    {
        _JsonContext = jsonContext;
    }

    public virtual async Task<IList<TypeEntity>> Get()
    {
        return await _JsonContext.CollectionAsync<TypeEntity>();
    }

    public async Task<TypeEntity> GetById(TypeId id)
    {
        TypeEntity entity = (await _JsonContext.CollectionAsync<TypeEntity>())
            .First(e => EqualityComparer<TypeId>.Default.Equals(e.Id, id));
        return entity;
    }
}
