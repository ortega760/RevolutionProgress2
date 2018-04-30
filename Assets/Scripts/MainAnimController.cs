using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAnimController : MonoBehaviour {

	static Animator anim;

	public float speed = 5.0f;
	public float rotationSpeed = 90.0f;

	private bool IsRunning, IsShooting, Dancing, IsCrouching, Jump, IsGathering, IsReloading, RiflePunch;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis ("Vertical")*speed;
		float rotation = Input.GetAxis ("Horizontal")*rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);

		if(translation != 0){
			anim.SetBool ("IsWalking", true);
		} else{
			anim.SetBool ("IsWalking", false);
		}

		if (Input.GetKey (KeyCode.LeftShift)) {
			IsRunning = true;
		} else {
			IsRunning = false;
		}

		if (Input.GetKey (KeyCode.C)) {
			IsCrouching = true;
		} else {
			IsCrouching = false;
		}

		if (Input.GetKey (KeyCode.Mouse0)) {
			IsShooting = true;
		} else {
			IsShooting = false;
		}

		if (Input.GetKey (KeyCode.Space)) {
			Jump = true;
		} else {
			Jump = false;
		}

		if (Input.GetKey (KeyCode.F)) {
			IsGathering = true;
		} else {
			IsGathering = false;
		}

		if (Input.GetKey (KeyCode.X)) {
			RiflePunch = true;
		} else {
			RiflePunch = false;
		}

		if (Input.GetKey (KeyCode.R)) {
			IsReloading = true;
		} else {
			IsReloading = false;
		}

		if (Input.GetKey (KeyCode.Backslash)) {
			Dancing = true;
		} else {
			Dancing = false;
		}

		anim.SetBool ("IsRunning", IsRunning);
		anim.SetBool ("IsShooting", IsShooting);
		anim.SetBool ("Dancing", Dancing);
		anim.SetBool ("Jump", Jump);
		anim.SetBool ("IsReloading", IsReloading);
		anim.SetBool ("IsGathering", IsGathering);
		anim.SetBool ("IsCrouching", IsCrouching);
		anim.SetBool ("RiflePunch", RiflePunch);
	
	}
}
