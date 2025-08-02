using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Time_Chat.Models
{
    public class UserModel
    {
        public Guid Id { get; init; }
        public required string UserName { get; set; }
    }
}