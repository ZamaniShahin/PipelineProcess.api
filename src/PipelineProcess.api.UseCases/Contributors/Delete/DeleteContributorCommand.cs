using Ardalis.Result;
using Ardalis.SharedKernel;

namespace PipelineProcess.api.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
