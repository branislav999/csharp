using System;
using System.Collections.Generic;
using System.IO;

class Program{
    


        private class Task{

            private string taskName;
            private DateTime date;

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
        
        
        
        using (StreamWriter writer = new StreamWriter("data.txt")){
            foreach (Task task in tasks){
            Console.WriteLine($"{task.getTaskName()}~{task.getTaskDate()}");
        }
        
        }
        
        

    }

}
