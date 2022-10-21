using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharpDriver.Core.Results {
    public class ParticipantResult {
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }

        public int? final_rank { get; set; }

    }
}
