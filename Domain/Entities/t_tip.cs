using System;
using System.Collections.Generic;
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

        public int idTip { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int liked { get; set; }
        public int disliked { get; set; }
        public int idPatientVoted { get; set; }
        public Nullable<int> administrator_userId { get; set; }
        public virtual t_user t_user { get; set; }
        public virtual ICollection<t_favorite> favorites { get; set; }

    }
}
