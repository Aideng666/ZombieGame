using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;
    private int _maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

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
}
