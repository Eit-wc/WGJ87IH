using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayRandom : MonoBehaviour
{
    [SerializeField]
    public GameObject[] doorControl;
    // Start is called before the first frame update
    public Vector3 doorInit1, doorInit2, doorInit3, doorInit4;
    void Start()
    {
        doorInit1 = doorControl[0].transform.position;
        doorInit2 = doorControl[1].transform.position;
        doorInit3 = doorControl[2].transform.position;
        doorInit4 = doorControl[3].transform.position;
        if(Global.Lhallway == null)
        {
            Global.Lhallway = new List<HallwayRandom>();
        }
        Global.Lhallway.Add(this);

    }

    public void action()
    {
        int max = 0;
            doorControl[0].transform.position = doorInit1;
            doorControl[1].transform.position = doorInit2;
            doorControl[2].transform.position = doorInit3;
            doorControl[3].transform.position = doorInit4;
            while (true)
            {
                max = 0;
                doorControl[0].transform.position = doorInit1;
                doorControl[1].transform.position = doorInit2;
                doorControl[2].transform.position = doorInit3;
                doorControl[3].transform.position = doorInit4;
                if (Random.value > 0.5)
                {
                    doorControl[0].transform.position = doorControl[0].transform.position + new Vector3(0, -5, 0);
                    max++;
                }
                if (Random.value > 0.5)
                {
                    doorControl[1].transform.position = doorControl[1].transform.position + new Vector3(0, -5, 0);
                    max++;
                }
                if (Random.value > 0.5)
                {
                    doorControl[2].transform.position = doorControl[2].transform.position + new Vector3(0, -5, 0);
                    max++;
                }
                if (Random.value > 0.5)
                {
                    doorControl[3].transform.position = doorControl[3].transform.position + new Vector3(0, -5, 0);
                    max++;
                }
                //if (max > 2)
               // {
                    break;
               // }
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            this.action();
        }
    }
}
