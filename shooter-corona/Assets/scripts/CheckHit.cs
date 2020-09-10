using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("NPC"))
        {
            var targetFind = collision.gameObject.transform.Find("GFX");
            var targetColorChange = targetFind.GetComponent<Renderer>();
            Color colorGreen = new Color(0, 1, 0, 1); // Green color

            if (targetColorChange.material.color != colorGreen)
            {
                targetColorChange.material.color = colorGreen;
                Debug.Log("NPC Color changed");
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
