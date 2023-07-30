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

        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaDataStore.VillaDTOs);

        }


        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("GetVilla/{id:int}")]
        public ActionResult<VillaDTO> GetVillas(int id)
        {
            if (id <= 0)
                return BadRequest();
            var villa = VillaDataStore.VillaDTOs.FirstOrDefault(x => x.Id == id);

            if (villa == null)
                return NotFound();
            return Ok(villa);

        }

        [HttpPost("SaveVilla")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaDTO villa)
        {

            if (villa == null) return BadRequest();
            if (villa.Id > 0)
                return StatusCode(StatusCodes.Status500InternalServerError);

            villa.Id = VillaDataStore.VillaDTOs.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;

            VillaDataStore.VillaDTOs.Add(villa);

            return Ok(villa);

        }



        [HttpDelete("DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla([FromQuery]int id)
        {
            if (id <= 0) return BadRequest();

            var villa = VillaDataStore.VillaDTOs.Find(x => x.Id == id);
            if (villa == null) return NotFound();

            VillaDataStore.VillaDTOs.Remove(villa);
            return Ok(villa);

        }

        [HttpPut("UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> UpdateVilla([FromBody] VillaDTO villa)
        {
            if (villa == null) return BadRequest();
            if (villa.Id < 0)
                return BadRequest();

            var data = VillaDataStore.VillaDTOs.Find(x =>x.Id == villa.Id);
            if (data == null) return NotFound();

            data.Name = villa.Name;

            return Ok(data);
        }
        
        
    }
}
