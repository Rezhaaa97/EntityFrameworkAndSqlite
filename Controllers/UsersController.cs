

using LECTURE4.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {    
        return Ok(_context.Users.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User newUser)
    {
        var user = _context.Users.Find(id);
        if (user == null) NotFound();
    
        user.Name = newUser.Name;
        user.Email = newUser.Email;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();

        return Ok();
    }

}