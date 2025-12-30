namespace hm11._12.Controllers;

using hm11._12.Data;
using hm11._12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // 1. Ім'я починається на A
    [HttpGet("name-starts-a")]
    public IActionResult UsersNameStartsWithA()
    {
        var users = _context.Users
            .Where(u => u.FirstName.StartsWith("A"))
            .ToList();

        return Ok(users);
    }

    // 2. Користувачі з підписками
    [HttpGet("with-subscriptions")]
    public IActionResult UsersWithSubscriptions()
    {
        var users = _context.Users
            .Include(u => u.Subscriptions)
            .Where(u => u.Subscriptions.Any())
            .ToList();

        return Ok(users);
    }

    // 3. Перші 5 Premium
    [HttpGet("premium-first5")]
    public IActionResult First5PremiumUsers()
    {
        var users = _context.Users
            .Where(u => u.Subscriptions.Any(s => s.Type == SubscriptionType.Premium))
            .Select(u => u.FirstName)
            .Take(5)
            .ToList();

        return Ok(users);
    }

    // 4. Користувач з найбільшою кількістю підписок
    [HttpGet("most-subscriptions")]
    public IActionResult UserWithMostSubscriptions()
    {
        var user = _context.Users
            .Include(u => u.Subscriptions)
            .OrderByDescending(u => u.Subscriptions.Count)
            .FirstOrDefault();

        return Ok(user);
    }

    // 5. Free підписки, які закінчились
    [HttpGet("expired-free")]
    public IActionResult ExpiredFreeSubscriptions()
    {
        var subs = _context.Subscriptions
            .Where(s => s.Type == SubscriptionType.Free && s.EndDate < DateTime.Now)
            .ToList();

        return Ok(subs);
    }
}