using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    private int _health = 20;

    // Update is called once per frame
    void Update()
    {
        if (_health < 1)
        {
            Die();
        }
    }

    void TakeDamage(int damage)
    {
        _health -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);

            TakeDamage(other.gameObject.GetComponent<Bullet>().GetDamage());
            Debug.Log("Damaged");
        }
    }
}
