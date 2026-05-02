using TaskManagement.Core.Interfaces;
using TaskMange.Core.Entiteis;
using TaskMange.Core.Interfaces;

public class TaskServices: ITaskService
{
    private readonly ITaskRepository _repo;

    public TaskServices(ITaskRepository repo)
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
        await _repo.AddAsync(task);
    }

    public async Task UpdateAsync(TaskItem task)
    {
        await _repo.UpdateAsync(task);
    }

    public async Task DeleteAsync(int id)
    {
        await _repo.DeleteAsync(id);
    }
}