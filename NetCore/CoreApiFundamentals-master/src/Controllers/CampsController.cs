using AutoMapper;
using CoreCodeCamp.Data;
using CoreCodeCamp.Data.Entities;
using CoreCodeCamp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _campRepository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public CampsController(ICampRepository campRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            _campRepository = campRepository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<CampModel[]>> GetCamps(bool includeTalks = false)
        {
            try
            {
                var results = await _campRepository.GetAllCampsAsync(includeTalks);
                return _mapper.Map<CampModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database errror");
            }
        }

        [HttpGet("{moniker:string}")]
        public ActionResult<CampModel> Get(string moniker)
        {
            try
            {
                var result = _campRepository.GetSpeakersByMonikerAsync(moniker);
                if (result == null) return NotFound();

                return _mapper.Map<CampModel>(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database errror");
            }
        }

        [HttpGet("serach")]
        public async Task<ActionResult<CampModel[]>> SearchByDate(DateTime theDate, bool includeTalks = false)
        {
            try
            {
                var results = await _campRepository.GetAllCampsByEventDate(theDate, includeTalks);
                if (!results.Any()) return NotFound();

                return _mapper.Map<CampModel[]>(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database errror");
            }
        }

        [HttpPost]
        public async Task<ActionResult<CampModel>> Post(CampModel model)
        {
            try
            {
                var existing = await _campRepository.GetCampAsync(model.Moniker);
                if (existing != null)
                {
                    return BadRequest("Moniker in use");
                }

                var location = _linkGenerator.GetPathByAction("Get", "Camps", new { moniker = model.Moniker });

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Could use no moniker");
                }

                var camp = _mapper.Map<Camp>(model);
                _campRepository.Add(camp);

                if (await _campRepository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<CampModel>(camp));
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database errror");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<CampModel>> Put(string moniker, CampModel model)
        {
            try
            {
                var olsCamp = await _campRepository.GetCampAsync(moniker);
                if (olsCamp == null) return NotFound($"Could not find {moniker}");

                //////////////
                _mapper.Map(model, olsCamp);

                if (await _campRepository.SaveChangesAsync())
                {
                    return _mapper.Map<CampModel>(olsCamp);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database errror");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string moniker)
        {
            try
            {
                var oldcamp = await _campRepository.GetCampAsync(moniker);
                if (oldcamp == null) return NotFound();

                _campRepository.Delete(oldcamp);

                if (await _campRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Database errror");
            }

            return BadRequest("Failed to delete the camp");
        }
    }
}