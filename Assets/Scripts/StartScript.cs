using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    public GameObject StartText_1;
    public GameObject StartText_2;
    public GameObject Player;
    public GameObject Eyelid_Top;
    public GameObject Eyelid_Bottom;
    public GameObject EndText;
    public GameObject StartCover;
    public GameObject DadText1;
    public GameObject DadText2;
    public GameObject DadText3;
    public GameObject DadText4;

    public Rigidbody rb1;
    public Rigidbody rb2;
    public Rigidbody rb3;

    public float dadTime = 0.0f;

    public bool TimeToEnd;
    public bool SpaceWasPressed;
	
	void Start () {
        Player.GetComponent<ConstantForce>().enabled = false;
        Eyelid_Top.GetComponent<ConstantForce>().enabled = false;
        Eyelid_Bottom.GetComponent<ConstantForce>().enabled = false;
        StartCover.SetActive(true);
        Player.GetComponent<FirstPersonLook>().enabled = false;
        rb1 = GetComponent<Rigidbody>();
        rb2 = GetComponent<Rigidbody>();
        rb3 = GetComponent<Rigidbody>();
        DadText1.SetActive(false);
        DadText2.SetActive(false);
        DadText3.SetActive(false);
        DadText4.SetActive(false);
    }
	
	
	void Update () {
		
        if (Input.GetKey(KeyCode.Return)){
            StartText_1.SetActive(false);
            StartText_2.SetActive(false);
            StartCover.SetActive(false);
            Player.GetComponent<FirstPersonLook>().enabled = true;
            Player.GetComponent<ConstantForce>().enabled = true;
            Eyelid_Top.GetComponent<ConstantForce>().enabled = true;
            Eyelid_Bottom.GetComponent<ConstantForce>().enabled = true;
            Cursor.visible = false;
           
            SpaceWasPressed = true;
        } 
        if (TimeToEnd == true)
        {
            Debug.Log("Eyelids Closed");

            EndText.SetActive(true);

            StartCover.SetActive(true);
            Eyelid_Top.SetActive(false);
            Eyelid_Bottom.SetActive(false);
            Player.GetComponent<FirstPersonLook>().enabled = false;
        }
        if (SpaceWasPressed == true)
        {
            dadTime += Time.deltaTime;
            Cursor.visible = false;
        }
        
        if (dadTime > 4.0f)
        {
            DadText1.SetActive(true);
        }
        if (dadTime > 10.0f)
        {
            DadText1.SetActive(false);
        }
        if (dadTime > 15.0f)
        {
            DadText2.SetActive(true);
        }
        if (dadTime > 20.0f)
        {
            DadText2.SetActive(false);
        }
        if (dadTime > 25.0f)
        {
            DadText3.SetActive(true);
        }
        if (dadTime > 30.0f)
        {
            DadText3.SetActive(false);
        }
        if (dadTime > 34.0f)
        {
            DadText4.SetActive(true);
        }

    }
    void OnTriggerStay(Collider coll)
    {

        if (coll.gameObject.tag == "Eyelid")
        {
            TimeToEnd = true;
            Debug.Log("Collision Detected");
            
        }
    }
}
