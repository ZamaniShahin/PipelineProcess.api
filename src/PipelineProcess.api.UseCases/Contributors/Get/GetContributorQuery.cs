using Ardalis.Result;
using Ardalis.SharedKernel;

namespace PipelineProcess.api.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
