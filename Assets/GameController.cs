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
        currentCamera = camera2;
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

    }

    void Update()
    {
        // Check for input to switch cameras
        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.LeftShift))
        {
            SwitchCamera(camera1);
        }
        else if (Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.LeftShift))
        {
            SwitchCamera(camera2);
        }
        else if (Input.GetKey(KeyCode.Alpha3) && Input.GetKey(KeyCode.LeftShift))
        {
            SwitchCamera(camera3);
        }
        else if (Input.GetKey(KeyCode.Alpha4) && Input.GetKey(KeyCode.LeftShift))
        {
            SwitchCamera(camera4);
        }
        else if (Input.GetKey(KeyCode.Alpha5) && Input.GetKey(KeyCode.LeftShift))
        {
            SwitchCamera(camera5);
        }
        else if (Input.GetKey(KeyCode.Alpha6) && Input.GetKey(KeyCode.LeftShift))
        {
            SwitchCamera(camera6);
        }

        if (currentCamera == camera1) 
        {
            if (Input.GetKeyDown(KeyCode.Q)) 
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
            if (Input.GetKeyDown(KeyCode.W))
            {
                enteredMorse += "W";
            }
            if (Input.GetKeyDown(KeyCode.E))
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
            if (Input.GetKeyDown(KeyCode.R) && safe1 == false)
            {
                safePoints++;
                safe1 = true;
            }

            if (Input.GetKeyDown(KeyCode.T) && safe2 == false)
            {
                safePoints++;
                safe2 = true;
            }

            if (Input.GetKeyDown(KeyCode.Y) && safe3 == false)
            {
                safePoints++;
                safe3 = true;
            }

            if (Input.GetKeyDown(KeyCode.U))
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
