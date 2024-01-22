using BlazorLeilart.Models.Products;

namespace BlazorLeilart.Models.Auction;

using System;

public class Auction
{
    public int id { get; private set; }
    public int auction_type_id { get; private set; }
    public int product_id { get; private set; }
    public int? minimum_value { get; private set; }
    public int? initial_value { get; private set; }
    public int? increment { get; private set; }
    public DateTime start { get; private set; }
    public DateTime end { get; private set; }
    public int? current_bid { get; private set; }
    public bool status { get; private set; }
    
    public Product Product { get; set; }

    public Auction(int id, int auctionTypeId, int productId, int? minimumValue, int? initialValue, int? increment, DateTime start, DateTime end, int? currentBid, bool status)
    {
        this.id = id;
        this.auction_type_id = auctionTypeId;
        this.product_id = productId;
        this.minimum_value = minimumValue;
        this.initial_value = initialValue;
        this.increment = increment;
        this.start = start;
        this.end = end;
        this.current_bid = currentBid;
        this.status = status;
        this.Product = null;
    }


    public Auction()
    {
        this.id = -1;
        this.auction_type_id = -1;
        this.product_id = -1;
        this.minimum_value = -1;
        this.initial_value = -1;
        this.increment = -1;
        this.start = System.DateTime.Now;
        this.end = System.DateTime.Now;
        this.current_bid = -1;
        this.status = false;
        this.Product = null;
    }
    

}
