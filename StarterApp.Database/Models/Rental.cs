namespace StarterApp.Database.Models;

public class Rental
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public string ItemTitle { get; set; }

    public string BorrowerName { get; set; }

    public string Status { get; set; }

    public bool IsPending => Status == "Requested";
}