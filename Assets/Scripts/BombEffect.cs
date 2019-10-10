using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour {

    public GameObject bombEffectPreb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print("碰到了！！！！");
        GameObject bombEffect = Instantiate(bombEffectPreb, collision.transform.position, collision.transform.rotation);

        Destroy(bombEffect.gameObject, 2.0f);
        Destroy(this.gameObject);
    }
}
