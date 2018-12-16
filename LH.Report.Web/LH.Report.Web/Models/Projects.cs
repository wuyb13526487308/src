using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class ProjectsProvider {
        public static DateTime DefaultCompletedDate { get { return new DateTime(2006, 09, 25); } }

        public static List<Task> GetProjectsTasks() {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task("Project 1 : Original Plan", "Project 1", new DateTime(2005, 03, 27), new DateTime(2005, 05, 30)));
            tasks.Add(new Task("Project 1 : Original Plan", "task 1", new DateTime(2005, 03, 27), new DateTime(2005, 04, 29)));
            tasks.Add(new Task("Project 1 : Original Plan", "task 2", new DateTime(2005, 04, 19), new DateTime(2005, 05, 30)));
            tasks.Add(new Task("Project 1 : Original Plan", "task 3", new DateTime(2005, 04, 18), new DateTime(2005, 05, 07)));
            tasks.Add(new Task("Project 1 : Original Plan", "task 4", new DateTime(2005, 04, 17), new DateTime(2005, 05, 06)));
            tasks.Add(new Task("Project 1 : Original Plan", "task 5", new DateTime(2005, 04, 23), new DateTime(2005, 05, 12)));
            tasks.Add(new Task("Project 1 : Current Plan", "Project 1", new DateTime(2005, 04, 22), new DateTime(2005, 06, 17)));
            tasks.Add(new Task("Project 1 : Current Plan", "task 1", new DateTime(2005, 04, 22), new DateTime(2005, 05, 17)));
            tasks.Add(new Task("Project 1 : Current Plan", "task 2", new DateTime(2005, 05, 01), new DateTime(2005, 06, 10)));
            tasks.Add(new Task("Project 1 : Current Plan", "task 3", new DateTime(2005, 05, 08), new DateTime(2005, 05, 28)));
            tasks.Add(new Task("Project 1 : Current Plan", "task 4", new DateTime(2005, 05, 09), new DateTime(2005, 05, 30)));
            tasks.Add(new Task("Project 1 : Current Plan", "task 5", new DateTime(2005, 05, 28), new DateTime(2005, 06, 17)));
            tasks.Add(new Task("Project 2 : Original Plan", "Project 2", new DateTime(2005, 03, 14), new DateTime(2005, 05, 15)));
            tasks.Add(new Task("Project 2 : Original Plan", "task 1", new DateTime(2005, 03, 14), new DateTime(2005, 04, 23)));
            tasks.Add(new Task("Project 2 : Original Plan", "task 2", new DateTime(2005, 03, 21), new DateTime(2005, 04, 09)));
            tasks.Add(new Task("Project 2 : Original Plan", "task 3", new DateTime(2005, 03, 28), new DateTime(2005, 04, 16)));
            tasks.Add(new Task("Project 2 : Original Plan", "task 4", new DateTime(2005, 04, 04), new DateTime(2005, 04, 23)));
            tasks.Add(new Task("Project 2 : Original Plan", "task 5", new DateTime(2005, 04, 26), new DateTime(2005, 05, 15)));
            tasks.Add(new Task("Project 2 : Current Plan", "Project 2", new DateTime(2005, 04, 11), new DateTime(2005, 06, 09)));
            tasks.Add(new Task("Project 2 : Current Plan", "task 1", new DateTime(2005, 04, 11), new DateTime(2005, 05, 06)));
            tasks.Add(new Task("Project 2 : Current Plan", "task 2", new DateTime(2005, 04, 17), new DateTime(2005, 05, 06)));
            tasks.Add(new Task("Project 2 : Current Plan", "task 3", new DateTime(2005, 04, 29), new DateTime(2005, 05, 17)));
            tasks.Add(new Task("Project 2 : Current Plan", "task 4", new DateTime(2005, 05, 09), new DateTime(2005, 05, 25)));
            tasks.Add(new Task("Project 2 : Current Plan", "task 5", new DateTime(2005, 05, 25), new DateTime(2005, 06, 09)));
            return tasks;
        }
        public static List<Task> GetProjectTasks(DateTime completedDate) {
            List<Task> tasks = new List<Task>();
            tasks.Add(new Task("Planned", "Market Analysis", new DateTime(2006, 08, 16), new DateTime(2006, 08, 23)));
            tasks.Add(new Task("Planned", "Feature Planning", new DateTime(2006, 08, 23), new DateTime(2006, 08, 25), new int[] { 0 }));
            tasks.Add(new Task("Planned", "Feature 1: Implementation", new DateTime(2006, 08, 25), new DateTime(2006, 10, 18), new int[] { 1 }));
            tasks.Add(new Task("Planned", "Feature 1: Demos&Docs", new DateTime(2006, 10, 18), new DateTime(2006, 10, 26), new int[] { 2 }));
            tasks.Add(new Task("Planned", "Feature 2: Implementation", new DateTime(2006, 09, 07), new DateTime(2006, 10, 18), new int[] { 1 }));
            tasks.Add(new Task("Planned", "Feature 2: Demos&Docs", new DateTime(2006, 10, 18), new DateTime(2006, 10, 26), new int[] { 4 }));
            tasks.Add(new Task("Planned", "Feature 3: Implementation", new DateTime(2006, 09, 21), new DateTime(2006, 10, 18), new int[] { 1 }));
            tasks.Add(new Task("Planned", "Feature 3: Demos&Docs", new DateTime(2006, 10, 18), new DateTime(2006, 10, 26), new int[] { 6 }));
            tasks.Add(new Task("Planned", "Testing & Bug Fixing", new DateTime(2006, 10, 26), new DateTime(2006, 11, 10), new int[] { 3, 5, 7 }));
            foreach (Task task in tasks.GetRange(0, tasks.Count))
                if (task.BeginDate < completedDate) {
                    DateTime endDate = task.EndDate < completedDate ? task.EndDate : completedDate;
                    tasks.Add(new Task("Completed", task.TaskName, task.BeginDate, endDate));
                }
            return tasks;
        }
    }

    public class Task {
        string projectName;
        string taskName;
        DateTime beginDate;
        DateTime endDate;
        IList<int> relations;

        public string ProjectName { get { return projectName; } }
        public string TaskName { get { return taskName; } }
        public DateTime BeginDate { get { return beginDate; } set { beginDate = value; } }
        public DateTime EndDate { get { return endDate; } set { endDate = value; } }
        public IList<int> Relations { get { return relations; } }

        public Task(string projectName, string taskName, DateTime beginDate, DateTime endDate, IList<int> relations) {
            this.projectName = projectName;
            this.taskName = taskName;
            this.beginDate = beginDate;
            this.endDate = endDate;
            this.relations = relations;
        }
        public Task(string projectName, string taskName, DateTime beginDate, DateTime endDate) : this(projectName, taskName, beginDate, endDate, null) {
        }
    }
}
