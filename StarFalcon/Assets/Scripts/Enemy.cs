﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void OnParticleCollision (GameObject other)
   {
       print("DOSTAŁEM");
       Destroy(gameObject);
   }
}
