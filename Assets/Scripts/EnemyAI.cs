using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float rotateSpeed = 5.0f;
    public float moveSpeed = 2.0f;
    public float canSeeDistance = 200.0f;
    public float fireDistance = 100.0f;

    public GameObject playerTank;
    public GameObject bulletPrefab;

    public GameObject gun;

    private Vector3 targetPosition = Vector3.zero;
    private GameObject bullet;

	// Use this for initialization
	void Start () {
        targetPosition = RandomPosition();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canSeeTarget())
        {
            targetPosition = playerTank.transform.position;

            if(inFireRange())
            {
                if(!bullet)
                {
                    doFire();
                }
            }
        }
        else
        {

            if (Vector3.Distance(transform.position, targetPosition) < 30)
            {
                targetPosition = RandomPosition();
            }
        }

        doMove();

    }

    void doFire()
    {
        bullet = Instantiate(bulletPrefab, gun.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 1000);
    }

    void doMove()
    {
        if (targetPosition != Vector3.zero)
        {
            Vector3 lookVector = targetPosition - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookVector);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotateSpeed);

            //transform.forwara--相对于世界坐标的前面
            //Vector3.forward--相对于自身的前面
            //transform.Translate(transform.forward * moveSpeed, Space.World);
            transform.Translate(Vector3.forward * moveSpeed);
        }
    }

    Vector3 RandomPosition()
    {
        float randomWidth = Random.Range(0, Const.MapWidth);
        float randomHeight = Random.Range(0, Const.MapHeight);

        Vector3 position = new Vector3(randomWidth, 0, randomHeight);

        return position;
;    }

    bool canSeeTarget()
    {
        bool canSee = false;

        if(playerTank != null)
        {
            float distance = Vector3.Distance(transform.position, playerTank.transform.position);

            if(distance < canSeeDistance)
            {
                canSee = true;
            }
        }

        return canSee;
    }

    bool inFireRange()
    {
        bool isInFireRange = false;
        if(playerTank != null)
        {
            float distance = Vector3.Distance(transform.position, playerTank.transform.position);
            if(distance < fireDistance)
            {
                isInFireRange = true;
            }
        }


        return isInFireRange;
    }
}
