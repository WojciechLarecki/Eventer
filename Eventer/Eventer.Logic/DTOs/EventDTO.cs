﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventer.Logic.DTOs
{
    public class EventDTO
    {
        public DateTime StartDate { get; internal set; }
        public DateTime EndDate { get; internal set; }
        public string Name { get; internal set; }
        public Guid Id { get; internal set; }
        public DateTime? JoinDate { get; internal set; }
    }
}
