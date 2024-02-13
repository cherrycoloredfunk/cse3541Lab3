using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    IList <Particle> particles = new List <Particle> ();
    // Start is called before the first frame update
    void Start()
    {
        //GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Particle p = s.AddComponent<Particle>();
        //p.Create(new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)), s);
        //particles.Add(p);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (particles.Count < 60)
        {
            GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Particle p = s.AddComponent<Particle>();
            p.Create(new Vector3(Random.Range(-5, 5), 8, Random.Range(0, 5)), s);
            particles.Add(p);
        }
        foreach (Particle part in particles)
        {
            part.ApplyForce(new Vector3(0, -1.0f, 0));
            part.Update();
            if(part.position.y <= -3)
            {
                part.velocity *= -1;
            }
        }
    }
}
