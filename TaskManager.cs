using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskManager
    {
        List<Task> tasks = new List<Task>();
        
        //метод для добавления задач
        public void AddTask()
        {
            Console.WriteLine("Enter title task: ");
            string title = Console.ReadLine();
            Console.WriteLine("Enter description task: ");
            string desc = Console.ReadLine();
            DateTime date = DateTime.Now;

            Task newtask = new Task() { Description = desc, Title = title, Time = date };
            
            using(var db = new TaskManagerDbContext())
            {
                db.Tasks.Add(newtask);
                db.SaveChanges();
            }

            Console.WriteLine("Finish!");
        }

        //метод для получения списка задач
        public void GetListTask()
        {
            Console.WriteLine("Tasks List: ");
            Console.WriteLine("------------------------------");

            using (var db = new TaskManagerDbContext())
            {
                var tasks = db.Tasks.ToList();   

                foreach (Task taskList in tasks)
                {
                    Console.WriteLine($"{taskList.Id} | {taskList.Title} | {taskList.Description} |  {taskList.Time}");
                }
            }
        }
        
        //метод для удаления задач
        public void TaskDelete(int taskId)
        {
            using(var db = new TaskManagerDbContext())
            {
                var task = db.Tasks.FirstOrDefault(d => d.Id == taskId);
                
                if(task != null)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                    Console.WriteLine("Rename of task!");
                    GetListTask();
                }
                else
                {
                    Console.WriteLine("task with this id was not found");
                }

            }
        }

        //метод для редактирования
        public void EditTask(int taskId)
        {
            using(var db = new TaskManagerDbContext())
            {
                var task = db.Tasks.FirstOrDefault(d => d.Id == taskId); 
                
                if(task != null)
                {
                    Console.WriteLine($"Current title: {task.Title}");
                    Console.WriteLine($"Current desctiption: {task.Description}");
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter new title: ");
                    string newTitle = Console.ReadLine();
                    Console.WriteLine("Enter new descriotion: ");
                    string newDesc = Console.ReadLine();
                    if(newTitle != null)
                    {
                        task.Title = newTitle;
                    }
                    if(newDesc != null)
                    {
                        task.Description = newDesc;
                    }

                    Console.WriteLine("Edit task!");
                    db.SaveChanges();
                    GetListTask();
                }
               

                else
                {
                    Console.WriteLine("Task not found!");
                }
            };

         
        }
    }
}
