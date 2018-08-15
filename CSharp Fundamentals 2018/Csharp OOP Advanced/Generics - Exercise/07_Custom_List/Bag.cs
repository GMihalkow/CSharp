using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Bag<T>
    where T : IComparable<T>
{
    private List<T> inventory;

    public Bag(List<T> inventory)
    {
        this.Inventory = inventory;
    }


    public List<T> Inventory
    {
        get
        {
            return this.inventory;
        }
        private set
        {
            this.inventory = value;
        }
    }

    public void Add(T element)
    {
        this.inventory.Add(element);
    }

    public T Remove(int index)
    {
        T temp = this.inventory[index];
        this.inventory.RemoveAt(index);
        return temp;
    }

    public bool Contains(T element)
    {
        bool IsThere = this.inventory.Contains(element);
        return IsThere;
    }

    public void Swap(int index1, int index2)
    {
        T temp1 = this.inventory[index1];
        T temp2 = this.inventory[index2];

        this.inventory.RemoveAt(index1);
        this.inventory.Insert(index1, temp2);

        this.inventory.RemoveAt(index2);
        this.inventory.Insert(index2, temp1);

    }

    public int CountGreaterThan(T element)
    {
        List<T> GreaterElements = this.inventory.Where(e => e.CompareTo(element) > 0).ToList();
        return GreaterElements.Count;
    }

    public T Max()
    {
        return this.inventory.Max();
    }

    public T Min()
    {
        return this.inventory.Min();
    }

    public string Print()
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (T element in this.inventory)
        {
            stringBuilder.AppendLine(string.Format($"{element}"));
        }

        return stringBuilder.ToString().TrimEnd();
    }
}