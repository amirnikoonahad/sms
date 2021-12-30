using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sms.Models;
using Kavenegar;

namespace sms.Controllers
{
    public class HomeController : Controller
    {
       private readonly context _context;
       public static int codesms;
       public HomeController(context context)
       {
           _context=context;
       }




        public IActionResult Index()
        {
            
            return View();
        }




       public IActionResult sendsms(tbl_user us)
        {

            Random rnd=new Random();
            int c=rnd.Next(1000,9999);
             var api = new KavenegarApi("3871353043697339486A70384F544A4A574C74612B51432F4C7A4B305076645457396F5267456F7A5A34383D");
            api.VerifyLookup(us.phone, c.ToString(), "taxijo");

          tbl_user user=new tbl_user();
          user.name=us.name;
            user.family=us.family;
              user.phone=us.phone;

              _context.tblUsers.Add(user);
              _context.SaveChanges();


              tbl_sms sms=new tbl_sms();
              sms.code=c;
              sms.id_user=_context.tblUsers.Max(a=>a.id);

               _context.tbl_smss.Add(sms);
              _context.SaveChanges();
         
         codesms=c;





            return RedirectToAction("check");
        }


        public IActionResult check()
        {


            return View();
        }
    
    [HttpPost]
         public IActionResult check(tbl_sms sm)
        {
           if (sm.code==codesms)
           {
              return RedirectToAction("panel");
           }else
           {

               ViewBag.msg="dadash be fanayi";
           }

            return View();
        }
        

       
    }
}
