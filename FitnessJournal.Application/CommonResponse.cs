﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application
{
    public class CommonResponse
    {
        public int Id { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public int Status { get; set; }
    }
}
