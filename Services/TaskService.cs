using TaskManagement.Core.Interfaces;
using TaskMange.Core.Entiteis;
using TaskMange.Core.Interfaces;

namespace TAskMange.Services.Services
{
    public class TaskService: ITaskService
    {

        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(bool? isCompleted, bool sortByDueDate)
        {
            var tasks = await _repo.GetAllAsync();

            if (isCompleted.HasValue)
                tasks = tasks.Where(t => t.IsCompleted == isCompleted.Value);

            if (sortByDueDate)
                tasks = tasks.OrderBy(t => t.DueDate);

            return tasks;
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task AddAsync(TaskItem task)
        {
            if (task.DueDate.HasValue && task.DueDate <= DateTime.Now)
                throw new Exception("DueDate must be in the future");

            await _repo.AddAsync(task);
        }

        public async Task UpdateAsync(TaskItem task)
        {
            if (task.DueDate.HasValue && task.DueDate <= DateTime.Now)
                throw new Exception("DueDate must be in the future");

            await _repo.UpdateAsync(task);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);
        }




    }
}
