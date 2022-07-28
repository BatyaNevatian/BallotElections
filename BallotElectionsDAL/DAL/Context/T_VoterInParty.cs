using System;
using System.Collections.Generic;

#nullable disable

namespace BallotElectionsDAL.DAL.Context
{
    public partial class T_VoterInParty
    {
        public int IdPointerInParty { get; set; }
        public int PartyId { get; set; }
        public int VoterId { get; set; }
        public DateTime date { get; set; }

        public virtual T_Party Party { get; set; }
        public virtual T_Voter Voter { get; set; }
    }
}
