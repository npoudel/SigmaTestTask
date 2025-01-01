using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Candidate
    {
        [Required, Key]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public string? BestCallTime { get; set; }

        public string? LinkedInProfile { get; set; }

        public string? GitHubProfile { get; set; }

        [Required]
        public string Comment { get; set; } = string.Empty;
    }
}
