using System;
using System.Collections.Generic;

#nullable disable

namespace BallotElectionsDAL.DAL.Context
{
    public partial class T_VoterPermission
    {
        public int IdVoterPermission { get; set; }
        public int PermissionId { get; set; }
        public int VoterId { get; set; }

        public virtual T_Permission Permission { get; set; }
        public virtual T_Voter Voter { get; set; }
    }
}
