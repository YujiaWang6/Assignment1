using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class GreetingController : ApiController
    {
        /// <summary>
        /// This method returns the string "Hello World!"
        /// </summary>
        /// <returns>"Hello World!"</returns>
        ///<example>
        ///POST: api/Greeting     -->  "Hello World!"
        ///</example>
        public string Post()
        {
            return "Hello World!" ;
        }


        /// <summary>
        /// This method returns the string "Greetings to {id} people!" where id is an input number of people.
        /// </summary>
        /// <param name="id">input number of people</param>
        /// <returns>A string which is "Greetings to {id} people!"</returns>
        /// <example>
        /// GET: api/Greeting/3     --> Greetings to 3 people!
        /// </example>
        /// <example>
        /// GET: api/Greeting/6     --> Greetings to 6 people!
        /// </example>
        /// <example>
        /// GET: api/Greeting/0     --> Greetings to 0 people!
        /// </example>
        public string Get(int id)
        {
            string NumberOfPeople = id.ToString();
            return "Greetings to " + NumberOfPeople + " people!";
        }


    }
}
