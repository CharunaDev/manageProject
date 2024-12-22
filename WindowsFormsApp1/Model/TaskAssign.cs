using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class TaskAssign
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string FirstName { get; set; }
        public DateTime? AssignDate { get; set; }
    }
}
