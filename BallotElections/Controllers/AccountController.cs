using BallotElectionsBLL;
using BallotElectionsDAL.DTOS;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BallotElections.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {

        private AccountHandler _accountHandler;

        AccountHandler accountHandler
        {
            get
            {
                if (accountHandler == null)
                {
                    _accountHandler = new AccountHandler();
                }
                return _accountHandler;
            }
        }
     

        [HttpPost]
        [Route("Register")]
        public async Task<int> Register([FromRoute] int idVoter, [FromQuery] string tz, [FromQuery] string email, [FromQuery] string fullName,
            [FromQuery] bool gender, [FromQuery] string city, [FromQuery] string password)
        {
            try
            {
                int voterId =  await _accountHandler.Register(idVoter,  tz,  email,  fullName, gender,  city,  password);
                return voterId;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return 0;
            }
        }


        [HttpPost]
        [Route("Login")]
        public async Task<string> Login([FromQuery] string tz, [FromQuery] string password)
        {
            try
            {
                string token  = await _accountHandler.Login( tz,  password);
                return token;
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
                return null;
            }
        }

    }

}
