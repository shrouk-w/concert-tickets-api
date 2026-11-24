using kolosB.Models.DTOs;

namespace kolosB.Services;

public interface ICustomerService
{
    public Task<InfoResponseDTO> GetInfoForCustomerAsync(int customerId, CancellationToken token);
    Task InsertCustomerAndPurchasesAsync(RequestDTO request, CancellationToken token);
}