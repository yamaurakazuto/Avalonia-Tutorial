using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia_todo_tutorial.Models
{
    public class ToDoItem
{
        /// <summary>
        /// Gets or sets the checked status of each item
        /// </summary>
        public bool IsChecked { set; get; }

        /// <summary>
        /// Gets or sets the content of the to-do item
        /// </summary>
       public string? Content { get; set; }

}
}
