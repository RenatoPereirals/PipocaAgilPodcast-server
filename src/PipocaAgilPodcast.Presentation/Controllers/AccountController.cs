using Microsoft.AspNetCore.Mvc;
using PipocaAgilPodcast.Presentation.Modles;
namespace PipocaAgilPodcast.Presentation.Controller;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    public IEnumerable<Account> _account = new Account[] {
        new() {
            Id = 1,
            Name = "Renato",
            Email = "renato@exemplo.com",
            DateOfBirth = "08/05/1990",
        },
         new() {
            Id = 2,
            Name = "Maira",
            Email = "maria@exemplo",
            DateOfBirth = "08/05/1991",
        },
         new() {
            Id = 3,
            Name = "João",
            Email = "Joao@exemplo",
            DateOfBirth = "08/05/2000",
        }
    };

    [HttpGet]
    public IEnumerable<Account> Get()
    {
        return _account;
    }

    [HttpGet("{id}")]
    public IEnumerable<Account> GetById(int id) {
        return _account.Where(account => account.Id == id);
    }
}
