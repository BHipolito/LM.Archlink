using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMArchlink.Models;
using System.IO;
using LMArchlink.Service;
using Microsoft.Extensions.Options;

namespace LMArchlink.Controllers
{
    [Route("api/lmarchlink")]
    [ApiController]
    public class LMArchlinkController : ControllerBase
    {

        private readonly MappingService _service;

        public LMArchlinkController(IOptions<MappingService> service)
        {
            _service = service.Value;
        }

        // POST api/lmarchlink/import
        [HttpPost("import")]
        public Response<List<ArchlinkModel>> Import(IFormFile formFile)
        {       

            if (formFile == null || formFile.Length <= 0)
            {
                return Response<List<ArchlinkModel>>.GetResult(-1, "formfile is empty");
            }

            if (!Path.GetExtension(formFile.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return Response<List<ArchlinkModel>>.GetResult(-1, "Not Support file extension");
            }

            try
            {
                var data = _service.MapFormService(formFile);

                // add list to db ..
                // SaveToSomewhere()

                // Send list to Archlink
                // -- ArchlinkAPI(list)

                // here just read and return
                return Response<List<ArchlinkModel>>.GetResult(0, "OK", data);
            }
            catch (Exception ex)
            {
                return Response<List<ArchlinkModel>>.GetResult(-1, ex.Message);
            }


            
        }
    }
}