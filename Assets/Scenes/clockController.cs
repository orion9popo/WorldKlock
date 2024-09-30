using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class clockController : MonoBehaviour
{

    public GameObject prefab;
    
    Dictionary<String, Transform> lehands = new Dictionary<String, Transform>();
    List<CLock> clocks = new List<CLock>(); 
    int i = 0;
    TimeZoneInfo[] timeZoneValues = {
    TimeZoneInfo.FindSystemTimeZoneById("Europe/London") ,
    TimeZoneInfo.FindSystemTimeZoneById("Asia/Bangkok"),
    TimeZoneInfo.FindSystemTimeZoneById("Asia/Tokyo"),
    TimeZoneInfo.FindSystemTimeZoneById("Australia/Sydney"),
    TimeZoneInfo.FindSystemTimeZoneById("America/New_York")
    };
    // Start is called before the first frame update
    void Start()
    {
        foreach (TimeZoneInfo timeZone in timeZoneValues)
        {
            DateTime now = DateTime.Now;
            String str = timeZone.Id.Substring(timeZone.Id.IndexOf("/")+ 1);
            Debug.Log(str);
            Vector3 pos = GameObject.Find(str).transform.position;
            GameObject instance = Instantiate(prefab, pos, Quaternion.identity);
            CLock instanceScript = instance.GetComponent<CLock>();
            clocks.Add(instanceScript);
            instance.transform.parent = this.gameObject.transform;
            instanceScript.timeZone = timeZone;

            foreach (Transform part in instance.transform)
            {
                if ("PivotHPivotMPivotS".Contains(part.name))
                {
                    lehands[part.name] = part;
                }
            }
            instanceScript.hourPivot = lehands["PivotH"];
            instanceScript.minutePivot = lehands["PivotM"];
            instanceScript.secondPivot = lehands["PivotS"];
            i += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
