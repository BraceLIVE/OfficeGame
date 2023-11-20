using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletObj;
    public GameObject bulletSpawner;

    private bool canFire = true;

    public float fireSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButton(0)){
            if(canFire){
                canFire = false;

                Fire();
            }
        } else if(!canFire) {
            canFire = true;
        }
    }

    void Fire()
    {
            GameObject obj = Instantiate(bulletObj, bulletSpawner.transform.position, Quaternion.identity);

            Vector3 shotDirection = Camera.main.transform.forward;

            Rigidbody bulletRigbody = obj.GetComponent<Rigidbody>();

            Quaternion targetRotation = Quaternion.LookRotation(shotDirection);
            obj.transform.rotation = Quaternion.Euler(-90f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);
            
            bulletRigbody.velocity = shotDirection * fireSpeed;
    }
}
