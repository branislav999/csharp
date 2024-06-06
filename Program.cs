using System;
using System.Collections.Generic;
using System.IO;

class Program{
    


        public class Task{

            public string taskName;
            public DateTime date;

            public void setTaskName (string _taskName) { 

                taskName = _taskName;

            }

            public string getTaskName(){
                return taskName;
            }

            public void setTaskDate(DateTime _date)
            {
                date = _date;
            }

            public DateTime getTaskDate()
            {
                return date;
            }

        
        }
    static void Main(string[] args) {

        List<Task> tasks = new List<Task>();
        Program program = new Program();

           
        bool continueMenu = true;
        
        while (continueMenu){
            
            
            
            Console.WriteLine("This is the menu: \n1.Add the task \n2.Print out the tasks \n3.See the upcoming tasks \n4.Save tasks to a file \n5.Display tasks from a file \n0.Quit the program");
            

            Console.WriteLine("What is your choice(1-5): ");
            string input = Console.ReadLine();
            int choice = int.Parse(input);
            
            switch (choice){
                case 1:
                    program.InputTask(tasks);
                    break;
                
                case 2:
                    foreach (Task task in tasks){
                        Console.WriteLine($"Task: {task.getTaskName()} is due {task.getTaskDate().ToShortDateString()}");
                    }
                    break;
                    
                    
                case 3:
                    program.UpcomingTasks(tasks);
                    break;
                
                case 4:
                    program.WriteFile(tasks);
                    break;
                
                case 5:
                    program.ReadFile();
                    break;
                    
                case 0:
                    continueMenu = false;
                    break;
            }
        }
    }
    
        public void InputTask(List<Task> tasks){
            
            bool addMoreTasks = true;
            
            while (addMoreTasks){
            
                Console.Write("Enter Task Name: ");
                string taskName = Console.ReadLine();
                
                Console.Write("Enter the Date: (YYYY-MM-DD): ");
                
                if (DateTime.TryParse(Console.ReadLine(), out DateTime taskDate))
                {
                    Task newTask = new Task();
                    newTask.setTaskName(taskName);
                    newTask.setTaskDate(taskDate);
                    tasks.Add(newTask);
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter date in YYYY-MM-DD format.");
                }
                
                Console.Write("Do you want to add another task? (yes/no): ");
                string userInput = Console.ReadLine().ToLower();
                addMoreTasks = userInput == "yes" || userInput == "y";
                
            }
            
        }
    
    
    
    
        public void UpcomingTasks(List<Task> tasks){
            
            bool noUpcoming = true;
            
            foreach(Task task in tasks ){
                if (task.getTaskDate() > DateTime.Today){
                    TimeSpan difference = task.getTaskDate() - DateTime.Today;
                    Console.WriteLine($"Your task is: {task.getTaskName()}. It is due in {difference.Days} days");
                    noUpcoming = false;
                    }
                }
                if (noUpcoming){
                    Console.WriteLine("No upcoming tasks. ");
                }
            
            
        }
        
        
        public void WriteFile(List<Task> tasks){
            using (StreamWriter writer = new StreamWriter("data.txt", true)){
                foreach (Task task in tasks){
                writer.WriteLine($"{task.getTaskName()}~{task.getTaskDate()}");
                }
            }
        }


        public void ReadFile(){
            using(StreamReader reader = new StreamReader("data.txt")){
            
                string line;

                while ((line = reader.ReadLine()) != null){
                    string[] parts = line.Split("~");
                
                    Console.WriteLine($"{parts[0]} - {parts[1]}");
                    }
        
                
            }
        }
    }
