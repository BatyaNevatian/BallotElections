using System;
using System.Collections.Generic;

#nullable disable

namespace BallotElectionsDAL.DAL.Context
{
    public partial class T_VoterPassword
    {
        public int IdVoterPassword { get; set; }
        public int VoterId { get; set; }
        public string Password { get; set; }

        public virtual T_Voter Voter { get; set; }
    }
}
