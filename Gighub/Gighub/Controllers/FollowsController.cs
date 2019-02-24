using Gighub.Models;
using Gighub.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Gighub.Controllers
{

    public class FollowsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public FollowsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Following()
        {
            var userId = User.Identity.GetUserId();
            var follows = _context.Followings
                .Where(a => a.FollowerId == userId)
                .Include(a => a.Followee)
                .ToList();

            var viewModel = new FollowingViewModel()
            {
                FollowedArtist = follows,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Followed Artists"
            };

            return View("Follows", viewModel);

        }
    }
}