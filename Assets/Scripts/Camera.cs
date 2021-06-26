using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform obje;
    Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position - obje.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (Player.die == false)
        {
            transform.position = obje.position + position;
        }
    }
}
