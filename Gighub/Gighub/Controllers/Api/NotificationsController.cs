using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers.Api
{

    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(i => i.UserId == userId && !i.IsRead)
                .Select(i => i.Notification)
                .Include(i => i.Gig.Artist)
                .ToList();

            return notifications.Select(i => new NotificationDto()
            {
                DateTime = i.DateTime,
                Gig = new GigDto
                {
                    Artist = new UserDto
                    {
                        Id = i.Gig.Artist.Id,
                        Name = i.Gig.Artist.Name,
                    },
                    DateTime = i.Gig.DateTime,
                    Id = i.Gig.Id,
                    IsCanceled = i.Gig.IsCanceled,
                    Venue = i.Gig.Venue
                },
                OriginalDateTime = i.OriginalDateTime,
                OriginalVenue = i.OriginalVenue,
                Type = i.Type
            });
        }
    }
}
