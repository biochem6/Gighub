using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Gighub.Controllers
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowDto dto)
        {
            var userId = User.Identity.GetUserId();

            var follow = new Follow
            {
                ArtistId = dto.ArtistId,
                FollowerId = userId
            };
            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }

    }
}
