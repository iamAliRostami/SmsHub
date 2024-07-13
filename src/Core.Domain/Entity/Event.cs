using SmsHub.Core.Domain.Comman;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.Core.Domain.Entity
{
    [Table(nameof(Event))]
    public class Event :AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;  
        public DateTime Date { get; set; }
    }
}
