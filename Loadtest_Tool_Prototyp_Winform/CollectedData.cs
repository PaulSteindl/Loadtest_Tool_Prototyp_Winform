using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loadtest_Tool_Prototyp_Winform
{
    public class CollectedData
    {
        public string Send { get; set; }
        public string Response { get; set; }
        public long Time { get; set; }
        public bool Success { get; set; }
        public long SendKb { get; set; }
        public long ReceiveKb { get; set; }
    }
}
