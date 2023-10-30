using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mis321_pa4_aevansmartinez.models;
using mis321_pa4_aevansmartinez.interfaces;
using mis321_pa4_aevansmartinez.database;

namespace mis321_pa4_aevansmartinez.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        // GET:  GET ALL EXERCISES
        [HttpGet(Name="GetExercises")]
        public List<Exercise> Get()
        {
            IGetAllExercises myExercises = new GetAllExercises();
            return myExercises.GetAllExercises();
        }

        // GET: GET ONE EXERCISE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE?
        [HttpGet("{id}", Name = "GetExercisee")]
        public Exercise Get(int id)
        {
            IGetExercise myExercise = new GetExercise();
            return myExercise.GetExercise(id);
        }

        // POST: CREATE EXERCISE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE?
        [HttpPost( Name = "CreateExercise")]
        public void Post([FromBody] Exercise value)
        {
            ICreateExercise newExercise = new CreateExercise();
            newExercise.CreateExercise(value);
            Console.WriteLine(value.activityType);
        }

        // PUT: DEL/PIN EXERCISE
        //[HttpPut("{id}")]
        [HttpPut( Name = "DelPinExercise")]
        public void Put(Exercise myExercise){
            //public void Put(int id, [FromBody] Exercise value)
        
            IDelPinExercise editExercise = new DelPinExercise();
            editExercise.DelPinExercise(myExercise);
        }

        // DELETE: DONT HARD DELETE THINGS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE?
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine(id);
        }
    }
}
