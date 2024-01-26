using BlazorLeilart.Models.Auction;
using BlazorLeilart.Models.Products;

namespace BlazorLeilart.Data.Interfaces.Auctions;

public interface IAuction
{
    Task<Auction> GetAuctionbyIdAsync(string id);
    Task<int> ContainsKeyAsync(string id);
    Task<bool> PutAuctionAsync(Auction auction);
    Task<bool> RemoveAuctionByIdAsync(string id);
    Task<bool> UpdateAuction(Auction auction);
    Task<List<Auction>> GetAllAuctionsAsync();
}

