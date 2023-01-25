using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment1.Controllers
{
    public class AddTenController : ApiController
    {

        /// <summary>
        /// This method returns 10 more than the integer input {id}
        /// </summary>
        /// <param name="id">input number</param>
        /// <returns>input number add 10 which the expression is ({id}+10)</returns>
        /// <example>
        /// GET: api/AddTen/21  -->  31
        /// </example>
        /// <example>
        /// GET: api/AddTen/0  -->  10
        /// </example>
        /// <example>
        /// GET: api/AddTen/-9  -->  1
        /// </example>
        public int Get(int id)
        {
            int addTen = id + 10;
            return addTen;
        }

    }
}
