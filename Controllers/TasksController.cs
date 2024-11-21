using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_api.DTO;
using task_api.Models;

namespace task_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _taskContext;

        public TasksController(TaskContext taskContext) 
        {
            _taskContext = taskContext;
        }
    
        
        //! Create ---------
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDTO taskDto)
        {
            try
            {
                Tasks tasks = new Tasks();
                tasks.Title = taskDto.Title;
                tasks.Description = taskDto.Description;
                tasks.CreatedAt = DateTime.Now;
                _taskContext.Add(tasks);
                await _taskContext.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTaskById),new {id = tasks.Id},tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        //------------------------------------------------------------

        //! GetAll ---------
        [HttpGet]
        public async Task<IActionResult> GetTask()
        {
            try
            {
                var r = await _taskContext.Tasks.ToListAsync();
                return Ok(r);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------

        //! GetById ---------
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var r = await _taskContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (r == null)
                {
                    return NotFound();
                }
                return Ok(r);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------

        //! Edit ---------
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditTask(int? id, TaskDTO2 taskDto)
        {
            if(id == null)
            {
                return NotFound();
            }
            try
            {
                if(id != taskDto.Id)
                {
                    return BadRequest();
                }

                var r = await _taskContext.Tasks.FirstOrDefaultAsync(x=>x.Id == id);

                if(r == null)
                {
                    return NotFound();
                }

                r.Title = taskDto.Title;
                r.Description = taskDto.Description;

                await _taskContext.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //------------------------------------------------------------

        //! Delete ---------
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                var r = await _taskContext.Tasks.FirstOrDefaultAsync(x=>x.Id == id);
                if(r == null)
                {
                    return NotFound();
                }
                _taskContext.Remove(r);

                await _taskContext.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //------------------------------------------------------------

    }
}