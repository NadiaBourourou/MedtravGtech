﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public partial class t_tip
    {
        public t_tip()
        {
            this.favorites = new List<t_favorite>();
        }


        [Display(Name = "Tip Id")]
        public int tipId { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "The title is required")]
        public string title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Body")]
        [Required(ErrorMessage = "The body is required")]
        public string body { get; set; }

        [Display(Name = "Number of like")]
        public int liked { get; set; }

        [Display(Name = "Number of dislike")]
        public int disliked { get; set; }
        public Nullable<int> idPatientVoted { get; set; }

        [Display(Name = "Administrator Id")]
        public Nullable<int> administrator_userId { get; set; }
        public virtual t_user t_user { get; set; }
        public virtual ICollection<t_favorite> favorites { get; set; }

    }
}
