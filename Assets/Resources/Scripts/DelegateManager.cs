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


    public void AddDelegateTimer(MyDelegate toInvoke, float time )
    {
        DelegateTimer toAdd = new DelegateTimer(toInvoke,Time.time+ time);
        delegateTimers.Add(toAdd);
    }
    

    public void Refresh()
    {

         for (int i = delegateTimers.Count - 1; i >=0; i--)
        {

            if (delegateTimers[i].timeOfInvoke <= Time.time)
            {
                delegateTimers[i].delegateToInvoke.Invoke();
                delegateTimers.RemoveAt(i);

            }

        }

    }

    public void EndGame() 
    {
        delegateTimers.Clear();
    }

    private class DelegateTimer
    {
        public float timeOfInvoke;
        public MyDelegate delegateToInvoke;

        public DelegateTimer( MyDelegate delegateToInvoke, float timeofInvokee)
        {
            this.timeOfInvoke = timeofInvokee;
            this.delegateToInvoke = delegateToInvoke;
        }


    }
}
