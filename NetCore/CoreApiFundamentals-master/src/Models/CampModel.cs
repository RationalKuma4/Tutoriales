﻿using CoreCodeCamp.Data.Entities;
using System;
using System.Collections.Generic;

namespace CoreCodeCamp.Models
{
    public class CampModel
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Moniker { get; set; }
        //public Location Location { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        public int Lenght { get; set; } = 1;
        //public ICollection<Talk> Talks { get; set; }

        public string Venue { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationCityTown { get; set; }
        public string LocationStateProvince { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationCountry { get; set; }

        public ICollection<TalkModel> Talks { get; set; }
    }
}
