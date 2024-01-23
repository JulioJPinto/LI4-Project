using System.Runtime.CompilerServices;

namespace BlazorLeilart.Authentication;

public class TokenSession
{
    private string token;

    public TokenSession(string email)
    {
        this.token = Base64Encode(email);
    }
 
    public string getToken()
    {
        return this.token;
    }
    public string getDecodedToken()
    {
        return Base64Decode(this.token);
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