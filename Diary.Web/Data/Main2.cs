using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.Web.Data
{
    public class Quote2
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
    }



    public class Rate
    {
        public int Id { get; set; }
        public virtual ICollection<Option2> Options { get; set; }
    }


    public class Option2
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }


    // from
    public class Quote1
    {
        public int QuoteId { get; set; }
        public string Type { get; set; }
        public string Destination { get; set; }
        public List<RateSet> RateSets { get; set; }
    }


    public class RateSet
    {
        public int Id { get; set; }
        public decimal ValueMin { get; set; }
        public decimal ValueMax { get; set; }
        public List<Option1> Options { get; set; }
    }


    public class Option1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
    
}
