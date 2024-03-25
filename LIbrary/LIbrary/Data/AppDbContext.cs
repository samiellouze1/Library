using LIbrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LIbrary.Data
{
    public class AppDbContext: IdentityDbContext<User>
    {

    }
}
