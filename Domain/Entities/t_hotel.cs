using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_hotel
    {
        public t_hotel()
        {
            this.t_servicehotel = new List<t_servicehotel>();
            this.t_hotelbooking = new List<t_hotelbooking>();
        }

        public int hotelId { get; set; }

        [Required(ErrorMessage = "The address of the hotel is required."), Display(Name = "Address")]
        public string address { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Required(ErrorMessage = "The hotel name is required."), Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Price Single")]
        [DataType(DataType.Currency)]
        public Nullable<double> priceSingle { get; set; }
        [Display(Name = "Price Suite")]
        [DataType(DataType.Currency)]
        public Nullable<double> priceSuite { get; set; }
        [Display(Name = "Stars")]
        public Nullable<int> stars { get; set; }
        public Nullable<int> state { get; set; }
        [Display(Name = "Picture")]
        public string ImgName { get; set; }
        public virtual ICollection<t_servicehotel> t_servicehotel { get; set; }
        public virtual ICollection<t_hotelbooking> t_hotelbooking { get; set; }
    }
}
