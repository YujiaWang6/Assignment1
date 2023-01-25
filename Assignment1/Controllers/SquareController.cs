using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class SquareController : ApiController
    {

        /// <summary>
        /// This method returns the square of the integer input {id}
        /// </summary>
        /// <param name="id">input number</param>
        /// <returns>the square of the input, which is the input number times the input number. The expression is (id*id)</returns>
        /// <example>
        /// GET: api/Square/2     -->  4
        /// </example>
        /// <example>
        /// GET: api/Square/-2     -->  4
        /// </example>
        /// <example>
        /// GET: api/Square/10     -->  100
        /// </example>
        public int Get(int id)
        {
            int square = id * id;
            return square;
        }

    }
}
