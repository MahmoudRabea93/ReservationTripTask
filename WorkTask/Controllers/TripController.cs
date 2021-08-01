using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Mapper;
using WorkTask.Model;
using WorkTask.Repos;
using WorkTask.ViewModel;

namespace WorkTask.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        #region Properties
        private DataBaseContext DB = new DataBaseContext();
        private IRepos<Trip> TripRep;
        private IMapper mapper;     
        #endregion
        public TripController(IRepos<Trip> _TripRep, IMapper _mapper)
        {
            this.TripRep = _TripRep;
            this.mapper = _mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var TripList = TripRep.GetAll();
                List<TripDTO> Data = mapper.Map<List<TripDTO>>(TripList);
                return Ok(Data);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var TripByID = TripRep.GetById(id);
                TripDTO Data = mapper.Map<TripDTO>(TripByID);
                return Ok(Data);
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }


        [HttpPost]
        public ActionResult Post(TripVM trip)
        {
            try
            {
                Trip newTrip = new Trip
                {
                    CityName = trip.CityName,
                    Content = trip.Content,
                    CreationDate = DateTime.Now,
                    ImageUrl = trip.ImageUrl,
                    Name = trip.Name,
                    Price = trip.Price,

                };
                TripRep.Create(newTrip);
                return CreatedAtAction("Get", new { id = newTrip.ID }, TripRep.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }

        // PUT api/<Trip>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, TripVM trip)
        {
            try
            {
                Trip newTrip = new Trip
                {
                    CityName = trip.CityName,
                    Content = trip.Content,
                    CreationDate = DateTime.Now,
                    ImageUrl = trip.ImageUrl,
                    Name = trip.Name,
                    Price = trip.Price,

                };
                TripRep.Modfiy(id, newTrip);
                return Ok(TripRep.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }

        // DELETE api/<Trip>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                TripRep.Delete(id);
                return Ok(TripRep.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }
    }
}
