using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    private float LeftLim  = -20f;    
   

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < LeftLim)
        {
            Destroy(gameObject);
        }

        /* [SerializeField] private float lifeTime = 5f; 

        void Start()
        {
              Destroy(gameObject, lifeTime);
        }
        Una altra manera de destruir per temps
        */
    }
}
