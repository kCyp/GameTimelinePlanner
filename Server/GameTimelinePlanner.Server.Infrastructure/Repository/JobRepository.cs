using GameTimelinePlanner.Shared.Domain.Entity;
using GameTimePlanner.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JobRepository : IJobRepository
{
    private IList<Job> _jobs = new List<Job>()
    {
        new Job(
            "Dark Knight", 
            Role.Tank, 
            new List<Skill>()
            {
                new Skill("Dark Missionary", 15, "15% magical damage reduction"),
                new Skill("Reprisal", 10, "10% damage reduction")
            }, 
            new DisplayDescription(
                "https://img.finalfantasyxiv.com/lds/promo/h/9/5JT3hJnBNPZSLAijAF9u7zrueQ.png",
                "#d126cc")
        ),
        new Job(
            "Warrior", 
            Role.Tank, 
            new List<Skill>()
            {
                new Skill("Reprisal", 10, "10% damage reduction"),
                new Skill("PlaceHolder1", 0, ""),
                new Skill("Placeholder2", 0, "")
            },
            new DisplayDescription(
                "https://img.finalfantasyxiv.com/lds/promo/h/0/U3f8Q98TbAeGvg_vXiHGOaa2d4.png",
                "#cf2621")
        ),
        new Job(
            "Sage", 
            Role.Healer, 
            new List<Skill>()
            {
                new Skill("Kerachole", 10, "10% damage reduction"),
                new Skill("Holos", 0, "")
            },
            new DisplayDescription(
                "https://img.finalfantasyxiv.com/lds/promo/h/e/G0lQTD01LdCGk5pECSc7fbbmbM.png",
                "#80a0f0")
        ),
    };

    public Task<IList<Job>> Get()
    {
        return Task.FromResult(_jobs);
    }
}
