using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace task_api.Models
{
    public class User:IdentityUser<int>
    {
        public string UserName { get; set;}
    }
}