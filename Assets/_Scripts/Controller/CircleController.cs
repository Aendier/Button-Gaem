using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.AddressableAssets;
 
public class CircleController : MonoBehaviour
{
    public Transform target;
    public float speed = 50f;
    public float currentSpeed = 10f;
    public float damping = 0.02f;

    public float energy = 0f;

    [Tooltip("泡泡打气速度")]
    public float aerationSpeed = 0.1f;
    public float force = 50f;
    public GameObject bubble;
    public GameObject bubblePre;

    private SpriteRenderer sr;
    public Sprite up;
    public Sprite down;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bubblePre = Addressables.LoadAssetAsync<GameObject>("Bubble").WaitForCompletion();
    }

    private void Start()
    {
        FunButtonController.Instance.ClickButtonOnDown += OnClickButtonDown;
        FunButtonController.Instance.ClickButtonOnHold += OnClickButtonHold;
        FunButtonController.Instance.ClickButtonOnFree += OnClickButtonFree;
        FunButtonController.Instance.ClickButtonOnUp += OnClickButtonUp;
        currentSpeed = speed;
    }

    private void Update()
    {
        transform.RotateAround(target.position,Vector3.forward,currentSpeed * Time.deltaTime);
    }

    private void OnClickButtonDown()
    {
         bubble = GenerateBubble();
         sr.sprite = down;
    }
    private void OnClickButtonHold()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, 0, damping);
        energy += Time.deltaTime;
        InflateBubble();
    }
    private void OnClickButtonFree()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, speed, damping);
    }
    private void OnClickButtonUp()
    {
        ShiftButton();
        EmissionBubble();
        sr.sprite = up;
    }


    private void ShiftButton()
    {
        Vector2 forceDirection = (FunButtonController.Instance.transform.position - transform.position).normalized;
        FunButtonController.Instance.rig.AddForce(energy * force *  forceDirection);
        energy = 0f;
    }

    private GameObject GenerateBubble()
    {
        GameObject go = Instantiate(bubblePre);
        return go;
    }
    private void InflateBubble()
    {
        bubble.transform.localScale += Vector3.one * aerationSpeed;
        bubble.transform.position = transform.position;
    }
    private void EmissionBubble()
    {
        Vector2 forceDirection = (transform.position - FunButtonController.Instance.transform.position).normalized;
        bubble.GetComponent<Rigidbody2D>().AddForce(forceDirection * force);
    }
}
