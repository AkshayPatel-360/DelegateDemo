using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class FakeLinq
{ 


    public static T GetRandomElementFromArray<T>(this T[] arr)
    {        
      
            return arr[Random.Range(0, arr.Length)];
            
    }

    public static string ConvertToString<T>( this IEnumerable<T> collection )
    {

        return string.Join(",", collection.ToArray());

        
    }


    public static List<T> ConvertArrayToList<T> ( this T[] arr)
    {

        return arr.ToList();
    }

    public static int GetFactorialOfInt (this int x)
    {
        int fact = 1;
        for (int i = 1; i <= x; i++)
        {

            fact = fact * i;
        }
        return fact;

    }


    public static void CallAfter(this DelegateManager.MyDelegate myDelegate, float timer)
    {
        DelegateManager.Instance.AddDelegateTimer(myDelegate, timer,0);
    }






}
