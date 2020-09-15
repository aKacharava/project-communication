using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;
    float speed = 2000f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponentInParent<PlayerAmmo>().ammo > 0 && Time.timeScale != 0f)
        {
            SoundManager.PlaySound("gun sound", true, false);
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        GameObject _instObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
        Rigidbody _instObjRigBod = _instObj.GetComponent<Rigidbody>();
        _instObjRigBod.AddRelativeForce(this.transform.forward * speed);
        GetComponentInParent<PlayerAmmo>().LoseAmmo(1);
    }
}
