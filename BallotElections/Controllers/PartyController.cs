using BallotElectionsBLL;
using BallotElectionsDAL.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BallotElections.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartyController : ControllerBase
    {

        private PartyHandler _partyHandler;


        PartyHandler partyHandler
        {
            get
            {
                if (partyHandler == null)
                {
                    _partyHandler = new PartyHandler();
                }
                return _partyHandler;
            }
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<List<PartyDTO>> GetList()
        {
            try
            {
                List<PartyDTO> parties = await _partyHandler.GetList();
                return parties;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return null;
            }
        }

        [HttpPost]
        [Route("Voting")]
        public async Task<int> Voting([FromQuery] string tz, [FromRoute] int partyId)
        {
            try
            {
                int result = await _partyHandler.Voting(tz, partyId);
                return result;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return 0;
            }
        }


        [HttpGet]
        [Route("GetStatistic")]
        public async Task<List<StatisticDTO>> GetStatistic([FromRoute] int groupById, [FromRoute] int voterId)
        {
            try
            {
                List<StatisticDTO> result = await _partyHandler.GetStatistic(groupById, voterId);
                return result;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return null;
            }
        }
    }
}
