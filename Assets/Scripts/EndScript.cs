using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour {

    public GameObject EndText;
    public GameObject Eyelid_Top;
    public GameObject Eyelid_Bottom;
    public GameObject Player;
	
	void Start () {
        EndText.SetActive(false);
	}
	
	
	void Update () {
		
	}

    void OnTriggerStay(Collider coll)
    {

        if (coll.gameObject.tag == "Eyelid")
        {

            Debug.Log("Eyelids Closed");
            Eyelid_Top.GetComponent<ConstantForce>().enabled = false;
            Eyelid_Bottom.GetComponent<ConstantForce>().enabled = false;
            EndText.SetActive(true);
            Player.GetComponent<ConstantForce>().enabled=false;
        }
    }
}
