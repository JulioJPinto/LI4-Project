using BlazorLeilart.Data.Interfaces.Auctions;
using BlazorLeilart.Models.Auction;
using Dapper;

namespace BlazorLeilart.Data.DL;

public class AuctionImp : IAuction
{
    
    private readonly IDBConnection _dbConnection;

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
            return (await _dbConnection.Connection.QueryAsync<Auction>("SELECT * FROM [auction]")).AsList();
        }
}