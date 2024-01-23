namespace BlazorLeilart.Models.Bidding;

using System;
public class Bidding
{
    public int Id { get; private set; }
    public int value { get; private set; }
    public DateTime time { get; private set; }
    public int auction_id { get; private set; }
    public int user_id { get; private set; }

    public Bidding(int id, int value, int id_leilao, int id_user)
    {
        this.Id = id;
        this.value = value;
        this.time = DateTime.Now;
        this.auction_id = id_leilao;
        this.user_id = id_user;
    }
    
    public Bidding()
    {
        this.Id = -1;
        this.value = -1;
        this.time = DateTime.Now;
        this.auction_id = -1;
        this.user_id = -1;
    }
    
    public class BiddingComparer : IComparer<Bidding>
    {
        public int Compare(Bidding x, Bidding y)
        {
            // Compare based on Montante in descending order
            return y.value.CompareTo(x.value);
        }
    }
}