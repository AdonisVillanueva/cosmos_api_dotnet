using CosmosApi.Models;
using NameserviceApi.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NameserviceApi
{
    public interface INameservice
    {
        Task<GasEstimateResponse> PostBuyNameSimulationAsync(BuyNameReq request, CancellationToken cancellationToken = default);
        Task<StdTx> PostBuyNameAsync(BuyNameReq request, CancellationToken cancellationToken = default);
        Task<ResponseWithHeight<WhoIs>> GetWhoIs(string name, CancellationToken cancellationToken = default);
    }
}