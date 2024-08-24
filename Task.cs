// Models/Task.cs
using System;

namespace ToDoListApp.Models
{
    public class Task
    {
        public int Id { get; set; } // Identificador único para la tarea.
        public string Description { get; set; } // Descripción de la tarea.
        public DateTime? DueDate { get; set; } // Fecha límite de la tarea (opcional).
        public bool IsCompleted { get; set; } // Estado de la tarea (completada o no).

        // Constructor para inicializar una nueva tarea.
        public Task(int id, string description, DateTime? dueDate = null)
        {
            Id = id;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }
    }
}