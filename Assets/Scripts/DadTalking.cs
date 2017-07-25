using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadTalking : MonoBehaviour {

    public GameObject DadText1;
    public GameObject DadText2;
    public GameObject DadText3;
    public GameObject DadText4;

    public float dadTime = 0.0f;
	
	void Start () {
        DadText1.SetActive(false);
        DadText2.SetActive(false);
        DadText3.SetActive(false);
        DadText4.SetActive(false);
    }
	
	
	void Update () {
        dadTime += Time.deltaTime;

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
}
