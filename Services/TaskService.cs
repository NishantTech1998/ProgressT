using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services
{
    public class TaskService
    {
        public void AddTask(Tasks task)
        {
            using (var db = new TaskProgressContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        public List<string> GetPlannedTask()
        {
            string currentDate = DateTime.Now.Date.ToString().Split(' ')[0];
            using (var db = new TaskProgressContext())
            {
                return db.Tasks.Where(t => t.IsPlanned == true && t.TaskDate ==currentDate ).Select(s => s.TaskName).ToList();
            }
        }

        public List<Tasks> GetAllTasks()
        {
            using (var db = new TaskProgressContext())
            {
                return db.Tasks.ToList();
            }
        }

        
        public void StartTask(String taskName)
        {
            using (var db = new TaskProgressContext())
            {
                Tasks CurrentTask = db.Tasks.Where(t => t.TaskName == taskName).Single();
                if (CurrentTask.IsPaused)
                {
                    CurrentTask.IsPaused = false;
                    CurrentTask.EndTime = DateTime.Now.ToString("T");
                }
                else
                {
                    CurrentTask.StartTime = DateTime.Now.ToString("T");
                }
                db.SaveChanges();
            }
        }

        public void PauseTask(string taskName)
        {
            using (var db = new TaskProgressContext())
            {
                Tasks CurrentTask = db.Tasks.Where(t => t.TaskName == taskName).Single();
                CurrentTask.IsPaused = true;
                if (CurrentTask.EndTime == null)
                {
                    CurrentTask.EndTime = DateTime.Now.ToString("T");
                    CurrentTask.TotalTimeTaken = (double.Parse(CurrentTask.TotalTimeTaken) + DateTime.Parse(CurrentTask.EndTime).Subtract(DateTime.Parse(CurrentTask.StartTime)).TotalMinutes).ToString();
                }
                else
                {
                    string tempTime = CurrentTask.EndTime;
                    CurrentTask.EndTime = DateTime.Now.ToString("T");
                    CurrentTask.TotalTimeTaken= (double.Parse(CurrentTask.TotalTimeTaken)+DateTime.Parse(CurrentTask.EndTime).Subtract(DateTime.Parse(tempTime)).TotalMinutes).ToString();
                }
                db.SaveChanges();
            }
        }

        public void StopTask(string taskName)
        {
            using (var db = new TaskProgressContext())
            {
                Tasks CurrentTask = db.Tasks.Where(t => t.TaskName == taskName).Single();
                CurrentTask.IsPaused = false;
                if (CurrentTask.EndTime == null)
                {
                    CurrentTask.EndTime = DateTime.Now.ToString("T");
                    CurrentTask.TotalTimeTaken = (double.Parse(CurrentTask.TotalTimeTaken) + DateTime.Parse(CurrentTask.EndTime).Subtract(DateTime.Parse(CurrentTask.StartTime)).TotalMinutes).ToString();
                }
                else
                {
                    string tempTime = CurrentTask.EndTime;
                    CurrentTask.EndTime = DateTime.Now.ToString("T");
                    CurrentTask.TotalTimeTaken = (double.Parse(CurrentTask.TotalTimeTaken) + DateTime.Parse(CurrentTask.EndTime).Subtract(DateTime.Parse(tempTime)).TotalMinutes).ToString();
                }
                db.SaveChanges();
            }
        }
    }
}
