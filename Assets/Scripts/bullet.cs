using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {


	private float rotationSpeed = 1f;
	private float minY = -60f;
	private float maxY = 60f;
	private float rotationY = 10f;
	private float rotationX = 0f;

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	void Start () {

	}

	// Update is called once per frame

	void Update () {

		if(Input.GetKey (KeyCode.Mouse0)) {
			Fire();
		}
				
	}
	void Fire() {
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		Destroy(bullet, 2.0f);
	}
}
