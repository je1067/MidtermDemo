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


    void Start()
    {
        MainCamActive = true;
        MainCam.GetComponent<Camera>().enabled = true;
        CameraCamActive = false;
        CameraCam.GetComponent<Camera>().enabled = false;
        PictureScoreText.SetActive(false); 
    }


    void Update()
    {
        //transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * MouseSens, 0f);
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSens;
        mouseY = Mathf.Clamp(mouseY, -15f, 15f);

        mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * MouseSens;
        mouseX = Mathf.Clamp(mouseX, -35f, 60f);

        Camera.main.transform.localEulerAngles = new Vector3(mouseY, mouseX, 0f);

       // if (Input.GetMouseButtonDown(0))
        //{
         //   Cursor.lockState = CursorLockMode.Locked;
          //  Cursor.visible = false;
        //}

        //Setting it so that pressing Space will alternate the two cameras
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if ((MainCamActive == (true)))
            {
                CameraCamActive = true;
                MainCam.GetComponent<Camera>().enabled = false;
                MainCamActive = (false);
                CameraCam.GetComponent<Camera>().enabled = true;
                Debug.Log("Camera Cam Active");
            } else if (CameraCamActive == (true))
            {
                MainCamActive = true;
                CameraCam.GetComponent<Camera>().enabled = false;
                CameraCamActive = (false);
                MainCam.GetComponent<Camera>().enabled = true;
                Debug.Log("Main CamActive");
            }

            if ((CameraCamActive ==  (true)) && (Input.GetMouseButtonDown(0)))
            {
                MainCamActive = true;
                CameraCam.GetComponent<Camera>().enabled = false;
                CameraCamActive = (false);
                MainCam.GetComponent<Camera>().enabled = true;
                PictureScoreText.SetActive(true);
                Debug.Log("Picture Taken");
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space) && (CameraCamActive == (true)))
        //{
         //   MainCamActive = true;
        //}

       /* if (MainCamActive == (true))
        {
            CameraCam.GetComponent<Camera>().enabled = false;
            CameraCamActive =(false);
            MainCam.GetComponent<Camera>().enabled = true;
            Debug.Log("Main CamActive");
        }

        if (CameraCamActive == (true))
        {
            MainCam.GetComponent<Camera>().enabled = false;
            MainCamActive =(false);
            CameraCam.GetComponent<Camera>().enabled = true;
            Debug.Log("Camera Cam Active");
        }
   */ }
}
