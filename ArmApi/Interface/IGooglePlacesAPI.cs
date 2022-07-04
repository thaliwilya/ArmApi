using ArmApi.Model.Services.GoogleAPI;

namespace ArmApi.Interface
{
    public interface IGooglePlacesAPI
    {
        Task<GooglePlacesAPIResponse> ApplyAsync(string? query);

    }
}
