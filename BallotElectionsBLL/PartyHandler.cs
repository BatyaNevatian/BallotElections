using BallotElectionsDAL;
using BallotElectionsDAL.DTOS;
using BallotElectionsDAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallotElectionsBLL
{
    public class PartyHandler
    {

        private static PartyDALHandler partyDalHandler
        {
            get => new PartyDALHandler();
        }

        private static VotingDALHandler votingDalHandler
        {
            get => new VotingDALHandler();
        }

        private static PermissionDALHandler permissionDALHandler
        {
            get => new PermissionDALHandler();
        }

        public async Task<int> Voting(string tz,  int partyId)
        {
            if (partyId != 0 || string.IsNullOrEmpty(tz))
            {
                string message = "Error";
                throw new Exception(message);
            }
            if (await votingDalHandler.CheckIfExists(tz,partyId))
            {
                string message = "Exists";
                throw new Exception(message);
            }

            int result = await votingDalHandler.Add(tz, partyId);
            return result;
        }

        public async Task<List<PartyDTO>> GetList()
        {
            List<PartyDTO> parties = await partyDalHandler.GetList();
            return parties;
        }

        public async Task<List<StatisticDTO>> GetStatistic(int groupById, int voterId)
        {
            if (!await permissionDALHandler.CheckUserPermission(voterId, (int)UserPermissionEnum.Administrator))
            {
                string message = "User doesnt have permissoin";
                throw new Exception(message);
            }
            List<StatisticDTO> result = await partyDalHandler.GetStatistic(groupById);
            return result;
        }
    }
}
