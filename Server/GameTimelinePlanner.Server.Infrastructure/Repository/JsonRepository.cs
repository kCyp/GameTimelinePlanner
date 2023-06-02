using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JsonRepository<T> : IRepository<T>
{
    private readonly JsonContext _JsonContext;

    public JsonRepository(JsonContext jsonContext)
    {
        _JsonContext = jsonContext;
    }

    public async Task<IList<T>> Get()
    {
        return await _JsonContext.CollectionAsync<T>();
    }
}
