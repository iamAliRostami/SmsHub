using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Domain.Entity
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;   
    }
}
