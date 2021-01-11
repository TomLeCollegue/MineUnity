using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fan : MonoBehaviour
{
    
    public float bladeSpeed = 50f;
    public static float pumpValue = 5f;

    private bool threadRunning = false;
    public static bool activeThread = false;

    public static bool FanIsActive = false;

    // Update is called once per frame
    void Update()
    {

        
        System.Threading.ParameterizedThreadStart pts = new System.Threading.ParameterizedThreadStart(threadFunc);
        System.Threading.Thread worker = new System.Threading.Thread(pts);
        worker.Priority = System.Threading.ThreadPriority.BelowNormal; // Lowest, BelowNormal, Normal, AboveNormal, Highest
        worker.IsBackground = true;


        if (!threadRunning && activeThread)
        {
            worker.Start();
            threadRunning = true;
        }
        else if (threadRunning && !activeThread)
        {
            threadRunning = false;
        }

        if (threadRunning && FanIsActive)
        {
            Vector3 _rotation = new Vector3(0f, 1f, 0f) * bladeSpeed;
            PerformRotation(_rotation);
        }
    }

    private void threadFunc(object treadParamsVar)
    {
        while (threadRunning)
        {
            if(Data.gazLVL > 70 && Data.waterLVL > -7.35 )
            {
                FanIsActive = true;
                while (Data.gazLVL > 30)
                {
                    Data.gazLVL -= pumpValue * 0.002f;
                    System.Threading.Thread.Sleep(10);
                }
                FanIsActive = false;
            }
            if (Data.gazLVL > 70 && pumpe.pumpIsActive)
            {
                FanIsActive = true;
                while (Data.gazLVL > 30)
                {
                    Data.gazLVL -= pumpValue * 0.002f;
                    System.Threading.Thread.Sleep(10);
                }
                FanIsActive = false;
            }
        }
    }

    private void PerformRotation(Vector3 rotation)
    {
        transform.rotation = transform.rotation * Quaternion.Euler(rotation);
    }
}
