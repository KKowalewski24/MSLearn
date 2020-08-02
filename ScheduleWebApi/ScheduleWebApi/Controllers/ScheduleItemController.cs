using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleWebApi.Data;
using ScheduleWebApi.Models;
using static ScheduleWebApi.Constants.Constants;

namespace ScheduleWebApi.Controllers {

    [Route(PATH_API_CONTROLLER)]
    [ApiController]
    public class ScheduleItemController : ControllerBase {

        /*----------------------- PROPERTIES REGION ----------------------*/
        private readonly AppDbContext _appDbContext;

        /*------------------------ METHODS REGION ------------------------*/
        public ScheduleItemController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        private bool IsItemExists(long id) {
            return _appDbContext.ScheduleItems.Any((it) => it.Id == id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleItem>>> GetItemList() {
            return await _appDbContext.ScheduleItems.ToListAsync();
        }

        [HttpGet(ID)]
        public async Task<ActionResult<ScheduleItem>> GetItem(long id) {
            var item = await _appDbContext.ScheduleItems.FindAsync(id);

            if (item == null) {
                return NotFound();
            }

            return item;
        }

        [HttpPut(ID)]
        public async Task<IActionResult> PutItem(long id, ScheduleItem scheduleItem) {
            if (id != scheduleItem.Id) {
                return BadRequest();
            }

            _appDbContext.Entry(scheduleItem).State = EntityState.Modified;

            try {
                await _appDbContext.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!IsItemExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ScheduleItem>> PostItem(ScheduleItem scheduleItem) {
            _appDbContext.ScheduleItems.Add(scheduleItem);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItem), new {id = scheduleItem.Id}, scheduleItem);
        }

        [HttpDelete(ID)]
        public async Task<ActionResult<ScheduleItem>> DeleteItem(long id) {
            var item = await _appDbContext.ScheduleItems.FindAsync(id);

            if (item == null) {
                return NotFound();
            }

            _appDbContext.ScheduleItems.Remove(item);
            await _appDbContext.SaveChangesAsync();

            return item;
        }

    }

}
