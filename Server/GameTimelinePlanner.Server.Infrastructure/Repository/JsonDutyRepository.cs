using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JsonDutyRepository : JsonRepository<Duty, string>
{
    public JsonDutyRepository(JsonContext jsonContext)
        : base(jsonContext)
    {
    }

    public override async Task<Duty> GetById(string id)
    {
        Duty duty = (await _JsonContext.CollectionAsync<Duty>()).First(d => d.Name == id);
        return duty;
    }
}
