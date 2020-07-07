using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    public class Audit
    {
        public string CreatedById { get; set; }
        
        [ForeignKey("CreatedById")] 
        public User CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string UpdatedById { get; set; }
        
        [ForeignKey("UpdatedById")] 
        public User UpdatedBy { get; set; }
    
        public DateTime Updated { get; set; }

        public bool IsDeleted { get; set; }
    }
}