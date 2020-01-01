using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int ScoreValue = 1;
    ScoreBoard scoreBoard;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard = GameObject.FindObjectOfType<ScoreBoard>();
    }

    // Update is called once per frame
   void OnParticleCollision (GameObject other)
   {
       print("DOSTAŁEM");
       scoreBoard.ScoreHit(ScoreValue);
       Destroy(gameObject);
   }
}
