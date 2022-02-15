﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominic_2005053J.Shared.Domain
{
    public class Symptom : BaseModel
    {
        public string Description { get; set; }
        public int SeverityId { get; set; }
        public bool PerformedSelfTest { get; set; }
    }
}
