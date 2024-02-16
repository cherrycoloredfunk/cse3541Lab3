using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    IList<Particle> particles = new List<Particle>();
    Plane p;

    // Start is called before the first frame update
    void Start()
    {
        p = new Plane(new Vector3(1, 1, 0), new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (particles.Count < 100)
        {
            GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Particle p = s.AddComponent<Particle>();
            p.Create(new Vector3(Random.Range(-5, 5), 8, Random.Range(0, 5)), s);
            particles.Add(p);
        }
        foreach (Particle part in particles)
        {
            part.ApplyForce(new Vector3(0, -9.8f, 0));
            part.Update();
            part.ResetForce();


            //Check if collision with the plane occurs
            if (Vector3.Dot(part.position, p.normal) <= 0)
            {
                Vector3 u = (Vector3.Dot(part.velocity, p.normal) / Vector3.Dot(p.normal, p.normal)) * p.normal;
                Vector3 w = part.velocity - u;
                part.velocity = w - u;
            }

        }
    }
}
