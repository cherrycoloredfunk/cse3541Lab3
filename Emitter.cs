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
        for(int i = 0; i < 10; i ++)
        {
            GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Particle p = s.AddComponent<Particle>();
            p.Create(new Vector3(Random.Range(0, 5), Random.Range(0, 5), Random.Range(0, 5)), s);
            particles.Add(p);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Particle p in particles)
        {
            p.Update();
        }
    }
}
