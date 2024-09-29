List<string> TaskList = new List<string>();

    
int menuSelected = 0;
do
{
    menuSelected = ShowMainMenu();
    if ((Menu)menuSelected == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)menuSelected == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)menuSelected == Menu.List)
    {
        ShowMenuTaskList();
    }
} while ((Menu)menuSelected != Menu.Exit);
    
/// <summary>
/// Show options for tasks, 1. Nueva tarea, 2. Remover tarea, 3. Tareas pendientes, 4. Salir
/// </summary>
/// <returns>Returns option indicated by user</returns>
int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    string option = Console.ReadLine();
    return Convert.ToInt32(option);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowMenuTaskList();

        string taskIndex = Console.ReadLine();

        //Remove one position becouse the array starts in 0
        int indexToRemove = Convert.ToInt32(taskIndex) - 1;

        if(indexToRemove > (TaskList.Count -1) || indexToRemove < 0)
        {
            Console.WriteLine("El número de tarea seleccionado es invalido");
        }
        else
        {
            if (indexToRemove > -1 && TaskList.Count > 0)
            {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine($"Tarea {task} eliminada.");
                    
            }
        }

    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea."); 
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string task = Console.ReadLine();
        if (task.Equals(""))
        {
            Console.WriteLine("Por favor ingrese una tarea válida");
        }
        else
        {
            TaskList.Add(task);
            Console.WriteLine("Tarea registrada");
        }
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        Console.WriteLine("----------------------------------------");
        int index = 1;
        TaskList.ForEach(p => Console.WriteLine($"{index++}. {p}"));
        Console.WriteLine("----------------------------------------");
    } 
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
