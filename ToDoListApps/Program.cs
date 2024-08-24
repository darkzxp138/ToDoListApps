using System;
using System.Collections.Generic;

class Task
{
    public string Description { get; set; }
    public DateTime? DueDate { get; set; }
    public bool IsCompleted { get; set; }

    public Task(string description, DateTime? dueDate = null)
    {
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    // Método para mostrar la tarea de manera formateada.
    public override string ToString()
    {
        return $"{Description}" + (DueDate.HasValue ? $" (Fecha límite: {DueDate.Value.ToShortDateString()})" : "") + (IsCompleted ? " [Completada]" : "");
    }
}

class Program
{
    // Una lista para almacenar las tareas.
    static List<Task> tasks = new List<Task>();

    static void Main(string[] args)
    {
        bool exit = false;

        // Bucle principal que continúa hasta que el usuario elija salir.
        while (!exit)
        {

            Console.WriteLine("\nGestor de Tareas:");
            Console.WriteLine("1. Agregar Tarea");
            Console.WriteLine("2. Listar Tareas");
            Console.WriteLine("3. Marcar Tarea como Completada");
            Console.WriteLine("4. Eliminar Tarea");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");

            // Lee la opción elegida por el usuario.
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddTask(); // Llama al método para agregar una tarea.
                    break;
                case "2":
                    ListTasks(); // Llama al método para listar las tareas.
                    break;
                case "3":
                    MarkTaskAsCompleted(); // Llama al método para marcar una tarea como completada.
                    break;
                case "4":
                    RemoveTask(); // Llama al método para eliminar una tarea.
                    break;
                case "5":
                    exit = true; // Cambia el valor de exit a true para salir del bucle.
                    break;
                default:
                    // Si la opción no es válida, muestra un mensaje de error.
                    Console.WriteLine("Opción inválida. Por favor, intenta nuevamente.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Introduce la descripción de la tarea: "); // Solicita al usuario que ingrese la descripción de la tarea.
        string description = Console.ReadLine(); // Lee la descripción de la tarea del usuario.

        DateTime? dueDate = null; // Inicializa la fecha límite como null.

        // Pregunta si el usuario desea agregar una fecha límite.
        Console.Write("¿Deseas agregar una fecha límite? (s/n): ");
        if (Console.ReadLine().ToLower() == "s")
        {
            Console.Write("Introduce la fecha límite (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime parsedDate))
            {
                dueDate = parsedDate; // Establece la fecha límite si el formato es válido.
            }
            else
            {
                Console.WriteLine("Formato de fecha inválido. La fecha límite no será establecida.");
            }
        }

        // Crea una nueva tarea y la agrega a la lista.
        Task newTask = new Task(description, dueDate);
        tasks.Add(newTask);
        Console.WriteLine("¡Tarea agregada exitosamente!"); // Informa al usuario que la tarea fue agregada.
    }

    // Método para listar todas las tareas.
    static void ListTasks()
    {
        Console.WriteLine("\nTareas:");

        // Verifica si hay tareas en la lista.
        if (tasks.Count == 0)
        {
            Console.WriteLine("No hay tareas disponibles."); // Informa al usuario si no hay tareas.
        }
        else
        {
            // Recorre todas las tareas y las muestra.
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}"); // Muestra cada tarea con su número correspondiente.
            }
        }
    }

    // Método para marcar una tarea como completada.
    static void MarkTaskAsCompleted()
    {
        ListTasks(); // Muestra la lista de tareas para que el usuario pueda elegir cuál marcar como completada.
        Console.Write("Introduce el número de la tarea para marcar como completada: "); // Solicita el número de la tarea a marcar.

        // Intenta convertir la entrada del usuario en un número y verifica si es válido.
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsCompleted = true; // Marca la tarea seleccionada como completada.
            Console.WriteLine("¡Tarea marcada como completada!"); // Informa al usuario que la tarea fue marcada.
        }
        else
        {
            Console.WriteLine("Número de tarea inválido. Por favor, intenta nuevamente."); // Muestra un mensaje si el número es inválido.
        }
    }

    // Método para eliminar una tarea de la lista.
    static void RemoveTask()
    {
        ListTasks(); // Muestra la lista de tareas para que el usuario pueda elegir cuál eliminar.
        Console.Write("Introduce el número de la tarea para eliminar: "); // Solicita el número de la tarea a eliminar.

        // Intenta convertir la entrada del usuario en un número y verifica si es válido.
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1); // Elimina la tarea seleccionada (resta 1 porque la lista empieza en 0).
            Console.WriteLine("¡Tarea eliminada exitosamente!"); // Informa al usuario que la tarea fue eliminada.
        }
        else
        {
            Console.WriteLine("Número de tarea inválido. Por favor, intenta nuevamente."); // Muestra un mensaje si el número es inválido.
        }
    }
}
