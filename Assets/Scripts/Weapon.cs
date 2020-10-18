using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //public enum WeaponType { Semi, Bu}

    public Transform spawn;

    public void Shoot()
    {
        Ray ray = new Ray(spawn.position, spawn.forward);
        RaycastHit hit;

        float shotDistance = 20;

        if (Physics.Raycast(ray, out hit, shotDistance))
        {
            shotDistance = hit.distance;

        }
        Debug.DrawRay(ray.origin, ray.direction * shotDistance, UnityEngine.Color.red, 1);
    }
}
