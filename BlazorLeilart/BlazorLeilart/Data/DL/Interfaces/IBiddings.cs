using BlazorLeilart.Models.Bidding;

namespace BlazorLeilart.Data.DL.Interfaces;

public interface IBiddings
{
    Task<Bidding> GetBiddingByIdAsync(string id);
    Task<int> ContainsKeyAsync(string id);
    Task<bool> PutBiddingAsync(Bidding bidding);
    Task<bool> RemoveBiddingByIdAsync(string id);
    Task<bool> UpdateBidding(Bidding bidding);
    Task<List<Bidding>> GetAllBiddingsAsync();
}