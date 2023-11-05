using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        transform.position = Vector3.SmoothDamp(transform.position, transform.position + new Vector3(0, 1, 0), ref _velocity, 0, 3000, Time.deltaTime);
    }
}
