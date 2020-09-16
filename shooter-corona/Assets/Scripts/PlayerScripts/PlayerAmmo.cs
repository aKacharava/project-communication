using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmmo : MonoBehaviour
{
    public int ammo = 30;
    public Text ammoDisplay;
    public int pickupAmmoCount;

    void Update()
    {
        ammoDisplay.text = "Ammo: " + ammo.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ammo")
        {
            ammo += pickupAmmoCount;

            SoundManager.PlaySound("reloading", true, false);

            Destroy(other.gameObject);
        }
    }

    public void SetAmmo(int ammoCount)
    {
        ammo = ammoCount;
    }
    public void AddAmmo(int ammoCount)
    {
        ammo += ammoCount;
    }
    public void LoseAmmo(int ammoCount)
    {
        ammo -= ammoCount;
    }
}
