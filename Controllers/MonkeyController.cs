using Microsoft.AspNetCore.Mvc;
using Exo4.Models;

namespace Exo4;

public class MonkeyController : Controller
{
    private FakeDbMonkey _fakeDbMonkey;
    
    public MonkeyController(FakeDbMonkey fakeDbMonkey)
    {
        _fakeDbMonkey = fakeDbMonkey;
    }

    public IActionResult Index()
    {
        
        return View(_fakeDbMonkey.GetAll());
    }

    public IActionResult Details(int id)
    {
        return View(_fakeDbMonkey.GetById(id));
    }
    
    public IActionResult CreateRandomMonkey(Monkey monkey)
    {
        monkey = new Monkey
        {
            Name = RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 6),
            Age = new Random().Next(1,100)
        };

        _fakeDbMonkey.Add(monkey);
        return RedirectToAction("Index");
    }
    
    public static string RandomString(string chars, int length)
    {
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}



