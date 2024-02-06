using Infomedia.Server.Models.RequestDto;
using Infomedia.Server.Models.ResponseDto;

namespace Infomedia.Server.Services.Interfaces
{
    public interface IQueries
    {
        Task<PurchaseResponseDto> PurchaseTransactionAsync(PurchaseInputDto inputDto);
        Task SendNotificationAsync(PurchaseResponseDto inputDto);
    }
}
