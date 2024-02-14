using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public Vector3 position;
    public Vector3 velocity;
    Vector3 force;
    Vector3 accel;
    GameObject particle;

    float mass;
    int currentLife;
    int maxLife;

    public void Create(Vector3 pos, GameObject g)
    {
        position = pos;
        velocity = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        force = new Vector3(0, 0, 0);
        particle = g;
        particle.transform.parent = transform;
        particle.transform.localScale = new Vector3(.5f, .5f, .5f);
        currentLife = 1;
        maxLife = 300;
        mass = 1;
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
            ResetForce();
            accel = new Vector3(0, 0, 0);
            velocity = new Vector3(0, 0, 0);
            position = new Vector3(Random.Range(-5, 5), 8, Random.Range(0, 5));
            currentLife = 0;

        }
        else
        {
            accel = force / mass;
            Vector3 endVel = velocity + accel * Time.deltaTime;
            position = position + (endVel + velocity) / 2f * Time.deltaTime;
            velocity = endVel;

            // Calculate the progress of color change (0 to 1)
            float progress = Mathf.Clamp01((float)currentLife / (float)maxLife);

            // Interpolate between startColor and endColor based on progress
            Color newColor = Color.Lerp(Color.white, Color.blue, progress);

            // Apply the new color to the object's material
            GetComponent<Renderer>().material.color = newColor;
        }
        particle.transform.position = position;
        currentLife++;
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
