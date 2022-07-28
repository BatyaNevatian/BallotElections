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
    public class AccountDALHandler
    {
        public async Task<int> Register(string tz, string email, string fullName, bool gender, string city, string password)
        {
            try
            {
                using (BaseDataContext dc = new BaseDataContext())
                {
                    T_Voter t_Voter = new T_Voter();
                    t_Voter.city = city;
                    t_Voter.FullName = fullName;
                    t_Voter.gender = gender;
                    t_Voter.mail = email;
                    t_Voter.tz = tz;
                    t_Voter.T_VoterPasswords.Add(new T_VoterPassword() { Password = password });
                    dc.T_Voters.Add(t_Voter);
                    await dc.SaveChangesAsync();
                    return t_Voter.IdVoter;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Login(string tz,string password)
        {
            try
            {
                using (BaseDataContext dc = new BaseDataContext())
                {
                    bool result = await (from v in dc.T_Voters
                                         join p in dc.T_VoterPasswords on v.IdVoter equals p.VoterId
                                         where v.tz == tz && p.Password == password
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
