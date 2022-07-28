using System;
using System.Collections.Generic;

#nullable disable

namespace BallotElectionsDAL.DAL.Context
{
    public partial class T_Party
    {
        public T_Party()
        {
            T_VoterInParties = new HashSet<T_VoterInParty>();
        }

        public int IdParty { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<T_VoterInParty> T_VoterInParties { get; set; }
    }
}
