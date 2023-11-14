using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    private float timer;
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        transform.position += new Vector3(0,0.1f,0);
        if (timer > 4)
        {
            Destroy(gameObject);
        }
    }
}
