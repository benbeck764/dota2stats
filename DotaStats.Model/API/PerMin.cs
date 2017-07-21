﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotaStats.Model.API
{
    public class PerMin
    {
        public PerMin()
        {
            GoldPerMinute = 0;
            XpPerMinute = 0;
        }

        [JsonProperty("gpm")]
        public int GoldPerMinute { get; set; }
        [JsonProperty("xpm")]
        public int XpPerMinute { get; set; }
    }
}
