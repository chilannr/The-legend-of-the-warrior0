using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public int damage;
    public float destroyDistance;
    public Attack attacker;
    private Vector3 startPos;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        startPos = transform.position;
    }
    private void Update()
    {
        float distance = (transform.position - startPos).sqrMagnitude;
        if(distance>destroyDistance)
        {
            Destroy(gameObject);
        }
    }
}