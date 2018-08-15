using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Lake : IEnumerable<int>
{
    public IReadOnlyList<int> StoneNumbers { get; private set; }

    public Lake(params int[] stoneNumbers)
    {
        this.StoneNumbers = stoneNumbers;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return StoneNumbers.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        List<int> oddPositions = new List<int>();
        List<int> evenPositions = new List<int>();
        for (int index = 0; index < this.StoneNumbers.Count; index++)
        {
            if (index % 2 == 0)
            {

                evenPositions.Add(this.StoneNumbers[index]);
            }
            else
            {
                oddPositions.Add(this.StoneNumbers[index]);

            }
        }
        oddPositions.Reverse();
        if ((oddPositions.Count + evenPositions.Count) == 0)
        {
            return string.Empty;
        }
        string result = string.Join(", ", evenPositions) + ", " + string.Join(", ", oddPositions);

        return result.ToString();
    }
}