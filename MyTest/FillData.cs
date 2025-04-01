using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace MyTest
{
    internal class FillData
    {
        public List<TaskItem> Fill(int[] ids, string[] descriptions, string[] dueDateStrings)
        {
            List<TaskItem> filled = new List<TaskItem>();
            for (int i = 0; i < ids.Length; i++)
            {
                int id = ids[i];
                string description = descriptions[i];
                DateTime dueDate = DateTime.Parse(dueDateStrings[i]);
                TaskItem task = new TaskItem(id, description, dueDate);
                filled.Add(task);
            }
            return filled;

        }
    }
}
