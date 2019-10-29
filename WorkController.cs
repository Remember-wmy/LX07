using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Controllers
{
    [Route("api/[controller]")]
    public class WorkController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public WorkController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Json(DAL.WorkInfo.Instance.GetCount());
        }
        [HttpGet("new")]
        public ActionResult GetNew() {
            var result = DAL.WorkInfo.Instance.GetNew();
            if (result.Count() != 0)
                return Json(Result.Ok(result));
            else
                return Json(Result.Err("记录数为0 "));
        }
        [HttpGet("new")]
        public ActionResult Get(int id)
        {
            var result = DAL.WorkInfo.Instance.GetModel(id);
            if (result!= null)
                return Json(Result.Ok(result));
            else
                return Json(Result.Err("WorkId不存在"));
        }
    }
}
