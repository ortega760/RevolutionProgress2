using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	
	//public Renderer rend;
	public GameObject wep;

	void Start(){
		//rend = GetComponent<Renderer> ();
		//rend.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			//wep.SetActive(true);
			//wep.renderer.enabled = true;
			wep.active = true;
		} 
			//wep.SetActive(false);
		wep.active = false;		
	}	
}
