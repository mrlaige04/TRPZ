using Lab6;

Console.CursorVisible = false;
while (true)
{
    var mainCommands = new List<string>()
    {
        "Task1",
        "Task2",
        "Task3",
        "Task4",
        "Exit"
    };

    int choosedTask = ArrowSelect(mainCommands)+1;
    Console.Clear();
    switch (choosedTask)
    {
        case 1:
            Task1();
            break;
        case 2:
            Task2();
            break;
        case 3:
            Task3();
            break;
        case 4:
            Task4();
            break;
        case 5:
            Console.WriteLine("Bye :)");
            Environment.Exit(0);           
            break;
        default:
            Console.WriteLine("Invalid number. Try again: ");
            break;
    }
  
    Console.Clear();
}

void Task1()
{
    var array = new int[5,5];
    var commands = new List<string>()
    {
        "FillRandom",
        "FillZeros",
        "FillOnes",
        "FillDiamond",
        "Exit"
    };

    var task1_action = ArrowSelect(commands) + 1;

    var demonstrateFill = (FillType startFill, FillType endFill) =>
    {
        var successFill = FillArray(array, startFill);
        if (!successFill) return -1;

        PrintMattrix(array);
        successFill = FillArray(array, endFill);
        if (!successFill) return -1;
        Console.WriteLine("=====================");
        PrintMattrix(array);
        Console.ReadKey();
        Console.Clear();

        return 0;
    };

    _ = task1_action switch
    {
        1 => demonstrateFill(FillType.FillZeros, FillType.FillRandom),
        2 => demonstrateFill(FillType.FillOnes, FillType.FillZeros),
        3 => demonstrateFill(FillType.FillZeros, FillType.FillOnes),
        4 => demonstrateFill(FillType.FillZeros, FillType.FillDiamond),
        _ => -1
    };

    if (task1_action == 5)
        return;
}

void Task2()
{
    var task = new Task2();
    Console.Clear();
    while(true)
    {
        var task2_commands = new List<string>()
        {
            "Add new",
            "Delete",
            "Sort",
            "Show all",
            "Find",
            "Clear",
            "Exit"
        };
        var task2_action = ArrowSelect(task2_commands) + 1;
        
        Console.Clear();
        switch (task2_action)
        {
            case 1:
                Console.WriteLine("Enter name: ");
                var name = Console.ReadLine();

                Console.WriteLine("Enter last name: ");
                var lastName = Console.ReadLine();

                Console.WriteLine("Enter group:");
                var group = Console.ReadLine();
                task.Add(name!, lastName!, group!);
                break;
            case 2:
                var all = task.GetAll();
                if (all.Count == 0) break;
                var selected = ArrowSelect(all);
                task.Delete(all[selected]);
                break;
            case 3:
                var sortTypes = new List<string>()
                {
                    "Name",
                    "LastName",
                    "Group"
                };
                var sortIndex = ArrowSelect(sortTypes) + 1;
                var sortType = sortIndex switch
                {
                    0 => SortProperty.Name,
                    1 => SortProperty.LastName,
                    2 => SortProperty.Group,
                    _ => SortProperty.LastName
                };
                var descChoose = new List<string>() {
                    "Ascending",
                    "Descending"
                };

                var sorted = task.Sort(sortType, ArrowSelect(descChoose) != 0);
                sorted.ForEach(Console.WriteLine);
                Console.ReadKey();
                break;
            case 4:
                var students = task.GetAll();
                students.ForEach(Console.WriteLine);
                Console.ReadKey();
                break;
            case 5:
                var findCommands = new List<string>()
                {
                    "Find by name",
                    "Find by last name",
                    "Find by group"
                };

                var command = ArrowSelect(findCommands) + 1;
                Console.Clear();
                var text = Console.ReadLine()!;
                Func<Student,bool> foundPredicate = command switch
                {
                    1 => stud => stud.Name.Contains(text, StringComparison.InvariantCultureIgnoreCase),
                    2 => stud => stud.LastName.Contains(text, StringComparison.InvariantCultureIgnoreCase),
                    3 => stud => stud.Group.Contains(text, StringComparison.InvariantCultureIgnoreCase),
                    _ => stud => stud.Name.Contains(text, StringComparison.InvariantCultureIgnoreCase)
                };
                var found = task.Find(foundPredicate);
                found.ForEach(Console.WriteLine);
                Console.ReadKey();
                break;
            case 6:
                task.Clear();
                break;
            case 7:
                return;
        }
        
        Console.Clear();
    }
}

void Task3()
{
    var task3 = new Task3();
    var collections = new List<string>()
    {
        "ArrayList",
        "SortedList",
        "Stack",
        "Dictionary",
        "Exit"
    };

    var operations = new List<string>() {
        "Add",
        "Remove",
        "Show all",
        "Exit"
    };

    while (true)
    {
        var col_selected = ArrowSelect(collections) + 1;
        if (col_selected == 5) return;

        var collection = (Collection) col_selected;
       
        var operation = ArrowSelect(operations) + 1;

        if (operation == 1) {
            switch (collection)
            {
                case Collection.ArrayList:
                case Collection.Stack:
                    Console.WriteLine("Enter values, separated by comma: ");
                    var listParams = Console.ReadLine()!.Split(',',
                        StringSplitOptions.RemoveEmptyEntries |
                        StringSplitOptions.TrimEntries);
                    task3.Add(collection, listParams);
                    break;
                case Collection.Dictionary:
                case Collection.SortedList:
                    Console.WriteLine("Enter values with type `key:value`, separated by comma: ");
                    var keyValueParams = Console.ReadLine()!.Split(',',
                        StringSplitOptions.RemoveEmptyEntries |
                        StringSplitOptions.TrimEntries);
                    task3.Add(collection, keyValueParams);
                    break;
            }
        } else if (operation == 2)
        {
            if (collection == Collection.Stack)
            {
                task3.Remove(collection, null);
            }
            else
            {
                Console.WriteLine("Enter values, separated by comma: ");
                var removeParams = Console.ReadLine()!
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                task3.Remove(collection, removeParams);
            }
        } else if (operation == 3)
        {
            task3.Print(collection);
            Console.ReadKey();
        }
    }
}

void Task4()
{
    var task4 = new Task4();
    task4.MainMethod();
    Console.ReadKey();
}


bool FillArray(int[,] array, FillType fillType = FillType.FillRandom)
{
    if (array.GetLength(0) != array.GetLength(1))
    {
        Console.WriteLine("Array must be NxN dimension");
        return false;
    }

    if (fillType != FillType.FillDiamond)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = fillType switch
                {
                    FillType.FillRandom => Random.Shared.Next(0, 100),
                    FillType.FillOnes => 1,
                    FillType.FillZeros => 0,
                    _ => throw new ArgumentException()
                };
            }
        }
    } else
    {
        try
        {
            int n = array.GetLength(0);
            int mid = n / 2;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (Math.Abs(mid - i) + Math.Abs(mid - j) <= mid)
                    {
                        array[i, j] = 0;
                    }
                    else
                    {
                        array[i, j] = 1;
                    }
                }
            }
        } catch { return false; }
    }
    return true;
}

void PrintMattrix(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i,j] + "\t");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int ArrowSelect<T> (List<T> items)
{
    int selectedIndex = 0; 

    Console.CursorVisible = false; 
    ConsoleKeyInfo keyInfo;

    do
    {
        Console.Clear(); 

       
        for (int i = 0; i < items.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.Write("> ");
            }
            Console.WriteLine(items[i]);
        }

        keyInfo = Console.ReadKey();

        
        if (keyInfo.Key == ConsoleKey.UpArrow && selectedIndex > 0)
        {
            selectedIndex--;
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow && selectedIndex < items.Count - 1)
        {
            selectedIndex++;
        }

    } while (keyInfo.Key != ConsoleKey.Enter); 

    Console.Clear();
    Console.CursorVisible = true;

    return selectedIndex;
}