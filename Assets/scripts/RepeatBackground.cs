using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPosition;
    public float repeatWitdth;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatWitdth = GetComponent<BoxCollider>().size.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPosition.x - repeatWitdth)
        {
            transform.position = startPosition;
        }
    }
}