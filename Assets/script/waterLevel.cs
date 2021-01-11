using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterLevel : MonoBehaviour
{

    

    public static float gazlvl = 30f;
    public float riseWater = 5f;

    private bool threadRunning = false;
    public static bool activeThread = false;

    public Transform water;



    // Update is called once per frame
    void Update()
    {
        System.Threading.ParameterizedThreadStart pts = new System.Threading.ParameterizedThreadStart(UpdateWaterNature);
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

        if (threadRunning)
        {
            LowWaterLevel();
        }


    }

    private void LowWaterLevel()
    {
        Vector3 position = new Vector3(-0.5296079f, Data.waterLVL, -0.6f);
        water.position = position;
    }

    private void UpdateWaterNature(object treadParamsVar)
    {
        while (threadRunning)
        {

            Debug.Log("Thread ");

            System.Threading.Thread.Sleep(10);
            Data.waterLVL += riseWater * 0.002f;

        }
    }

}
