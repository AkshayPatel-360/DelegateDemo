using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string desiredOutput = "Akki Desired";


        DelegateManager.Instance.Initialize();

        string s = desiredOutput;
        DelegateManager.Instance.AddDelegateTimer(() => {OutputMessage(s); },1.5f);
        desiredOutput = "Akki changed";

        DelegateManager.Instance.AddDelegateTimer(() => { OutputMessage(desiredOutput); }, 3f); 
       // DelegateManager.Instance.AddDelegateTimer(MyFunction, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        DelegateManager.Instance.Refresh();

    }


    public void MyFunction()
    {
        Debug.Log("Its Working");
    }

    public void OutputMessage(string s)
    {
        Debug.Log("S : " + s);
    }

    
}
