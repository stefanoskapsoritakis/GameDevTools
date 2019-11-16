using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRun : MonoBehaviour
{
    public Text timeText;
    public float time = 30;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }
    public void UpdateTime()
    {
        time = time - Time.deltaTime;
        timeText.text = "Time: " + Mathf.Round(time);
    }
}