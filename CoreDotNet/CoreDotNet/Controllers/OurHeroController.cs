﻿using CoreDotNet.Model;
using CoreDotNet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurHeroController : ControllerBase
    {
        private readonly IOurHeroService _heroService;

        public OurHeroController(IOurHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] bool? isActive = null)
        {
            return Ok(_heroService.GetAllHeros(isActive));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var hero = _heroService.GetHerosByID(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post(OurHero heroObject)
        {
            var hero = _heroService.AddOurHero(heroObject);

            if (hero == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] OurHero heroObject)
        {
            var hero = _heroService.UpdateOurHero(id, heroObject);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Updated Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_heroService.DeleteHerosByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Deleted Successfully!!!",
                id = id
            });
        }
    }
}
