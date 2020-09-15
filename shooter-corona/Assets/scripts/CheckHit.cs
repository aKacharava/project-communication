using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("NPC"))
        {
            var targetFind = collision.gameObject.transform.Find("NPC_GFX");
            var targetColorChange = targetFind.GetChild(0).GetComponent<Renderer>();
            Color colorGreen = new Color(0, 1, 0, 1); // Green color

            if (targetColorChange.material.color != colorGreen)
            {
                targetColorChange.material.color = colorGreen;
                targetFind.gameObject.tag = "NPC_Masked";
                Destroy(this.gameObject);
                if (!collision.gameObject.GetComponent<NpcController>().masked)
                {
                    collision.gameObject.GetComponent<NpcController>().masked = true;
                }
            }
        }
        else
        {
            Destroy(this.gameObject, 2f);
        }
    }
}
