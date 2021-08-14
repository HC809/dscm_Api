using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DiunsaSCM.API.Controllers
{
    [ApiController]
    public class GenericController<TModel> : Controller
    {
        protected readonly IServiceBase<TModel> _service;

        public GenericController(IServiceBase<TModel> service)
        {
            _service = service;
        }


        public async Task<ActionResult> GetAllAsync(long parentId, string searchString = "", int slice = 0)
        {
            ServiceResult<IEnumerable<TModel>> serviceResult;
            if (parentId == 0)
                serviceResult = await _service.GetAllAsync(searchString, slice);
            else
                serviceResult = await _service.GetAllByParentAsync(parentId);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var serviceResult = _service.GetById(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TModel model)
        {
            var serviceResult = _service.Add(model);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] TModel model)
        {
            var serviceResult = _service.Update(model);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var serviceResult = _service.Delete(id);
            if (serviceResult.ResponseCode == ResponseCode.Error)
            {
                return BadRequest(serviceResult);
            }
            return Ok(serviceResult);
        }
    }
}
