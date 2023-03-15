using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly DataContext _context;
        public ActivitiesController(DataContext context)
        {
            _context = context;
            
        }

        [HttpGet]//for localhost:5000/api/activities
        public async Task<ActionResult<List<Activity>>> GetActivities(){
            return await _context.Activities.ToListAsync();
        }

        [HttpGet("{id}")]//for localhost:5000/api/activities/uidos-ds3243-fdsfv-23fw
        public async Task<ActionResult<Activity>> GetActivity(Guid id){

            return await _context.Activities.FindAsync(id);
        }



    }
}