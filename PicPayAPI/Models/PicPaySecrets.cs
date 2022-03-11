namespace PicPayAPI.Models;

public record PicPaySecrets
{
    public string Token { get; set; }
    public string SellerToken { get; set; }
}