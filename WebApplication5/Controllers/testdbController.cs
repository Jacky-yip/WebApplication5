using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication5.Entities;
namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testdbController : ControllerBase
    {
        private readonly   testdbContext  testdb;

        public testdbController( testdbContext DBContext)
        {
            this.testdb = DBContext;
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<tb1>>> Get()
        {
            var List = await testdb.tb1.Select(
                s => new tb1
                {
                    id = s.id,
                    createDate = s.createDate,
                    machineId = s.machineId,
                    value = s.value,
                }
            ).ToListAsync();

            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }

        [HttpPost("InsertUser")]
        public async Task<HttpStatusCode> InsertUser(string v_machineId,decimal v_value)
        {
            var entity = new tb1()
            {
                machineId = v_machineId,
                value =  v_value,
                createDate = DateTime.Now,
            };
            testdb.tb1.Add(entity);
            await testdb.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        [HttpDelete("DeleteUser/{Id}")]
        public async Task<HttpStatusCode> DeleteUser(int Id)
        {
            var entity = new tb1()
            {
                id = Id
            };
            testdb.tb1.Attach(entity);
            testdb.tb1.Remove(entity);
            await testdb.SaveChangesAsync();
            return HttpStatusCode.OK;
        }

        [HttpPut("UpdateUser")]
        public async Task<HttpStatusCode> UpdateUser(int Id, decimal v)
        {
            var entity = await testdb.tb1.FirstOrDefaultAsync(s => s.id == Id);
            entity.value = v;
            await testdb.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }

}
