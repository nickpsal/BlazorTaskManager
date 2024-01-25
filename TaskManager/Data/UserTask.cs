namespace TaskManager.Data
{
    public class UserTask
    {
        public string TaskName { get; set; }
        public string TaskDesc { get; set; }
        public string taskSetupDate { get; set; }
        public string taskScheduleDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public UserTask(string taskName, string TaskDesc, string taskSetupDate, string taskScheduleDate, string startTime, string endTime)
        {
            this.TaskName = taskName;
            this.TaskDesc = TaskDesc;
            this.taskSetupDate = taskSetupDate;
            this.taskScheduleDate = taskScheduleDate;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }
    }
}
