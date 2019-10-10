using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFire : MonoBehaviour {

    public GameObject bulletPrefab;
    public Transform firePosition;
    public int fireForce = 1000;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(Const.Mouse0))
        {
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * fireForce);
        }
    }
}
