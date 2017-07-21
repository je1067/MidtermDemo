using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    Vector3 inputVector;
    Rigidbody rb;
    public float MoveSpeed = 5.0f;
    public float GravityForce = -1.0f;
    public float MouseSens = 1.0f;
    float mouseY;
    float mouseX;

    public GameObject MainCam;
    public GameObject CameraCam;
    public bool MainCamActive;
    public bool CameraCamActive;
    public GameObject PictureScoreText;
    public GameObject CameraSnap;
    public float CameraWait= 1.0f;
    

    void Start()
    {
        MainCamActive = true;
        MainCam.GetComponent<Camera>().enabled = true;
        CameraCamActive = false;
        CameraCam.GetComponent<Camera>().enabled = false;
        PictureScoreText.SetActive(false);
        CameraSnap.SetActive(false);
        Debug.Log("Game Started");
    }


    void Update()
    {
       
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSens;

        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * MouseSens;
 
        if (MainCamActive == true)
        {
            mouseY = Mathf.Clamp(mouseY, -15f, 15f);
            mouseX = Mathf.Clamp(mouseX, -35f, 60f);

        } else if (CameraCamActive == true)
        {
            mouseY = Mathf.Clamp(mouseY, -15f, 15f);
            mouseX = Mathf.Clamp(mouseX, -35f, 50f);
        }
        MainCam.transform.localEulerAngles = new Vector3(mouseY, mouseX, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
            if ((MainCamActive == (true)))
            {
                CameraCamActive = true;
                MainCam.GetComponent<Camera>().enabled = false;
                MainCamActive = (false);
                CameraCam.GetComponent<Camera>().enabled = true;
                Debug.Log("Camera Cam Active");
            }
            else if (CameraCamActive == (true))
            {
                MainCamActive = true;
                CameraCam.GetComponent<Camera>().enabled = false;
                CameraCamActive = (false);
                MainCam.GetComponent<Camera>().enabled = true;
                Debug.Log("Main CamActive");
            }
        }

        if ((CameraCamActive == (true)) && (Input.GetKey(KeyCode.Mouse0)))
        {
            CameraSnap.SetActive(true);
            Debug.Log("Mouse Clicked");
        }
        if ((CameraCamActive == (true)) && (Input.GetKeyUp(KeyCode.Mouse0))) { 
            CameraSnap.SetActive(false);
            
                MainCamActive = true;
                CameraCam.GetComponent<Camera>().enabled = false;
                CameraCamActive = (false);
                MainCam.GetComponent<Camera>().enabled = true;
                PictureScoreText.SetActive(true);
                Debug.Log("Picture Taken");
                
            }

    }
}
