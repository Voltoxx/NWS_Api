using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NWS_Api1.Context;
using NWS_Api1.Models;

namespace NWS_Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NwsController : Controller
    {
        
        private readonly AppDBContext context;

        public NwsController(AppDBContext context)
        {
            this.context = context;
        }

        
        //GET Nws/GetAllPeople
        [HttpGet("GetAllPeople")]
        public ActionResult<List<Nws>> GetAllPeople()
        {
            return context.nws.ToList();
        }

        /*
        //GET Nws/GetOnePerson
        [HttpGet("GetOnePerson")]

        //POST Nws/InsertOnePerson
        [HttpPost("InsertOnePerson")]

        //PUT Nws/UpdateOnePerson
        [HttpPut("UpdateOnePerson")]

        //DELETE Nws/DeleteOnePerson
        [HttpDelete("DeleteOnePerson")]
        */
    }
}
