// Интерфейс, который объединяет все компоненты дерева
public interface IComponent
{
    void Add(IComponent component);
    void Remove(IComponent component);
    void Display(int depth);
}

// Класс-лист, представляющий отдельный элемент дерева
public class Leaf : IComponent
{
    private string _name;

    public Leaf(string name)
    {
        _name = name;
    }

    public void Add(IComponent component)
    {
        Console.WriteLine("Cannot add to a leaf");
    }

    public void Remove(IComponent component)
    {
        Console.WriteLine("Cannot remove from a leaf");
    }

    public void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + _name);
    }
}

// Класс, представляющий композит, объединяющий несколько элементов
public class Composite : IComponent
{
    private List<IComponent> _children = new List<IComponent>();

    public void Add(IComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IComponent component)
    {
        _children.Remove(component);
    }

    public void Display(int depth)
    {
        Console.WriteLine(new String('-', depth) + "Composite");
        foreach (IComponent component in _children)
        {
            component.Display(depth + 2);
        }
    }
}

class program
{
    static void Main(string[] args)
    {
        Composite root = new Composite();

        Console.WriteLine("Введите название корневого элемента:");
        string name = Console.ReadLine();
        root.Add(new Leaf(name));

        while (true)
        {
            Console.WriteLine("Хотите добавить новый элемент? (y/n)");
            string answer = Console.ReadLine();

            if (answer == "y")
            {
                Console.WriteLine("Введите название нового элемента:");
                string childName = Console.ReadLine();
                root.Add(new Leaf(childName));
            }
            else if (answer == "n")
            {
                break;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
            }
        }

        Console.WriteLine("\nДерево элементов:");

        root.Display(1);
    }


}
