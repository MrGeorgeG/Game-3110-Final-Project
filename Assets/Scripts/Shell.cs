using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject shellExplosionPrefab;

    public void OnTriggerEnter(Collider collider)
    {
        GameObject.Instantiate(shellExplosionPrefab, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
        if (collider.tag == "Player")
        {
            collider.SendMessage("TakeDamage");
        }
    }
}
