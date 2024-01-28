using BlazorLeilart.Models.Auction;
using BlazorLeilart.Models.Bidding;

namespace BlazorLeilart.Data.Interfaces;

public interface IAuction
{
    Task<Auction> GetAuctionbyIdAsync(string id);
    Task<int> ContainsKeyAsync(string id);
    Task<bool> PutAuctionAsync(Auction auction);
    Task<bool> RemoveAuctionByIdAsync(string id);
    Task<bool> UpdateAuction(Auction auction);
    Task<List<Auction>> GetAllAuctionsAsync();

    Task UpdateAuctionBids(Auction auction);

    Task<List<Auction>> GetDistinctAuctionsOrderedByLastBidAsync(string userid);

    Task<List<Auction>> GetAuctionsByLastBidAsync();
}

