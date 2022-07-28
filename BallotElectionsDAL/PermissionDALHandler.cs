using BallotElectionsDAL.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallotElectionsDAL
{
    public class PermissionDALHandler
    {
        public async Task<bool> CheckUserPermission(int voterId, int permissionId)
        {
            try
            {
                using (BaseDataContext dc = new BaseDataContext())
                {
                    bool result = dc.T_VoterPermissions.Any(a => a.VoterId == voterId && a.PermissionId == permissionId);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
