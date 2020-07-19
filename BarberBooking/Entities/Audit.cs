using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    public class Audit
    {
        [ForeignKey("CreatedBy")] 
        public string CreatedById { get; set; }
        
        public User CreatedBy { get; set; }

        public DateTime Created { get; set; }

        [ForeignKey("UpdatedBy")] 
        public string UpdatedById { get; set; }
        
        public User UpdatedBy { get; set; }
    
        public DateTime Updated { get; set; }

        public bool IsDeleted { get; set; }
    }
}