using BlazorLeilart.Data.Interfaces;
using BlazorLeilart.Models.Auction;
using BlazorLeilart.Models.Bidding;
using BlazorLeilart.Models.Products;
using Dapper;

using BlazorLeilart.Data.Interfaces;

namespace BlazorLeilart.Data.DL;

public class AuctionImp : IAuction
{
    
    private readonly IDBConnection _dbConnection;
    private IAuction _auctionImplementation;

    public AuctionImp(IDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Auction> GetAuctionbyIdAsync(string id)
        {
            string query = "SELECT * FROM [auction] WHERE id = @inputId";
            return await _dbConnection.Connection.QueryFirstOrDefaultAsync<Auction>(query, new { inputId = id });
        }

        public async Task<int> ContainsKeyAsync(string id)
        {
            string query = "SELECT COUNT(*) FROM [auction] WHERE id = @inputId";
            return await _dbConnection.Connection.ExecuteScalarAsync<int>(query, new { inputId = id });
        }

        public async Task<bool> PutAuctionAsync(Auction auction)
        {
            if (await ContainsKeyAsync(auction.id.ToString()) == 0)
            {
                string insertQuery = "INSERT INTO [auction] (auction_type_id, product_id, minimum_value, initial_value, increment, start, [end], current_bid, status) " +
                                     "VALUES (@AuctionTypeId, @ProductId, @MinimumValue, @InitialValue, @Increment, @Start, @End, @CurrentBid, @Status)";
                await _dbConnection.Connection.ExecuteAsync(insertQuery, new
                {
                    AuctionTypeId = auction.auction_type_id,
                    ProductId = auction.product_id,
                    MinimumValue = auction.minimum_value,
                    InitialValue = auction.initial_value,
                    Increment = auction.increment,
                    Start = auction.start,
                    End = auction.end,
                    CurrentBid = auction.current_bid,
                    Status = auction.status
                });

                auction.Product = await _dbConnection.Connection.ExecuteScalarAsync<Product>(
                        "SELECT * FROM product WHERE auction_id = @id ", new {id = auction.product_id});
                auction.Bids = (await _dbConnection.Connection.QueryAsync<Bidding>(
                    "SELECT * FROM bidding WHERE auction_id = @id ORDER BY value ASC;", new { id = auction.id })).ToList();

                return true;
            }

            return false;
        }

        public async Task<bool> RemoveAuctionByIdAsync(string id)
        {
            if (await ContainsKeyAsync(id) > 0)
            {
                string query = "DELETE FROM [auction] WHERE id = @inputId";
                await _dbConnection.Connection.ExecuteAsync(query, new { inputId = id });

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAuction(Auction auction)
        {
            int existingAuctionCount = await ContainsKeyAsync(auction.id.ToString());

            if (existingAuctionCount > 0)
            {
                string updateQuery = "UPDATE [auction] SET auction_type_id = @AuctionTypeId, product_id = @ProductId, " +
                                     "minimum_value = @MinimumValue, initial_value = @InitialValue, increment = @Increment, " +
                                     "start = @Start, [end] = @End, current_bid = @CurrentBid, status = @Status " +
                                     "WHERE id = @Id";
                await _dbConnection.Connection.ExecuteAsync(updateQuery, new
                {
                    Id = auction.id,
                    AuctionTypeId = auction.auction_type_id,
                    ProductId = auction.product_id,
                    MinimumValue = auction.minimum_value,
                    InitialValue = auction.initial_value,
                    Increment = auction.increment,
                    Start = auction.start,
                    End = auction.end,
                    CurrentBid = auction.current_bid,
                    Status = auction.status
                });

                return true;
            }

            return false;
        }

        public async Task<List<Auction>> GetAllAuctionsAsync()
        {
            List<Auction> auctions = (await _dbConnection.Connection.QueryAsync<Auction>("SELECT * FROM auction")).AsList();
            
            List<Product> products = (await _dbConnection.Connection.QueryAsync<Product>("SELECT * FROM product")).AsList();
        
            foreach (Auction auction in auctions)
            {
                auction.Product = products.Find(p => p.id == auction.product_id);
                auction.Bids = (await _dbConnection.Connection.QueryAsync<Bidding>(
                    "SELECT * FROM bidding WHERE auction_id = @id ORDER BY value ASC;", new { id = auction.id })).ToList();
                
            }
            return auctions;
        }

        public async Task UpdateAuctionBids(Auction auction)
        {
            auction.Bids = (await _dbConnection.Connection.QueryAsync<Bidding>(
                "SELECT * FROM bidding WHERE auction_id = @id ORDER BY value ASC;", new { id = auction.id })).ToList();
            
        }
}