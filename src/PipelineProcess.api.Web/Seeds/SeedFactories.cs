using Ardalis.SharedKernel;
using Newtonsoft.Json;
using PipelineProcess.api.Core.Records.FactoryDtos;
using Factory = PipelineProcess.api.Core.Aggregates.FactoryAggregate.Factory;

namespace PipelineProcess.api.Web.Seeds;

public class SeedFactories
{
  public static async Task InitializeAsync(IServiceProvider serviceProvider)
  {
    var repo = serviceProvider.GetService<IRepository<Factory>>();
    if (!await repo.AnyAsync())
    {
      var jsonList =
        JsonConvert.DeserializeObject<List<SeedFactoryDto>>(await File.ReadAllTextAsync(Directory.GetCurrentDirectory() + @"\wwwroot\" + "Factories.json"));

      var instituteQuestions = jsonList.Select(factory => new Factory(factory.FactoryTitle)).ToList();

      await repo.AddRangeAsync(instituteQuestions);
      await repo.SaveChangesAsync();
    }
  }
}
