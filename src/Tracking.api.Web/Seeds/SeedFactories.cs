﻿using Ardalis.SharedKernel;
using Newtonsoft.Json;
using Tracking.api.Core.Records.FactoryDtos;
using Factory = Tracking.api.Core.Aggregates.FactoryAggregate.Factory;
using FactoryAggregate_Factory = Tracking.api.Core.Aggregates.FactoryAggregate.Factory;

namespace Tracking.api.Web.Seeds;

public class SeedFactories
{
  public static async Task InitializeAsync(IServiceProvider serviceProvider)
  {
    var repo = serviceProvider.GetService<IRepository<FactoryAggregate_Factory>>();
    if (!await repo.AnyAsync())
    {
      var jsonList =
        JsonConvert.DeserializeObject<List<SeedFactoryDto>>(await File.ReadAllTextAsync(Directory.GetCurrentDirectory() + @"\wwwroot\" + "Factories.json"));

      var instituteQuestions = jsonList.Select(factory => new FactoryAggregate_Factory(factory.FactoryTitle)).ToList();

      await repo.AddRangeAsync(instituteQuestions);
      await repo.SaveChangesAsync();
    }
  }
}
