﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.AI;

public class SteeringBehaviour : MonoBehaviour
{
    public float weighting = 7.5f;
    protected AI owner; // Reference to owner (for getting Velocity)

    // Start is called before the first frame update
    void Awake()
    {
        // Get the AI that this steering behaviour is attached to
        owner = GetComponent<AI>();
    }

    public virtual Vector3 GetForce()
    {
        // SET force to zero
        Vector3 force = Vector3.zero;

        // Do nothing in the base class (always returns zero)

        // Return force
        return force;
    }
}