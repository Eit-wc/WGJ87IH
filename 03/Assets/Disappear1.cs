using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            this.transform.position = this.transform.position + new Vector3 (0, 0, -1);
        }
        if (Input.GetKeyDown("u"))
        {
            this.transform.position = this.transform.position + new Vector3 (0, 0, 1);
        }
    }
}
