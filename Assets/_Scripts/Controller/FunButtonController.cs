using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class FunButtonController : MySingleton<FunButtonController>
{
    public event Action ClickButtonOnDown;
    public event Action ClickButtonOnHold;
    public event Action ClickButtonOnFree;
    public event Action ClickButtonOnUp;

    private SpriteRenderer sr;
    public Sprite up;
    public Sprite down;
    public Rigidbody2D rig;
 
    private ParticleSystem levelUpParticle;
    private Animator animator;

    public event Action onHit;
    protected override void Awake()
    {
        base.Awake();
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        levelUpParticle = GetComponentInChildren<ParticleSystem>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        LevelManager.Instance.onLevelUp += OnLevelUp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse Down!!!");
            ClickButtonOnDown?.Invoke();
            sr.sprite = down;
        }
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Mouse Hold!!!");
            ClickButtonOnHold?.Invoke();
        }
        else
        {
            //Debug.Log("Mouse Free!!!");
            ClickButtonOnFree?.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("Mouse Up!!!");
            ClickButtonOnUp?.Invoke();       
            sr.sprite = up;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Debug.Log("Enemy Entet");
            OnHit();
            collision.transform.GetComponent<Enemy>().BlowUp();
        }
    }


    private void OnLevelUp()
    {
        animator.SetTrigger("LevelUp");
    }

    private void OnHit()
    {
        animator.SetTrigger("Hit");
        onHit?.Invoke();
        LevelManager.Instance.currentExp -= 10;
    }

    private void PlayLevelUpParticle()
    {
        levelUpParticle.Play();
    }
}
