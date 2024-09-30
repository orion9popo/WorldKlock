using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

public class CLock : MonoBehaviour
{
    public Transform hourPivot, minutePivot, secondPivot;
    public TimeZoneInfo timeZone;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tick();
    }

    public void tick()
    {
        DateTime now = DateTime.Now;
        DateTime differentTime = TimeZoneInfo.ConvertTime(now, timeZone);

        hourPivot.rotation = Quaternion.Euler(0, differentTime.Hour * 30 + now.Minute / 2, 0);
        minutePivot.rotation = Quaternion.Euler(0, now.Minute * 6 + now.Second / 10, 0);
        secondPivot.rotation = Quaternion.Euler(0, now.Second * 6, 0);
    }

}
