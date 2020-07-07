using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberBooking.Entities
{
    public class Audit
    {
        [Required]
        [ForeignKey("CreatedBy")] 
        public string CreatedById { get; set; }
        
        public User CreatedBy { get; set; }

        public DateTime Created { get; set; }

        [Required]
        [ForeignKey("UpdatedBy")] 
        public string UpdatedById { get; set; }
        
        public User UpdatedBy { get; set; }
    
        public DateTime Updated { get; set; }

        public bool IsDeleted { get; set; }
    }
}