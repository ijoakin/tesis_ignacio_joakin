using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBusinessLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        IDBToolsBL _iDBTools;
        private IHostingEnvironment _env;
        public DataController(IDBToolsBL iDBTools, IHostingEnvironment env)
        {
            _iDBTools = iDBTools;
            _env = env;
        }
        [HttpGet("createinitialdata")]
        public bool createinitialdata()
        {
            try
            {
                var webRoot = string.Format("{0}\\Controllers\\SQL\\", _env.ContentRootPath);
                this._iDBTools.CreateInitialData(webRoot);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}