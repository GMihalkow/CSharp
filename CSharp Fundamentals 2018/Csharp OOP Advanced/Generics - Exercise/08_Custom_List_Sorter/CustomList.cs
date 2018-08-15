using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T>
    where T : IComparable<T>
{
    private List<T> inventory;

    public CustomList(List<T> list)
    {
        this.Inventory = list;
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
        List<T> GreaterItems = this.inventory.Where(e => e.CompareTo(element) > 0).ToList();
        return GreaterItems.Count;
    }

    public T Max()
    {
        List<T> Elements = this.inventory.OrderByDescending(e => e).ToList();
        return Elements.First();
    }

    public T Min()
    {
        List<T> Elements = this.inventory.OrderBy(e => e).ToList();
        return Elements.First();
    }

    public void Sort()
    {
        this.inventory = this.inventory.OrderBy(e => e).ToList();
    }

}