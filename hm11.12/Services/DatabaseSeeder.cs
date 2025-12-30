namespace hm11._12.Services;

using hm11._12.Data;
using hm11._12.Models;

public static class DatabaseSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any())
            return;

        var users = new List<User>
        {
            new User
            {
                FirstName = "Andrew",
                LastName = "Johnson",
                BirthDate = new DateTime(2000, 1, 1),
                Email = "andrew@test.com",
                Subscriptions =
                {
                    new Subscription
                    {
                        Name = "Free Plan",
                        Price = 0,
                        StartDate = DateTime.Now.AddMonths(-3),
                        EndDate = DateTime.Now.AddMonths(-1),
                        Type = SubscriptionType.Free
                    },
                    new Subscription
                    {
                        Name = "Premium Plan",
                        Price = 30,
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(1),
                        Type = SubscriptionType.Premium
                    }
                }
            },
            new User
            {
                FirstName = "Alex",
                LastName = "Brown",
                BirthDate = new DateTime(1999, 5, 5),
                Email = "alex@test.com"
            },
            new User
            {
                FirstName = "Anna",
                LastName = "Smith",
                BirthDate = new DateTime(2001, 3, 22),
                Email = "anna@test.com",
                Subscriptions =
                {
                    new Subscription
                    {
                        Name = "Free Plan",
                        Price = 0,
                        StartDate = DateTime.Now.AddMonths(-2),
                        EndDate = DateTime.Now.AddDays(-10),
                        Type = SubscriptionType.Free
                    }
                }
            }
        };

        context.Users.AddRange(users);
        context.SaveChanges();
    }
}
