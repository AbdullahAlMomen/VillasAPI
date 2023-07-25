using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VillasAPICore.DataStore;
using VillasAPICore.Models.DTO;
using VillasAPICore.Models.Entity;

namespace VillasAPICore.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet("GetVillas")]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return VillaDataStore.VillaDTOs;
            
        }


        [HttpGet("GelVilla/{id:int}")]
        public VillaDTO GetVillas(int id)
        {
            return VillaDataStore.VillaDTOs.FirstOrDefault(x => x.Id == id); ;

        }


    }
}
