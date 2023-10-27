using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Camera camera4;
    public Camera camera5;
    public Camera camera6;
    private bool atRoom1;
    private bool atRoom2;
    private bool atRoom3;
    public int cameraNumber;
    public GameObject artifact1Object;
    public bool artifact1Check;
    public Image artifact1Image;
    public GameObject artifact2Object;
    public bool artifact2Check;
    public Image artifact2Image;
    public GameObject artifact3Object;
    public bool artifact3Check;
    public Image artifact3Image;
    public GameObject gameWinPanel;
    public int hammerHits;
    public string enteredMorse;
    public int safePoints;
    private bool safe1;
    private bool safe2;
    private bool safe3;

    public Camera currentCamera;
    void Awake()
    {
        currentCamera = camera1;
        cameraNumber = 1;
        camera1.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
        camera5.enabled = false;
        camera6.enabled = false;
        artifact1Check = false;
        artifact2Check = false;
        artifact3Check = false;
        safe1 = false;
        safe2 = false;
        safe3 = false;
        atRoom1 = false;
        atRoom2 = false;
        atRoom3 = false;

    }

    void Update()
    {
        currentCamera = camera1;
        /*
        if (Input.GetKeyDown(KeyCode.Space) && atRoom1 == false && artifact1Check == false)
        {
            SwitchCamera(camera2);
            atRoom1 = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && atRoom1 == true & artifact1Check == true)
        {
            SwitchCamera(camera3);
        }

        else if(Input.GetKeyDown(KeyCode.Space) && atRoom2 == false && artifact1Check == true)
        {
            SwitchCamera(camera4);
            atRoom2 = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space) && atRoom2 == true & artifact2Check == true && artifact1Check == true)
        {
            SwitchCamera(camera5);
        }

        else if(Input.GetKeyDown(KeyCode.Space) && atRoom3 == false && artifact1Check == true)
        {
            SwitchCamera(camera6);
            atRoom3 = true;
        }
        else if(Input.GetKeyUp(KeyCode.Space) && atRoom3 == true)
        {
            SwitchCamera(camera1);
        }
        /* Check for input to switch cameras
        if (cameraNumber == 1)
        {
            
        }
        else if (cameraNumber == 2)
        {
            
        }
        else if (cameraNumber == 3)
        {
            SwitchCamera(camera3);
        }
        else if (cameraNumber == 4)
        {
            SwitchCamera(camera4);
        }
        else if (cameraNumber == 5)
        {
            SwitchCamera(camera5);
        }
        else if (cameraNumber == 6)
        {
            SwitchCamera(camera6);
        }
        else if (cameraNumber == 7)
        {
            SwitchCamera(camera1);
            cameraNumber = 1;
        }*/

        if (currentCamera == camera2) 
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                hammerHits++;
                if (hammerHits == 5)
                {
                    artifact1Check = true;
                    artifact1Image.gameObject.SetActive(true);
                    artifact1Object.SetActive(false);
                }
            }
        }

        else if (currentCamera == camera4)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                enteredMorse += "W";
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                enteredMorse += "E";
            }

            if (enteredMorse == "WWWEEEWWW")
            {
                artifact2Check = true;
                artifact2Image.gameObject.SetActive(true);
                artifact2Object.SetActive(false);
            }
        }

        else if (currentCamera == camera6)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && safe1 == false)
            {
                safePoints++;
                safe1 = true;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && safe2 == false && safe1 == true)
            {
                safePoints++;
                safe2 = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && safe3 == false && safe2 == true)
            {
                safePoints++;
                safe3 = true;
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && safe3 == true)
            {
                safePoints++;
                if (safePoints == 4)
                {
                    artifact3Check = true;
                    artifact3Image.gameObject.SetActive(true);
                    artifact3Object.SetActive(false);
                }
            }


        }

        if (currentCamera != camera4)
        {
            enteredMorse = "";
        }
        if (currentCamera != camera6)
        {
            safePoints = 0;
        }

        if (artifact1Check && artifact2Check && artifact3Check)
        {
            gameWinPanel.SetActive(true);
        }
    }

    //&& Input.GetKeyDown(KeyCode.LeftShift)

    void SwitchCamera(Camera newCamera)
    {
        if (currentCamera != null)
        {
            currentCamera.enabled = false;
        }

        newCamera.enabled = true;
        currentCamera = newCamera;
    }
}
