using System.Text;

namespace Leilart.Authentication;

public class TokenSession
{
    private string token { get; }

    public TokenSession(string email)
    {
        this.token = Base64Encode(email);
    }
    
    public static string Base64Encode(string plainText) 
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
    
    public static string Base64Decode(string base64EncodedData) 
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }
    
    public bool confirmSession(string email)
    {
        return (Base64Decode(this.token) == email);
    }
}