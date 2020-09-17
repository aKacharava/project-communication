using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : MonoBehaviour
{
    public GameObject player;
    public GameObject floatingText;
    public float interactionRadius = 5.0f;
    public float healRate = 2.0f;

    private PlayerHealth targetHealth;

    void Start()
    {
        targetHealth = PlayerManager.instance.player.GetComponent<PlayerHealth>();
    }

    
    void Update()
    {
        float distToPlayer = Vector3.Distance(player.transform.position, transform.position);
        print(distToPlayer);
        if (distToPlayer<=interactionRadius)
        {
            floatingText.SetActive(true);
            if(Input.GetKey(KeyCode.E) && targetHealth.currentHealth > 0)
            {
                targetHealth.HealPlayer(healRate);
            }
        }
        else floatingText.SetActive(false);

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
        
    }

}
