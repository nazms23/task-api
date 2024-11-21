using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace task_api.DTO
{
    //! Create için DTO
    public class TaskDTO
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}