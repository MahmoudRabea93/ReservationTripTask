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
                var TripList = TripRep.GetAll();
                List<TripDTO> Data = mapper.Map<List<TripDTO>>(TripList);
                return Ok(Data);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
          
                var TripByID = TripRep.GetById(id);
                TripDTO Data = mapper.Map<TripDTO>(TripByID);
                return Ok(Data);
           
        }


        [HttpPost]
        public ActionResult Post(TripVM trip)
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

        // PUT api/<Trip>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, TripVM trip)
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

        // DELETE api/<Trip>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
                TripRep.Delete(id);
                return Ok(TripRep.GetAll()); 
        }
    }
}
