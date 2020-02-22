using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tasks
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TaskDate { get; set; }
        public bool IsPlanned { get; set; }
        public bool IsPaused { get; set; }
        public string TotalTimeTaken { get; set; }

    }
}
