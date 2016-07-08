using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {

    //variables
    public Light light1;
    public Light light2;
	// Update is called once per frame
	void Update () {
        //slowly make the map darker
        light1.intensity -= 0.0001f;
        light2.transform.eulerAngles -= new Vector3(0.002f, 0, 0);
	}
}
