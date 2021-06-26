using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour
{
    public GameObject lastFloor;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            createFloor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createFloor()
    {
        int rnd = Random.Range(0, 10);
        int rndcry = Random.Range(0, 30);
        if (rnd < 5)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.back;
        }

        lastFloor = Instantiate(lastFloor, lastFloor.transform.position + direction, lastFloor.transform.rotation);


        lastFloor.transform.GetChild(0).gameObject.SetActive(rndcry % 8 == 7);
    }
}
