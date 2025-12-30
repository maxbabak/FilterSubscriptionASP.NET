namespace hm11._12.Models;

public class Subscription
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public SubscriptionType Type { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;
}