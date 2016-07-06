﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Target : MonoBehaviour {

    
    public GameObject Turret;
    public GameObject Barrel;
    public GameObject target;
    float gravity = 9.81f;
    public Slider FiringVel;
 

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Targetrecticle();
	}

    public void Targetrecticle()
    {
        
        float firerad = Barrel.transform.rotation.y;
        float launchangle = 2 * firerad;
        float velocity = FiringVel.value;
        float velocity2 = velocity * velocity;
        float sin = Mathf.Sin(launchangle);
        float calc1 = velocity2 * sin;
        float MaxDistance = (calc1 / gravity) / 2000;
        Debug.Log("max distance is " + MaxDistance);
        transform.localPosition = new Vector3(0, 0, MaxDistance);
        
    }
        
}

