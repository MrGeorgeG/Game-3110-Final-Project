using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Hp = 100;
    public GameObject tankExplosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TakeDamage()
    {
        if (Hp <= 0)
            return;
        Hp -= Random.Range(10, 20);

        if (Hp <= 0)
        {
            GameObject.Instantiate(tankExplosion, transform.position + Vector3.up, transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
    }
}
