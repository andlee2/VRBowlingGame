using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pin : MonoBehaviour
{
    
    public bool pinKnockedDown = false;
    public ScoreManager scoreManager;
    public Vector3 startingPosition;

   
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.x != 0 && !pinKnockedDown) {
            pinKnockedDown = true;
            scoreManager.UpdateScore();
        }
    }
}
