using Application.UseCases.GetTopicsData.Output;

namespace Application.UseCases.GetTopicsData
{
    public interface IGetTopicsDataUseCase
    {
        public Task<GetTopicsDataOutput> ExecuteAsync();
    }
}
