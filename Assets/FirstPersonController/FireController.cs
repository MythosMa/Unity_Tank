using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0) == true)
        {
            GameObject gun = GameObject.FindWithTag("gun");


            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position , transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
        }
    }
}
