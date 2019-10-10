using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float boomRadius = 200.0f;
    public float boomPower = 2000.0f;
    public GameObject boomEffectPrefabs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, boomRadius);
        foreach(Collider hitObject in colliders)
        {
            Rigidbody rb = hitObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(boomPower, transform.position, boomRadius);
            }
        }

        GameObject bombEffect = Instantiate(boomEffectPrefabs, transform.position, transform.rotation);
        Destroy(bombEffect.gameObject, 10.0f);

        print("碰到了！！！！");
        Destroy(this.gameObject);
    }
}
