using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gighub.Models
{
    public class Follow
    {
        public Gig Artist { get; set; }

        public ApplicationUser Follower { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ArtistId { get; set; }


        [Key]
        [Column(Order = 2)]
        public string FollowerId { get; set; }




    }
}