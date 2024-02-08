using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Vector3 position;
    Vector3 velocity;
    Vector3 force;
    Vector3 accel;
    GameObject particle;

    float mass;
    int currentLife;
    int maxLife;

    public void Create(Vector3 pos, GameObject g)
    {
        position = pos;
        velocity = new Vector3(0, -1, 0);
        accel = new Vector3(0, 0, 0);
        particle = g;
        particle.transform.parent = transform;
        currentLife = 1;
        maxLife = 100;
        mass = 1;
        force = new Vector3(0, 0, 0);
    }

    // Start is called before the first frame update
    public void Start()
    {
    
    }

    // Update is called once per frame
    public void Update()
    {
        if(currentLife >= maxLife)
        {
            //Reset particle with random startingPos
        }
        else
        {
            accel = force / mass;
            Vector3 endVel = velocity + accel * Time.deltaTime;
            position = position + (endVel + velocity) / 2f * Time.deltaTime;
            velocity = endVel;
        }
        particle.transform.position = position;
    }

    public void ApplyForce(Vector3 f)
    {
        force += f;
    }

    public void ResetForce()
    {
        force = Vector3.zero;
    }
}
