using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("NPC"))
        {
            Debug.Log("NPC IS HIT");
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "Gun")
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
