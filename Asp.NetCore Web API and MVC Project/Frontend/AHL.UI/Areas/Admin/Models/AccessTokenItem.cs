namespace AHL.UI.Areas.Admin.Models
{
    public class AccessTokenItem
    {
        public List<string>? Cleims { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
