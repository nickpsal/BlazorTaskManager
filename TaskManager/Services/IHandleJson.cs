using System.Collections.ObjectModel;
using TaskManager.Data;

namespace TaskManager.Services
{
    public interface IHandleJson
    {
        List<UserTask> readJsonData();
        Task exporttoJson(List<UserTask> tasks);
        Task savetoJson(UserTask newTask);
        Task deleteTask(UserTask taskdorDeleted);
        Task UpdateTask(UserTask oldTask, UserTask updateTask);
    }
}
