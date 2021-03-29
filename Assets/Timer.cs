using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float realTime;
    public float minutes;
    public TextMeshProUGUI timer ;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        realTime += (1 * (Time.deltaTime/1.5f));
        realTime = Mathf.Round(realTime * 100f) / 100f;

        if (realTime > 60)
        {
            realTime = 0;
            minutes += 1;
        }

        if (realTime < 0.1f)
        {
            if (minutes < 10f)
            {
                timer.text = ("0" + minutes + ":00:0" + realTime);
            }
            else
            {
                timer.text = (minutes + ":00:0" + realTime);
            }
        }
        else if (realTime < 9.99f)
        {
            if (minutes < 10f)
            {
                timer.text = ("0" + minutes + ":0" + realTime);
            }
            else
            {
                timer.text = (minutes + ":0" + realTime);
            }
        }
        else
        {
            if (minutes < 10f)
            {
                timer.text = ("0" + minutes + ":" + realTime);
            }
            else
            {
                timer.text = (minutes + ":" + realTime);
            }
        }
        if (minutes == 99)
        {
            gameOver = true;
        }
    }
}
