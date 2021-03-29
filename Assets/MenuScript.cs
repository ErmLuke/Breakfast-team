using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject Controls;
    public GameObject Settings;
    public GameObject Menu;
    public GameObject Objective;
    public GameObject backCover;
    public int objectiveNum;
    public bool paused;
    public bool objectiveOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && (!paused))
        {
            if (objectiveOpen)
            {
                Invoke("CloseWindow", 0f);
            }
            if (!objectiveOpen)
            {
                Invoke("OpenPause", 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && (paused))
        {
            Invoke("CloseWindow", 0f);
        }
        if (paused)
        {
            Time.timeScale = 0f;
        }
        if (!paused)
        {
            Time.timeScale = 1.5f;
        }

        switch (objectiveNum)
        {
            case 1:
                objectiveOpen = true;
                break;
            default:
                objectiveOpen = false;
                Objective.SetActive(false);
                break;
        }

        if (objectiveNum > 1)
        {
            objectiveNum = 0;
        }
    }
    public void CloseWindow()
    {
        objectiveNum = 0;
        paused = false;
        Menu.SetActive(false);
        Controls.SetActive(false);
        Settings.SetActive(false);
        Objective.SetActive(false);
        backCover.SetActive(false);
    }
    public void OpenPause()
    {
        Menu.SetActive(true);
        Controls.SetActive(false);
        Settings.SetActive(false);
        Objective.SetActive(false);
        backCover.SetActive(true);
        paused = true;
    }
    public void OpenSettings()
    {
        Menu.SetActive(false);
        Controls.SetActive(false);
        Settings.SetActive(true);
        Objective.SetActive(false);
        backCover.SetActive(true);
        paused = true;
    }
    public void OpenControls()
    {
        Menu.SetActive(false);
        Controls.SetActive(true);
        Settings.SetActive(false);
        Objective.SetActive(false);
        backCover.SetActive(true);
        paused = true;
    }
    public void OpenObjective()
    {
        objectiveNum += 1;
        Menu.SetActive(false);
        Controls.SetActive(false);
        Settings.SetActive(false);
        Objective.SetActive(true);
    }
}
