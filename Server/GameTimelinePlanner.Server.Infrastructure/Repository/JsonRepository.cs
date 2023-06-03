using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Infrastructure.Repository;

public abstract class JsonRepository<TypeEntity, TypeId> : IRepository<TypeEntity, TypeId>
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

    public abstract Task<TypeEntity> GetById(TypeId id);
}
