using System;

namespace OWSData.Models.Tables
{
    public partial class GlobalData
    {
        public Guid CustomerGuid { get; set; }
        public string GlobalDataKey { get; set; }
        public string GlobalDataValue { get; set; }
    }
}
