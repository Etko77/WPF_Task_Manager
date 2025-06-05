using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCompleye { get; set; }
        public TimeSpan Timer { get; set; }

        public TaskState TaskSate { get; set; }
        public TaskCategory TaskCategory { get; set; }
        public TaskImportance TaskImportance { get; set; }

    }
    public enum TaskState
    {
        InProgress,
        Complete,
        NotStarted,
        Late,
        Archived,
        Deleted
    }
    public enum TaskCategory
    {
        Personal, 
        Work,
        Home,
        Travel,
        HealthWellbeing,
        Finance,
        Shopping, 
        Social,
        Education,
        Errands,
        HobbiesLesiure,
        BirthdayAnniversaries,
        Projects,
        VolunteeringCommunity

    }
    public enum TaskImportance
    {
        Low,
        Medium,
        High,
        Critical
    }
}
