using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;
    public Gun startingGun;
    Gun equippedGun;
    


    private void Start()
    {
        if(startingGun != null)
        {
            EquipGun(startingGun);
        }
    }

    public void EquipGun(Gun guntoEquip)
    {
        if(equippedGun != null)
        {
            Destroy(equippedGun.gameObject);

        }
        equippedGun = Instantiate(guntoEquip, weaponHold.position, weaponHold.rotation);
        equippedGun.transform.parent = weaponHold;

    }

    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
}
