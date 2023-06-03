using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JsonJobRepository : JsonRepository<Job, string>
{
    private readonly IRepository<Role, RoleType> _RoleRepository;

    public JsonJobRepository(JsonContext jsonContext, IRepository<Role, RoleType> roleRepository)
        : base(jsonContext)
    {
        _RoleRepository = roleRepository;
    }

    public override async Task<IList<Job>> Get()
    {
        IList<Job> jobs = await base.Get();
        foreach (Job job in jobs)
        {
            Role role = await _RoleRepository.GetById(job.RoleType);
            job.SetRole(role);
        }
        return jobs;
    }

    public override async Task<Job> GetById(string id)
    {
        Job job = (await _JsonContext.CollectionAsync<Job>()).First(j => j.Name == id);
        return job;
    }
}
