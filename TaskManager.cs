// Services/TaskManager.cs
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public class TaskManager
    {
        private List<Task> _tasks = new List<Task>(); // Lista para almacenar las tareas.
        private int _nextId = 1; // Contador para generar IDs únicos.

        // Método para agregar una tarea.
        public void AddTask(string description, DateTime? dueDate = null)
        {
            var task = new Task(_nextId++, description, dueDate);
            _tasks.Add(task);
        }

        // Método para obtener todas las tareas.
        public List<Task> GetTasks()
        {
            return _tasks;
        }

        // Método para marcar una tarea como completada.
        public bool MarkTaskAsCompleted(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                return true;
            }
            return false;
        }

        // Método para eliminar una tarea.
        public bool DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
                return true;
            }
            return false;
        }
    }
}

