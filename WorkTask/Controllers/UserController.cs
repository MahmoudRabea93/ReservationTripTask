using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTask.Mapper;
using WorkTask.Model;
using WorkTask.Repos;

namespace WorkTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepos<User> UserRep;
        private IMapper mapper;
        public UserController(IRepos<User> _UserRep, IMapper _mapper)
        {
            this.UserRep = _UserRep;
            this.mapper = _mapper;
        }
        [HttpGet]
        public ActionResult Get()
        {
            List<UserDTO> Data = mapper.Map<List<UserDTO>>(UserRep.GetAll());
            return Ok(Data);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                UserDTO Data = mapper.Map<UserDTO>(UserRep.GetById(id));
                return Ok(UserRep.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post(User user)
        {
            try
            {
                UserRep.Create(user);
                return CreatedAtAction("Get", new { id = user.ID }, UserRep.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, User user)
        {
            try
            {
                UserRep.Modfiy(id, user);
                return Ok(UserRep.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                UserRep.Delete(id);
                return Ok(UserRep.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest("Internal server error :" + ex);
            }
        }
    }
}
