using System;
using IBusinessLogic;
using Microsoft.AspNetCore.Hosting;
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
            _iDBTools = iDBTools ?? throw new ArgumentNullException(nameof(iDBTools));
            _env = env ?? throw new ArgumentNullException(nameof(env));
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