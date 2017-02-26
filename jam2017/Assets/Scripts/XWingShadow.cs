using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWingShadow : MonoBehaviour {
    Rigidbody2D tankBody;
    public int speed;

    // Use this for initialization
    void Start()
    {
        tankBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tankBody.velocity = transform.parent.right * speed;
    }
}
