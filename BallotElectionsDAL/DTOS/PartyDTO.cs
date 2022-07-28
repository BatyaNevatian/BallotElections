using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallotElectionsDAL.DTOS
{
    public class PartyDTO
    {
        public int partyId { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string photo { get; set; }

    }
}
