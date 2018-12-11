using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymCore.Models
{
    public class UserBiometricsModel
    {
        public UserBiometricsModel()
        {
        }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public int Id { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}