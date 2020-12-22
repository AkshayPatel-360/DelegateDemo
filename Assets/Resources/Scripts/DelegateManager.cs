using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateManager
{
    // Start is called before the first frame update
    #region singleton

    private static DelegateManager instance;
    public static DelegateManager Instance { get { return instance ?? (instance = new DelegateManager()); } }
    private DelegateManager() { }
    #endregion

    public delegate void MyDelegate();
    List<DelegateTimer> delegateTimers;



    public void Initialize()
    {
        delegateTimers = new List<DelegateTimer>();
    }


    public void AddDelegateTimer(MyDelegate toInvoke, float time , int sameFunctionCallCount )
    {
        DelegateTimer toAdd = new DelegateTimer(toInvoke,Time.time+ time,sameFunctionCallCount);
        delegateTimers.Add(toAdd);
    }
    

    public void Refresh()
    {

         for (int i = delegateTimers.Count - 1; i >=0; i--)
        {

            if (delegateTimers[i].timeOfInvoke <= Time.time)
            {

                for (int j = 0; j < delegateTimers[i].invokeCount; j++)
                {

                    try
                    {
                        delegateTimers[i].delegateToInvoke.Invoke();
                    }
                    catch (System.Exception)
                    {

                        Debug.LogError("Problem while invoking");
                    }

                    
                    




                }

                delegateTimers.RemoveAt(i);

            }

        }

    }

   

   

    
  






    /* public void InvokeCallCount(int x)

     {
         for (int i = 0; i < x; i++)
         {

             if (delegateTimers[])
             {

             }


         }


     }*/

    public void EndGame() 
    {
        delegateTimers.Clear();
    }

    private class DelegateTimer
    {
        public float timeOfInvoke;
        public MyDelegate delegateToInvoke;
        public int invokeCount;

        public DelegateTimer( MyDelegate delegateToInvoke, float timeofInvokee , int invokeCount)
        {
            this.timeOfInvoke = timeofInvokee;
            this.delegateToInvoke = delegateToInvoke;
            this.invokeCount = invokeCount;
        }


    }
}
