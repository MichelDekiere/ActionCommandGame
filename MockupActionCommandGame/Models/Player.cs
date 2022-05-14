﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ActionCommandGame.Services.Model.Results;

namespace ActionCommandGame.Ui.WebApp.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public IList<PlayerResult> Players { set; get; }

    }
}
