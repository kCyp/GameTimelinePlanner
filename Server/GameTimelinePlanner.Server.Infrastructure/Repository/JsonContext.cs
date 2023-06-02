using GameTimelinePlanner.Shared.Domain.Entity;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JsonContext
{
    private Lazy<Task<IList<Job>>> _LazyJobs { get; set; } = new Lazy<Task<IList<Job>>>(async() =>
    {
        using FileStream fileStream = new("Data/jobs.json", FileMode.Open);
        IList<Job> jobs = await JsonSerializer.DeserializeAsync<IList<Job>>(fileStream) ?? new List<Job>();
        return jobs;
    }); 

    public async Task<IList<T>> CollectionAsync<T>()
    {
        return typeof(T) switch
        {
            Type type when type == typeof(Job) => (IList<T>) await _LazyJobs.Value,
            _ => throw new NotImplementedException()
        }; ;
    }
}