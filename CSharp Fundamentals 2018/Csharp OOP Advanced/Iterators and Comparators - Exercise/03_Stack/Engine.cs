using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private Stack<int> stack;

    public Engine(List<int> stack)
    {
        this.Stack= new Stack<int>(stack);
    }

    public Stack<int> Stack
    {
        get
        {
            return this.stack;
        }
        private set
        {
            this.stack = value;
        }
    }

    public void Pop()
    {
        try
        {
            this.stack.Pop();
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }

    public void Push(params int[] elements)
    {
        int[] items = elements;
        this.stack.Push(elements);
    }

}