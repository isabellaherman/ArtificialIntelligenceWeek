using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var movementX = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * MovementSpeed;

        var movementY = Input.GetAxis("Vertical");

        transform.position += new Vector3(0, movementY, 0) * Time.deltaTime * MovementSpeed;
    }
}
