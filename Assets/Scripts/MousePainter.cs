using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePainter : MonoBehaviour {
    public Transform paintGlob;
	
	void Start () {
		
	}
	
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit = new RaycastHit();
        if (Physics.Raycast(ray,out rayHit, 100f))
        {
            //paintGlob.position = rayHit.point;
            Instantiate(paintGlob, rayHit.point, Quaternion.Euler(0f, 0f, 0f));
        }
	}
}
