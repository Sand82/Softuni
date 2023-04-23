using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

/// <summary>
/// The ThreadExecutor is the concrete implementation of the IScheduler.
/// You can send any class to the judge system as long as it implements
/// the IScheduler interface. The Tests do not contain any <e>Reflection</e>!
/// </summary>
public class ThreadExecutor : IScheduler
{
    private Dictionary<int, Task> taskDictionary = new Dictionary<int, Task>();
    private List<Task> tasksList = new List<Task>();
      
    public ThreadExecutor()
    {

    }   

    int IScheduler.Count => taskDictionary.Count;

    public void ChangePriority(int id, Priority newPriority)
    {
        if (!taskDictionary.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        else
        {
            taskDictionary[id].TaskPriority = newPriority;

            var task = tasksList.Find(x => x.Id == id);
            task.TaskPriority = newPriority;
        }       
    }

    public bool Contains(Task task)
    {
        return taskDictionary.ContainsKey(task.Id);
    }

    public int Cycle(int cycles)
    {

        if (tasksList.Count == 0)
        {
            throw new InvalidOperationException();
        }

        int removedCycleCount = 0;

        for (int i = 0; i < tasksList.Count; i++)
        {
            var task = tasksList[i];
            task.Consumption -= cycles;

            if (task.Consumption <= 0)
            {
                tasksList.Remove(task);
                taskDictionary.Remove(task.Id);
                i--;
                removedCycleCount++;
            }
        }

        return removedCycleCount;

    }

    public void Execute(Task task)
    {
        if (!taskDictionary.ContainsKey(task.Id))
        {
            taskDictionary.Add(task.Id, task);
            tasksList.Add(task);
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public IEnumerable<Task> GetByConsumptionRange(int low, int high, bool inclusive)
    {
        var result = new List<Task>();

        if (tasksList.Count == 0)
        {
            return result;
        }

        for (int i = 0; i < tasksList.Count; i++)
        {
            var task = tasksList[i];

            if (inclusive)
            {
                if (task.Consumption >= low && task.Consumption <= high)
                {
                    result.Add(task);
                }
            }
            else 
            {
                if (task.Consumption > low && task.Consumption < high)
                {
                    result.Add(task);
                }
            }            
        }

        result = result.OrderBy(x => x.Consumption).ThenByDescending(x => x.TaskPriority).ToList();

        return result;
    }

    public Task GetById(int id)
    {
        if (taskDictionary.ContainsKey(id))
        {
            return taskDictionary[id];
        }
        else
        {
            throw new ArgumentException();
        }
    }

    public Task GetByIndex(int index)
    {
        if (index < 0 || index > tasksList.Count)
        {
            throw new ArgumentOutOfRangeException();
        }

        return tasksList[index];
    }

    public IEnumerable<Task> GetByPriority(Priority type)
    {
        var result = new List<Task>();

        if (tasksList.Count == 0)
        {
            return result;
        }

        for (int i = 0; i < tasksList.Count; i++)
        {
            var task = tasksList[i];

            if (task.TaskPriority == type)
            {
                result.Add(task);
            }
        }

        result = result.OrderByDescending(x => x.Id).ToList();

        return result;
    }

    public IEnumerable<Task> GetByPriorityAndMinimumConsumption(Priority priority, int low)
    {
        var result = new List<Task>();

        for (int i = 0; i < tasksList.Count; i++)
        {
            var task = tasksList[i];

            if (task.TaskPriority == priority && task.Consumption >= low)
            {
                result.Add(task);
            }
        }

        result = result.OrderByDescending(x => x.Id).ToList();

        return result;
    }


    public IEnumerator<Task> GetEnumerator()
    {
        return tasksList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
