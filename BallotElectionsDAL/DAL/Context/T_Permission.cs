using System;
using System.Collections.Generic;

#nullable disable

namespace BallotElectionsDAL.DAL.Context
{
    public partial class T_Permission
    {
        public T_Permission()
        {
            T_VoterPermissions = new HashSet<T_VoterPermission>();
        }

        public int IdPermission { get; set; }
        public string Permission { get; set; }

        public virtual ICollection<T_VoterPermission> T_VoterPermissions { get; set; }
    }
}
