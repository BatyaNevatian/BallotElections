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
    public class CityController: ControllerBase
    {
        private CityHandler _cityHandler;

        CityHandler cityHandler
        {
            get
            {
                if (cityHandler == null)
                {
                    _cityHandler = new CityHandler();
                }
                return _cityHandler;
            }
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<List<City>> GetList([FromQuery] string search)
        {
            try
            {
                List<City> result = await _cityHandler.GetList(search);
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
