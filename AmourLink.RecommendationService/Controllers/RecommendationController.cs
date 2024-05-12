using AmourLink.RecommendationService.Data.Context;
using AmourLink.RecommendationService.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmourLink.RecommendationService.Controllers
{
    public class RecommendationController : BaseApiController
    {
        private readonly ApplicationDbContext _context;

        public RecommendationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Test()
        {
            var users = _context.Users.OrderBy(u => u.Rating).Include(u => u.UserDetails).ToList();

            return users;
        }
    }
}
