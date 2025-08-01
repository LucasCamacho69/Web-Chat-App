using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Real_Time_Chat.Models
{
    public class MessageModel
    {
        public Guid Id { get; init; }
        public Guid UserId { get; set; }
        public string? Content { get; set; }
        public DateTime SendedAt { get; init; }
        public DateTime? EditedAt { get; init; }
    }
}