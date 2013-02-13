using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoSite.Models
{
    public class ToDoModelInitializer : DropCreateDatabaseAlways<ToDoContext>
    {
        protected override void Seed(ToDoContext context)
        {
            ToDoTask task1 = new ToDoTask()
            {
                Description = "Első feladat",
                Date = DateTime.Now,
                IsCompleted = false,
                UserName = "testuster"
            };

            ToDoTask task2 = new ToDoTask()
            {
                Description = "Második feladat",
                Date = DateTime.Now,
                IsCompleted = false,
                UserName = "testuster"
            };

            ToDoTask task3 = new ToDoTask()
            {
                Description = "Harmadik feladat",
                Date = DateTime.Now,
                IsCompleted = false,
                UserName = "testuster"
            };

            context.Tasks.Add(task1);
            context.Tasks.Add(task2);
            context.Tasks.Add(task3);

            context.SaveChanges();
        }
    }
}