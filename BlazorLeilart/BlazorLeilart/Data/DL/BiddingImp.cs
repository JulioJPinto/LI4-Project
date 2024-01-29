using BlazorLeilart.Models.Bidding;
using Dapper;

namespace BlazorLeilart.Data.Interfaces.Auctions
{
    public class BiddingImp : IBiddings
    {
        private readonly IDBConnection _dbConnection;

        public BiddingImp(IDBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Bidding> GetBiddingByIdAsync(string id)
        {
            string query = "SELECT * FROM [bidding] WHERE id = @inputId";
            return await _dbConnection.Connection.QueryFirstOrDefaultAsync<Bidding>(query, new { inputId = id });
        }

        public async Task<int> ContainsKeyAsync(string id)
        {
            string query = "SELECT COUNT(*) FROM [bidding] WHERE id = @inputId";
            return await _dbConnection.Connection.ExecuteScalarAsync<int>(query, new { inputId = id });
        }

        public async Task<bool> PutBiddingAsync(Bidding bidding)
        {
            if (await ContainsKeyAsync(bidding.Id.ToString()) == 0)
            {
                string insertQuery = "INSERT INTO [bidding] (time, value, auction_id, user_id) " +
                                     "VALUES (@Time, @Value, @AuctionId, @UserId)";
                await _dbConnection.Connection.ExecuteAsync(insertQuery, new
                {
                    Time = bidding.time,
                    Value = bidding.value,
                    AuctionId = bidding.auction_id,
                    UserId = bidding.user_id
                });
                
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveBiddingByIdAsync(string id)
        {
            if (await ContainsKeyAsync(id) > 0)
            {
                string query = "DELETE FROM [bidding] WHERE id = @inputId";
                await _dbConnection.Connection.ExecuteAsync(query, new { inputId = id });

                return true;
            }

            return false;
        }

        public async Task<bool> UpdateBidding(Bidding bidding)
        {
            int existingBiddingCount = await ContainsKeyAsync(bidding.Id.ToString());

            if (existingBiddingCount > 0)
            {
                string updateQuery = "UPDATE [bidding] SET time = @Time, value = @Value, " +
                                     "auction_id = @AuctionId, user_id = @UserId " +
                                     "WHERE id = @Id";
                await _dbConnection.Connection.ExecuteAsync(updateQuery, new
                {
                    Id = bidding.Id,
                    Time = bidding.time,
                    Value = bidding.value,
                    AuctionId = bidding.auction_id,
                    UserId = bidding.user_id
                });

                return true;
            }

            return false;
        }

        public async Task<List<Bidding>> GetAllBiddingsAsync()
        {
            return (await _dbConnection.Connection.QueryAsync<Bidding>("SELECT * FROM [bidding] ORDER BY value ASC")).AsList();
        }

        public async Task<List<Bidding>> GetAllBiddingsFilteredbyAuctionAsync(string auctionid)
        {
            return (await _dbConnection.Connection.QueryAsync<Bidding>("SELECT * FROM bidding WHERE auction_id = @id ORDER BY value ASC;", new { id = auctionid })).ToList();
        }

        public async Task<List<Bidding>> GetBiddingByUserAsync(string userid)
        {
            return (await _dbConnection.Connection.QueryAsync<Bidding>(
                "SELECT * FROM bidding WHERE auction_id = @id ORDER BY value ASC;", new { id = userid })).ToList();
        }
        
        public async Task<List<Bidding>> GetBiddingsbyUserAndAuctionAsync(string userid, string auctionid)
        {
            string query = "SELECT * FROM bidding WHERE auction_id = @auctionid AND user_id = @userid ORDER BY value ASC;";

            return (await _dbConnection.Connection.QueryAsync<Bidding>(
                query, new { auctionid, userid })).ToList();
        }

        public async Task<Bidding> GetHighestBidinAuctionAsync(string auctionId)
        {
            // Assuming you have some kind of SQL connection or DbContext (e.g., dbContext)
            // Adjust the following line based on your actual implementation
            string query = $"SELECT TOP 1 * FROM Bidding WHERE AuctionId = @AuctionId ORDER BY Value DESC";

            // Assuming you're using Dapper or some other library for SQL operations
            // Adjust the following line based on your actual implementation
            Bidding highestBid = await _dbConnection.Connection.QueryFirstOrDefaultAsync<Bidding>(query, new { AuctionId = auctionId });

            return highestBid;
        }

    }
}
