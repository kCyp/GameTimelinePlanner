﻿using GameTimelinePlanner.Shared.Domain.Entity;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.IO;

namespace GameTimelinePlanner.Infrastructure.Repository;

public class JsonContext
{
    private Lazy<Task<IList<Job>>> _LazyJobs { get; set; } = new Lazy<Task<IList<Job>>>(async() =>
    {
        //using FileStream fileStream = new("Data/jobs.json", FileMode.Open);
        //IList<Job> jobs = await JsonSerializer.DeserializeAsync<IList<Job>>(fileStream) ?? new List<Job>();
        DirectoryInfo jsonDir = new DirectoryInfo("Data/jobs");
        FileInfo[] files = jsonDir.GetFiles("*.json");
        List<Job> jobs = new();
        foreach( FileInfo fileInfo in files )
        {
            using FileStream fileStream = fileInfo.OpenRead();
            Job? _fileJob = await JsonSerializer.DeserializeAsync<Job>(fileStream);
            if (_fileJob != null)
            { 
                jobs.Add(_fileJob);
            }
        }
        return jobs;
    });

    private Lazy<Task<IList<Role>>> _LazyRoles { get; set; } = new Lazy<Task<IList<Role>>>(async () =>
    {
        using FileStream fileStream = new("Data/role.json", FileMode.Open);
        IList<Role> duties = await JsonSerializer.DeserializeAsync<IList<Role>>(fileStream) ?? new List<Role>();
        return duties;
    });

    private Lazy<Task<IList<Duty>>> _LazyDuties { get; set; } = new Lazy<Task<IList<Duty>>>(async() =>
    {
        using FileStream fileStream = new("Data/duty.json", FileMode.Open);
        IList<Duty> duties = await JsonSerializer.DeserializeAsync<IList<Duty>>(fileStream) ?? new List<Duty>();
        return duties;
    }); 

    public async Task<IList<T>> CollectionAsync<T>()
    {
        return typeof(T) switch
        {
            Type type when type == typeof(Job) => (IList<T>) await _LazyJobs.Value,
            Type type when type == typeof(Role) => (IList<T>) await _LazyRoles.Value,
            Type type when type == typeof(Duty) => (IList<T>) await _LazyDuties.Value,
            _ => throw new NotImplementedException()
        };
    }
}