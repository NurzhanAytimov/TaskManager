using System;

namespace TaskManager
{
    class Program
    {
        public static void Main(string[] args) 
        {
            TaskManager taskManager = new TaskManager();
            
            Console.WriteLine("[1] Add task: ");
            Console.WriteLine("[2] Get list of task: ");
            Console.WriteLine("[3] Rename task:");
            Console.WriteLine("[4] Edit Task:");
            Console.WriteLine("[5] Exit");
            int result = int.Parse(Console.ReadLine());


            while(result != 5)
            {
                if(result == 1)
                {
                    taskManager.AddTask();
                }

                else if(result == 2)
                {
                    taskManager.GetListTask();
                   
                }

                else if(result == 3)
                {
                    Console.WriteLine("Enter id whicht delete: ");
                    int taskId = int.Parse(Console.ReadLine());
                    taskManager.TaskDelete(taskId);
                }
                else if(result == 4)
                {
                    Console.WriteLine("Enter id of task whicht edit: ");
                    int taskId = int.Parse(Console.ReadLine());
                    taskManager.EditTask(taskId);
                }

                else
                {
                    break;
                }

                /*Console.WriteLine("[1] Add task: ");
                Console.WriteLine("[2]Get list of task: ");
                Console.WriteLine("[3] Exit");
                result = int.Parse(Console.ReadLine());*/
            }
        }





    }
}
