using BallotElectionsDAL.DAL.Context;
using BallotElectionsDAL.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallotElectionsDAL
{
  public  class VotingDALHandler
    {
        public async Task<int> Add(string tz, int partyId)
        {
            try
            {
                using (BaseDataContext dc = new BaseDataContext())
                {
                    T_VoterInParty t_VoterInParty = new T_VoterInParty();
                    t_VoterInParty.PartyId = partyId;
                    t_VoterInParty.VoterId = dc.T_Voters.FirstOrDefault(a => a.tz == tz).IdVoter;
                    t_VoterInParty.date = DateTime.Now;

                    dc.T_VoterInParties.Add(t_VoterInParty);
                    await dc.SaveChangesAsync();
                    return t_VoterInParty.IdPointerInParty;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CheckIfExists(string tz, int partyId)
        {
            try
            {
                using (BaseDataContext dc = new BaseDataContext())
                {
                    bool result = await (from v in dc.T_Voters
                                         join vp in dc.T_VoterInParties on v.IdVoter equals vp.VoterId
                                         where v.tz == tz && vp.PartyId == partyId
                                         select v.IdVoter).AnyAsync();

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
