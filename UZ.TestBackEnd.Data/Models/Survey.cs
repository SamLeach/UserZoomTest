using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UZ.TestBackEnd.Data.Models
{
    public class Survey
    {
        public string StudyTitle { get; set; }
        public string SurveyTitle { get; set; }
        public string Completes { get; set; }
        public string Needed { get; set; }
        public string ParticipantsNeeded { get; set; }
    }
}
