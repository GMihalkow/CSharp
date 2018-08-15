using System;
using System.Collections.Generic;
using System.Text;

public class Threeuple<T1, T2, T3>
{
    private T1 firstParameter;
    private T2 secondParameter;
    private T3 thirdParameter;

    public Threeuple(T1 first, T2 second, T3 third)
    {
        this.FirstParameter = first;
        this.SecondParameter = second;
        this.ThirdParameter = third;
    }

    public T1 FirstParameter
    {
        get
        {
            return this.firstParameter;
        }
        private set
        {
            this.firstParameter = value;
        }
    }

    public T2 SecondParameter
    {
        get
        {
            return this.secondParameter;
        }
        private set
        {
            this.secondParameter = value;
        }
    }

    public T3 ThirdParameter
    {
        get
        {
            return this.thirdParameter;
        }
        private set
        {
            this.thirdParameter = value;
        }
    }

    public override string ToString()
    {
        return $"{this.FirstParameter} -> {this.SecondParameter} -> {this.ThirdParameter}";
    }
}