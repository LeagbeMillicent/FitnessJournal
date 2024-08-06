using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Domain
{
    public class Login
    {
        public int LogId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
