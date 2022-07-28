using BallotElectionsDAL.DAL.Context;
using BallotElectionsDAL.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using BallotElectionsDAL.Enums;
using System.Transactions;

namespace BallotElectionsDAL
{
    public class PartyDALHandler
    {

        public async Task<List<PartyDTO>> GetList()
        {
            try
            {
                using (BaseDataContext dc = new BaseDataContext())
                {
                    List<PartyDTO> parties = await dc.T_Parties
                        .Select(a => new PartyDTO
                        {
                            description = a.Description,
                            partyId = a.IdParty,
                            photo = a.Photo,
                            name = a.Name
                        }).ToListAsync();
                    return parties;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<List<StatisticDTO>> GetStatistic(int groupById)
        {
            try
            {
                using (BaseDataContext dc = new BaseDataContext())
                {
                    List<StatisticDTO> result = await (from v in dc.T_Voters
                                                       join vp in dc.T_VoterInParties on v.IdVoter equals vp.VoterId
                                                       join p in dc.T_Parties on vp.PartyId equals p.IdParty
                                                       select new
                                                       {
                                                           city = v.city,
                                                           gender = v.gender ? GenderEnum.female.ToString() : GenderEnum.male.ToString(),
                                                           p.Name
                                                       }).GroupBy(s => new StatisticDTO { partyName = s.Name, columnDynamic = groupById == 1 ? s.gender : s.city })
                                                 .Select(a => a.Key).ToListAsync();
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
