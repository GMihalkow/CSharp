using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class Spy
{
    public string GetFields(string className, string accessModifier)
    {
        Type classType = Type.GetType(className);
        StringBuilder stringBuilder = new StringBuilder();

        FieldInfo[] fields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).ToArray();

        switch (accessModifier)
        {
            case "protected":
                {
                    foreach (FieldInfo field in fields.Where(f=>f.IsFamily).ToArray())
                    {
                        stringBuilder.AppendLine(string.Format($"protected {field.FieldType.Name} {field.Name}"));
                    }
                }
                break;
            case "public":
                {
                    foreach (FieldInfo field in fields.Where(f => f.IsPublic).ToArray())
                    {
                        stringBuilder.AppendLine(string.Format($"public {field.FieldType.Name} {field.Name}"));
                    }
                }
                break;
            case "private":
                {
                    foreach (FieldInfo field in fields.Where(f => f.IsPrivate).ToArray())
                    {
                        stringBuilder.AppendLine(string.Format($"private {field.FieldType.Name} {field.Name}"));
                    }
                }
                break;
            case "all":
                {
                    foreach (FieldInfo field in fields)
                    {
                        if (field.IsFamily)
                        {
                            stringBuilder.AppendLine(string.Format($"protected {field.FieldType.Name} {field.Name}"));

                        }
                        else if(field.IsPublic)
                        {
                            stringBuilder.AppendLine(string.Format($"public {field.FieldType.Name} {field.Name}"));

                        }
                        else if (field.IsPrivate)
                        {
                            stringBuilder.AppendLine(string.Format($"private {field.FieldType.Name} {field.Name}"));

                        }
                    }
                }
                break;
        }
        return stringBuilder.ToString().Trim();
    }
}