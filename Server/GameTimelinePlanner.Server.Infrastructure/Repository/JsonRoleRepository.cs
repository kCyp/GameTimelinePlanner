using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JsonRoleRepository : JsonRepository<Role, RoleType>
{
    public JsonRoleRepository(JsonContext jsonContext)
        : base(jsonContext)
    {
    }

    public override async Task<Role> GetById(RoleType roleType)
    {
        Role role = (await _JsonContext.CollectionAsync<Role>()).First(r => r.Type == roleType);
        return role;
    }
}
