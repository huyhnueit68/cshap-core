using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DEMO.API
{
    public class Customer
    {
        ///<summary>
        /// ID
        ///</summary>
        public int ID { get; set; }
        ///<summary>
        ///Customer name
        ///</summary>
        public string CustomerName { get; set; }
        ///<summary>
        ///Adrress
        ///</summary>
        public string Address { get; set; }
        ///<summary>
        ///Birthday
        ///</summary>
        public DateTime Birthday { get; set; }

    }
}
