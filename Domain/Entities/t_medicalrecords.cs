using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class t_medicalrecords
    {
        public int medicalRecordsId { get; set; }
        public byte[] analysis { get; set; }
        public byte[] patientFile { get; set; }

        public string fileAnalysis { get; set; }
        public string filePatient { get; set; }
        public Nullable<int> patient_userId { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
