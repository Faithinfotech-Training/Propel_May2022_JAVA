using CMSByTeamJava.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMSByTeamJava.Repository
{
    public interface IUsersRepository
    {
        public Task<ActionResult<Users>> GetUsersbypassword(string UserName, string Password);
    }
}
