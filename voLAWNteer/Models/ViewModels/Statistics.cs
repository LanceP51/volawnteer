using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace voLAWNteer.Models.ViewModels
{
    public class Statistics
    {
        public int ServiceInstances { get; set; }
        public List<Lawn> ApprovedLawns { get; set; }
        public List<Lawn> DeniedLawns { get; set; }
        public List<Lawn> PendingLawns { get; set; }
    }
}
