using BlazorLeilart.Models.Bidding;

namespace BlazorLeilart.Data.Interfaces;

public interface IBiddings
{
    Task<Bidding> GetBiddingByIdAsync(string id);
    Task<int> ContainsKeyAsync(string id);
    Task<bool> PutBiddingAsync(Bidding bidding);
    Task<bool> RemoveBiddingByIdAsync(string id);
    Task<bool> UpdateBidding(Bidding bidding);
    Task<List<Bidding>> GetAllBiddingsAsync();
    Task<List<Bidding>> GetAllBiddingsFilteredbyAuctionAsync(string id);
    Task<List<Bidding>> GetBiddingByUserAsync(string id);
    Task<List<Bidding>> GetBiddingsbyUserAndAuctionAsync(string userid, string auctionid);
    Task<Bidding> GetHighestBidinAuctionAsync(string auctionId);
}