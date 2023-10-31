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
    [Route("api/[controller]")]
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
        [HttpPost(Name = "CreateExercise")]
        public int Post([FromBody] Exercise value)
        {
            ICreateExercise newExercise = new CreateExercise();
            return newExercise.CreateExercise(value);
        }

        // PUT: DEL/PIN EXERCISE
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Exercise value){
            IDelPinExercise editExercise = new DelPinExercise();
            editExercise.DelPinExercise(value);
        }

        // DELETE: DONT HARD DELETE THINGS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~DONE?
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Console.WriteLine(id);
        }
    }
}
