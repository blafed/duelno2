using System.Collections.Generic;
public static class ListUtils
{
    public static void insertUntil<T>(this List<T> list, int index, T item, T defaultFill = default(T))
    {
        if (index < list.Count)
            list.Insert(index, item);
        else
        {
            list.Capacity = index + 1;
            for (int i = list.Count; i < index; i++)
            {
                list.Add(defaultFill);
            }
            list.Add(item);
        }
    }
}