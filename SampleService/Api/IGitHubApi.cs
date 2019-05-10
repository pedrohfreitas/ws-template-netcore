using Refit;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Api
{
    public interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<User> GetUser(string user);
    }
}
