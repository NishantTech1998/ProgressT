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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime TaskDate { get; set; }
        public bool IsPlanned { get; set; }
        public bool IsPaused { get; set; }
        public DateTime TotalTimeTaken { get; set; }

    }
}
