using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gazLevel : MonoBehaviour
{
    public static float gazlvl = 30f;
    public float riseGaz = 5f;

    public TextMeshProUGUI text;


    private bool threadRunning = false;
    public static bool activeThread = false; 

    private void Update()
    {
        text.text = "Niveau de gaz : " + (int)Data.gazLVL + "   (30 - 70)";

        System.Threading.ParameterizedThreadStart pts = new System.Threading.ParameterizedThreadStart(UpdateGazNature);
        System.Threading.Thread worker = new System.Threading.Thread(pts);
        worker.Priority = System.Threading.ThreadPriority.BelowNormal; // Lowest, BelowNormal, Normal, AboveNormal, Highest
        worker.IsBackground = true;


        if (!threadRunning && activeThread)
        {
            worker.Start();
            threadRunning = true;
        }
        else if (threadRunning  && !activeThread)
        {
            threadRunning = false;
        }
        
    }

   


    private void UpdateGazNature(object treadParamsVar)
    {
        while(threadRunning)
        {
            Debug.Log("Thread ");
            
            System.Threading.Thread.Sleep(10);
            Data.gazLVL += riseGaz * 0.002f;

        }
    }

}