using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoidHolder : ScriptableObject
{
    public LinkedList<Boid> boids = new LinkedList<Boid>();
}
