using LargeWebStore.Common.Domain.Data;
using LargeWebStore.Common.Domain.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LargeWebStore.Common.Data.Models.Channel
{
    public class ChannelModel : ModelBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public string Hostname { get; set; }
        public string ThemeName { get; set; }
        public string ContactEmail { get; set; }
    }
}
