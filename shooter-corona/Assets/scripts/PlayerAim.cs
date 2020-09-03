using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Camera mainCam;

    Vector3 lookPos;
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 mousePos = Input.mousePosition;
        //Vector3 playerPos = mainCam.WorldToScreenPoint(transform.localPosition);

        //Vector2 offset = new Vector3(mousePos.x - playerPos.x, mousePos.y - playerPos.z);

        //float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg - 90;

        //transform.rotation = Quaternion.Euler(0f, -angle, 0f);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt(transform.position + lookDir, Vector3.up);
    }
}
