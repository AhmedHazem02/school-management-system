using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Department.Query.DTOs;
using SchoolProject.Core.Features.Department.Query.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]  
    public class DepartmentController :AppBaseController
    {

      [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int Id)
        {
            return NewResult(await _mediator.Send(new GetDepartmentById(Id)));
        }
    }
}
