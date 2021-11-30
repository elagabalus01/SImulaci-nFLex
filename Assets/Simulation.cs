using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    Vector3 acceleration, velocity, position, p0;
    Vector3 force;

    public Vector3 gravity = new Vector3(0.0f,-9.81f, 0.0f);
    public float mass = 1.0f;
    public float K = 10.0f;
    public float D = 1.0f;

    public GameObject referenceObject;
    public GameObject massObject;

    // Start is called before the first frame update
    void Start()
    {

        p0 = referenceObject.transform.position;
        position = p0;
        massObject.transform.position = p0;

        velocity = new Vector3(0.0f, 0.0f, 0.0f);
        acceleration = new Vector3(0.0f, 0.0f, 0.0f);
        force = new Vector3(0.0f, 0.0f, 0.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (referenceObject == null) return;
        if (massObject      == null) return;

        p0 = referenceObject.transform.position;

        force = mass * gravity - K * (position-p0) - D * velocity;

        acceleration = force / mass;

        velocity += acceleration * Time.deltaTime;

        position += velocity * Time.deltaTime;

        massObject.transform.position = position;

        Debug.DrawLine(p0, position);

    }
}
