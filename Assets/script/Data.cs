using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static float gazLVL = 30;
    public static float waterLVL = -12f;



    public float ForcePump = 5f;
    public float ForceFan = 5f;

    public bool ActiveFan = false;
    public bool ActivePump = false;
    
    public bool ActiveWaterRising = false;
    public bool ActiveGazRising = false;


    private void Update()
    {
        fan.activeThread = ActiveFan;
        pumpe.activeThread = ActivePump;
        gazLevel.activeThread = ActiveGazRising;
        pumpe.LowSpeed = ForcePump;
        fan.pumpValue = ForceFan;
        waterLevel.activeThread = ActiveWaterRising;
    }



}
