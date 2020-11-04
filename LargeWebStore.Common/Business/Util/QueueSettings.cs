﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Business.Util
{
    public class QueueSettings
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
    }
}
