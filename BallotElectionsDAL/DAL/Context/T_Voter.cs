using System;
using System.Collections.Generic;

#nullable disable

namespace BallotElectionsDAL.DAL.Context
{
    public partial class T_Voter
    {
        public T_Voter()
        {
            T_VoterInParties = new HashSet<T_VoterInParty>();
            T_VoterPasswords = new HashSet<T_VoterPassword>();
            T_VoterPermissions = new HashSet<T_VoterPermission>();
        }

        public int IdVoter { get; set; }
        public string tz { get; set; }
        public string mail { get; set; }
        public string FullName { get; set; }
        public bool gender { get; set; }
        public string city { get; set; }

        public virtual ICollection<T_VoterInParty> T_VoterInParties { get; set; }
        public virtual ICollection<T_VoterPassword> T_VoterPasswords { get; set; }
        public virtual ICollection<T_VoterPermission> T_VoterPermissions { get; set; }
    }
}
