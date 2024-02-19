using Bigss.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bigss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDepController : ControllerBase
    {
        private readonly BigshipContext context;

        public EmpDepController(BigshipContext context )
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            var data = (from a in context.Employees
                        join b in context.Departmants on a.Id equals b.Id
                        select new
                        {
                            a.FirstName,
                            a.LastName,
                            a.Email,
                            b.NameName,
                            b.Location
                        }).ToList();
            return Ok(data);
        }
        [HttpPut("UpdateLocation")]
        public ActionResult UpdateDepartmentLocation(UpdateLocation location)
        {
            var data = context.Departmants.Find(location.Id);
            if (data == null)
            {
                return BadRequest();
            }
            data.Location = location.Location;
            context.SaveChanges();

            return Ok(location);
        }
    }
}
