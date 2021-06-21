using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace MISA.DEMO.API.Controllers
{
    // create a attribuite and router
    [ApiController]
    [Route("v1")]

    public class CustomerController : ControllerBase
    {
        List<Customer> listCustomer = new List<Customer>
        {
            new Customer
            {
                ID = 1,
                CustomerName = "Pham Quang Huy",
                Address = "217 Mai Dich",
                Birthday =  new DateTime(2000, 12, 14),
            },
            new Customer
            {
                ID = 2,
                CustomerName = "Nguyen Van A",
                Address = "217 Mai Dich",
                Birthday =  new DateTime(1999, 11, 5),
            },
            new Customer
            {
                ID = 3,
                CustomerName = "Nguyen Van B",
                Address = "217 Mai Dich",
                Birthday =  new DateTime(1998, 10, 14),
            },
            new Customer
            {
                ID = 4,
                CustomerName = "Nguyen Van C",
                Address = "217 Mai Dich",
                Birthday =  new DateTime(1997, 9, 14),
            },
            new Customer
            {
                ID = 5,
                CustomerName = "Nguyen Van D",
                Address = "217 Mai Dich",
                Birthday =  new DateTime(1996, 8, 14),
            },
            new Customer
            {
                ID = 6,
                CustomerName = "Nguyen Van E",
                Address = "217 Mai Dich",
                Birthday =  new DateTime(1995, 7, 5),
            },
        };

        /// <summary>
        ///  get data customer
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Customer")]
        public JsonResult GetCustomers()
        {
            var connectionString = "User Id=dev;Host=35.194.135.168;Port= 3306; Database=MISACukCuk Password=12345678@Abc; Charater Set=utf8";
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var customer = dbConnection.Query<Customer>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);
            /* get all data*/
            return Ok(customer);
            /*return listCustomer;*/
        }

        /// <summary>
        /// install data to customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Customer")]
        public List<Customer> InsertCustomer (Customer customer)
        {

            /* add customer */
            try
            {
                listCustomer.Add(customer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return listCustomer;
        }

        /// <summary>
        /// update data to customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Customer")]
        public List<Customer> UpdateCustomer(Customer customer)
        {

            /* add customer */
            try
            {
                var obj = listCustomer.FirstOrDefault(_ => _.ID == customer.ID);
                if (obj != null) {
                    obj.CustomerName = customer.CustomerName;
                    obj.Address = customer.Address;
                    obj.Birthday = customer.Birthday;
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return listCustomer;
        }

        /// <summary>
        /// delete data to customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Customer")]
        public List<Customer> DeleteCustomer(int ID)
        {

            /* add customer */
            try
            {
                var obj = listCustomer.FirstOrDefault(_ => _.ID == ID);
                if (obj != null)
                {
                    listCustomer.Remove(obj);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return listCustomer;
        }

    }
}
