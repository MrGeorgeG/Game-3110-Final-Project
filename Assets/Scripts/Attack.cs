using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject shellPrefab;
    public KeyCode firekey = KeyCode.Mouse0;
    public float shellSpeed = 10;

    private Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(firekey))
        {
            GameObject go = GameObject.Instantiate(shellPrefab, firePoint.position, firePoint.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * shellSpeed;
        }
    }
}
