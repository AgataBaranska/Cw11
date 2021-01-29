using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cw11.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DueDate { get; set; }

        [ForeignKey("IdDoctor")]
        public int? IdDoctor { get; set; }

        [ForeignKey("IdPatient")]
        public int? IdPatient { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }

        public ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }
    }
}