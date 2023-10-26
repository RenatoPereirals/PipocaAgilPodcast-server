using Microsoft.AspNetCore.Mvc;
using PipocaAgilPodcast.API.Models;

namespace PipocaAgilPodcast.API.Controllers;

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
        }
    };

    [HttpGet(Name = "GetAccount")]
    public IEnumerable<Account> Get()
    {
        return _account;
    }
}
