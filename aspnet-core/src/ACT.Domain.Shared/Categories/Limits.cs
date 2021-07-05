using Abp.Domain.Values;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACT.Categories
{
    public class Limits
    {
        public string Name { get; set; }
        public int type { get; set; }
        public int speedLimit { get; set; }
        public int speedLimitHysteresis { get; set; }
        public int duration { get; set; }
        public int startHour { get; set; }
        public int endHour { get; set; }
    }
}
