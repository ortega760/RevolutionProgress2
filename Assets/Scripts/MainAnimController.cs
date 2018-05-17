using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainAnimController : MonoBehaviour {

	static Animator anim;

	public float speed = 5.0f;
	public float rotationSpeed = 90.0f;
	public GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;
	private bool IsRunning, IsShooting, Dancing, IsCrouching, Jump, IsGathering, IsReloading, RiflePunch;
	public float time = .6f;
	public float timer;
	public Text counttext;
	public Text wintext;
	private int countt;


	public Rigidbody projectile;
	public float speed1=20; 
	public float range = 100f;
	public float damage = 10f;
	public Camera fpscam;

	public AudioSource audioSource;
	public AudioClip audioClip;




	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		timer = time;
		SetCountText ();
		wintext.text = "";
		countt = 0;


	}
		




	// Update is called once per frame
	void Update () {
		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;

		//animations
		transform.Translate (0, 0, translation);
		transform.Rotate (0, rotation, 0);

		if (translation != 0) {
			anim.SetBool ("IsWalking", true);
			speed = 5.0f;
		} else {
			anim.SetBool ("IsWalking", false);
		}

		if (Input.GetKey (KeyCode.LeftShift)) {
			IsRunning = true;
			speed = 10.0f;
		} else {
			IsRunning = false;
		}

		if (Input.GetKey (KeyCode.C)) {
			IsCrouching = true;
		} else {
			IsCrouching = false;
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

		if (Input.GetKey (KeyCode.V)) {
			Dancing = true;
		} else {
			Dancing = false;
		}
			
		if (Input.GetKey (KeyCode.Mouse0)) {
				IsShooting = true;
				;
			} else {
				IsShooting = false;
		}
	


		anim.SetBool ("IsRunning", IsRunning);
		anim.SetBool ("IsShooting", IsShooting);
		anim.SetBool ("Dancing", Dancing);
		anim.SetBool ("Jump", Jump);
		anim.SetBool ("IsReloading", IsReloading);
		anim.SetBool ("IsGathering", IsGathering);
		anim.SetBool ("IsCrouching", IsCrouching);
		anim.SetBool ("RiflePunch", RiflePunch);

		timer -= Time.deltaTime;
		if (timer < 0) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				Shoot();
				timer = time;

			}
		}
	}
	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (fpscam.transform.position, fpscam.transform.forward, out hit, range)) {
			Debug.Log (hit.transform.name);
		}
		playClip ();

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);
			countt = countt + 1;
			SetCountText ();
		}
	}
	void SetCountText()
	{
		counttext.text="Bottles of Tea Collected: " + countt.ToString() + "/3";
		if (countt >= 3) {
			wintext.text = "The War is won! Tea has influenced the tides of the war in your favor! Spam the V Button to celebrate!";

		}
	}
	public void playClip(){
		audioSource.clip = audioClip;
		audioSource.Play();
	}
}
