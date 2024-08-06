using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager_PS : MonoBehaviour
{
    public List<Transform> weaponSlot = new List<Transform>();
    int currentWeaponSlot = 1;

    public void AddWeapon(GameObject weaponPrefab)
    {
        if (currentWeaponSlot < weaponSlot.Count)
        {
            Instantiate(weaponPrefab, weaponSlot[currentWeaponSlot]);
            currentWeaponSlot++;
        }
    }
    
}
