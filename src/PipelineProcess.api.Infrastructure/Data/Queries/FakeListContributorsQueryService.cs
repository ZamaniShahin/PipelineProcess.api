using PipelineProcess.api.UseCases.Contributors;
using PipelineProcess.api.UseCases.Contributors.List;

namespace PipelineProcess.api.Infrastructure.Data.Queries;

public class FakeListContributorsQueryService : IListContributorsQueryService
{
  public Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    List<ContributorDTO> result =
        [new ContributorDTO(1, "Fake Contributor 1", ""),
        new ContributorDTO(2, "Fake Contributor 2", "")];

    return Task.FromResult(result.AsEnumerable());
  }
}
