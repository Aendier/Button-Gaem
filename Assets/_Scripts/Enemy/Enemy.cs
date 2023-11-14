using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    public float moveSpeed;

    private Explodable _explodable;

    private float exp = 10;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;

        _explodable = GetComponent<Explodable>();

    }
    private void Start()
    {
        exp = Random.Range(10, 30);
        transform.localScale *= Random.Range(1,3);
        exp += transform.localScale.x * 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            rb.MovePosition(rb.position + direction.normalized * moveSpeed * Time.deltaTime);
        }
    }

    public void Dead()
    {
        BlowUp();  
        LevelManager.Instance.GainExp(transform.position, exp);
    }

    public void BlowUp()
    {
        _explodable.explode();
        ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
        ef.doExplosion(transform.position);
        this.enabled = false;
        transform.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
