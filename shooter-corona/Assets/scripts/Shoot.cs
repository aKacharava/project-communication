using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;
    float speed = 2000f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out hit))
            //{
            GameObject _instObj = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
            Rigidbody _instObjRigBod = _instObj.GetComponent<Rigidbody>();
            _instObjRigBod.AddRelativeForce(this.transform.forward * speed);
            //}
        }
    }
}
