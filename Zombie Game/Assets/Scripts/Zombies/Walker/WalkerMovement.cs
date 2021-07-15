using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float knockbackForce;

    Rigidbody body;
    Transform trans;

    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = (player.transform.position - trans.position).normalized * speed;
        trans.LookAt(player.transform.position);
    }

    public void Knockback(Vector3 direction)
    {
        body.AddForce(direction.normalized * knockbackForce, ForceMode.Impulse);
    }
}
