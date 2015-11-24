﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public partial class t_favorite
    {
        public t_favorite()
        {
            this.tips = new List<t_tip>();
        }

        public int idFavorite { get; set; }
        public string nameFavorite { get; set; }
        public Nullable<int> patient_userId { get; set; }
        public virtual t_user t_user { get; set; }
        public virtual ICollection<t_tip> tips { get; set; }

    }
}