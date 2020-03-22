using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Speed;


    // Welcome to a basic script to get a cube moving. Use this for demonstration purposes. In Start() we add a rigidbody component and set speed.
    void Start()
    {
        //Fetch the Rigidbody component you attach from your GameObject
        m_Rigidbody = GetComponent<Rigidbody>();
        //Speed of the GameObject
        m_Speed = 10.0f;
    }

    // These are movement command paths.
    void Update()
    {
        m_Rigidbody.velocity = transform.forward * m_Speed;

    }
}
