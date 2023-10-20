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

    public Camera currentCamera;
    void Awake()
    {
        currentCamera = camera1;
        camera2.enabled = false;
        camera3.enabled = false;
        camera4.enabled = false;
        camera5.enabled = false;
        artifact1Check = false;
        artifact2Check = false;
        artifact3Check = false;
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

        if (currentCamera == camera2) 
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                artifact1Check = true;
                artifact1Image.gameObject.SetActive(true);
                artifact1Object.SetActive(false);
            }
        }

        else if (currentCamera == camera3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                artifact2Check = true;
                artifact2Image.gameObject.SetActive(true);
                artifact2Object.SetActive(false);
            }
        }

        else if (currentCamera == camera4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                artifact3Check = true;
                artifact3Image.gameObject.SetActive(true);
                artifact3Object.SetActive(false);
            }
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
