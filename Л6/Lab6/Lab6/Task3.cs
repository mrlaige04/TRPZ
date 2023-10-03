using System.Collections;


namespace Lab6;
public enum Collection
{
    ArrayList = 1,
    SortedList,
    Stack,
    Dictionary
}
public class Task3
{
    private ArrayList _arrayList = new ArrayList();
    private SortedList _sortedList = new SortedList();
    private Stack _stack = new Stack();
    private Dictionary<object, object> _dictionary = new Dictionary<object, object>();

    public void Add(Collection collection, object?[] parameters)
    {
        switch (collection)
        {
            case Collection.ArrayList:
                _arrayList.AddRange(parameters);
                break;
            case Collection.SortedList:
            case Collection.Dictionary:
                foreach (var item in parameters)
                {
                    try
                    {
                        var str = item.ToString();
                        var pars = str.Split(':', StringSplitOptions.TrimEntries);
                        var key = pars[0];
                        var value = pars[1];
                        if (collection == Collection.Dictionary && !_dictionary.ContainsKey(key))
                            _dictionary.Add(key, value);
                        else if (collection == Collection.SortedList && !_sortedList.ContainsKey(key))
                            _sortedList.Add(key, value);
                        else
                        {
                            Console.WriteLine("Element with such key already exists");
                            Console.ReadKey();
                        }
                    } catch (IndexOutOfRangeException) { 
                        Console.WriteLine("Some invalid values in input");
                        Console.ReadKey();
                    }
                }
                break;
            case Collection.Stack:
                foreach (var item in parameters) {
                    _stack.Push(item);
                }
                break;
        }
    }

    public void Remove(Collection collection, object?[] parameters)
    {
        switch (collection)
        {
            case Collection.Stack:
                if (_stack.Count > 0) _stack.Pop();
                break;
            case Collection.ArrayList:
                foreach (var item in parameters)
                {
                    _arrayList.Remove(item);
                }
                break;
            case Collection.Dictionary:
                foreach(var item in parameters)
                {
                    _dictionary.Remove(item);
                }
                break;
            case Collection.SortedList:
                foreach (var item in parameters)
                {
                    _sortedList.Remove(item);
                }
                break;
        }
    }

    public void Print(Collection collection)
    {
        switch (collection)
        {
            case Collection.ArrayList:
                foreach (var parameter in _arrayList)
                {
                    Console.Write(parameter + "\t");
                }
                Console.WriteLine();
                break;
            case Collection.SortedList:
                foreach (var parameter in _sortedList)
                {
                    Console.Write(parameter + "\t");
                }
                Console.WriteLine();
                break;
            case Collection.Stack:
                foreach (var parameter in _stack)
                {
                    Console.Write(parameter + "\t");
                }
                Console.WriteLine();
                break;
            case Collection.Dictionary:
                foreach (var entry in _dictionary)
                {
                    Console.WriteLine($"{entry.Key} : {entry.Value}");
                }
                break;
        }
    }
}
