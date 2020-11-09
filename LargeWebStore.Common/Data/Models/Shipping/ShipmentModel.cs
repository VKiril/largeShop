﻿using LargeWebStore.Common.Domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Shipping
{
    public class ShipmentModel : ModelBase
    {
        public string State { get; set; }
        public string Tracking { get; set; }
    }
}
