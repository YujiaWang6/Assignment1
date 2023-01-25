using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// This method returns several steps of calculation of input number {id}.
        /// </summary>
        /// <param name="id">input number</param>
        /// <returns>Math.Sqrt(({id}*{id})- ({id} + 10) / 5 )</returns>
        /// <example>
        /// GET: api/NumberMachine/10      --> 9.7979589711327115
        /// </example>
        /// <example>
        /// GET: api/NumberMachine/-5      --> 4.8989794855663558
        /// </example>
        /// <example>
        /// GET: api/NumberMachine/30      --> 29.866369046136157
        /// </example>

        public double Get(double id)
        {
            double calculation = Math.Sqrt((id * id) - (id + 10) / 5);
            return calculation;
        }

    }
}
