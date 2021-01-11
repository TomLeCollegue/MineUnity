using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumpe : MonoBehaviour
{
    public float waterLow = -12.27f;
    public float waterHight = -7.35f;


    public float bladeSpeed = 50f;
    public static float LowSpeed = 5f;

    private bool threadRunning = false;
    public static bool activeThread = false;


    public static bool pumpIsActive = false;


    // Update is called once per frame
    void FixedUpdate()
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

        if (threadRunning && pumpIsActive)
        {
            Vector3 _rotation = new Vector3(0f, 1f, 0f) * bladeSpeed;
            PerformRotation(_rotation);
            
        }
    }



    private void PerformRotation(Vector3 rotation)
    {
        transform.rotation = transform.rotation * Quaternion.Euler(rotation);

    }


    private void threadFunc(object treadParamsVar)
    {
        while (threadRunning)
        {

            if(Data.waterLVL > waterHight && Data.gazLVL < 70 && !fan.FanIsActive)
            {
                pumpIsActive = true;
                while(Data.waterLVL > waterLow)
                {
                    Data.waterLVL -= LowSpeed * 0.002f;
                    System.Threading.Thread.Sleep(10);
                }
                pumpIsActive = false;
            }
        }
    }


}
