using DataAcces.Concrete.EntityFramework;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetCpuAndRam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class can : ControllerBase
    {


        SimpleContextDb db = new SimpleContextDb();
      
            public string listele()
        {
            string result = "";
            List<User> userlistesi = db.Users.ToList();
            foreach(User user in userlistesi)
            {
                result += "" + user.Cpu +"       " +
                    "";
            }  
            return result;
        }

       
    }
    

}

