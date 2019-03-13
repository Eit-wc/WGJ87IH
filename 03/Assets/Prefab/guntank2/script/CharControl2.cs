using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControl2 : MonoBehaviour
{
    private Rigidbody rb;
    public float rotage_speed = 100;
    public float move_speed = 100;
    public float max_speed = 100;
    public ForceMode fm = ForceMode.Force;
    private Vector3 rotageVec;
    private Vector3 m_camForward;
    private Transform m_cam;
    private Vector3 TragetMove;

    // Start is called before the first frame update

    float h,v;

    GameObject objWheelR,objWheelL;
 
    Material matWheelR,matWheelL;

    Vector3 moveForce;
    public float animeSpeed = 5;

    AudioSource auds;


    Vector3 worldPar;

    void Start()
    {
        auds = GetComponent<AudioSource>();
        auds.volume = 0.0f;
        auds.loop = true;
        auds.Play();

        rb = GetComponent<Rigidbody>();
        rotageVec = new Vector3(0,1,0);
        
        objWheelR = this.transform.Find("WheelR").gameObject;
        objWheelL = this.transform.Find("WheelL").gameObject;

        // wheel
        matWheelR = objWheelR.GetComponent<MeshRenderer>().materials[0];
        matWheelL = objWheelL.GetComponent<MeshRenderer>().materials[0];
        
        matWheelR.SetFloat("Vector1_19DBBA1C",0);
        matWheelL.SetFloat("Vector1_19DBBA1C",0);

        m_cam = Camera.main.transform;
        TragetMove = Vector3.zero;
        worldPar = new Vector3(1, 0, 1);
    }

    private void FixedUpdate() {
        
        m_camForward = Vector3.Scale(m_cam.forward, worldPar).normalized;
        
        
        // read inputs
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        TragetMove = (m_camForward * h) + (m_cam.right * -v);

        rotageVec = Vector3.RotateTowards(this.transform.forward,TragetMove,Time.deltaTime * rotage_speed,0.0f);
        this.transform.rotation = Quaternion.LookRotation(rotageVec);

        matWheelR.SetFloat("Vector1_19DBBA1C",(v - h)*animeSpeed);
        matWheelL.SetFloat("Vector1_19DBBA1C",(v + h)*animeSpeed);


        moveForce = (transform.right * move_speed) * TragetMove.magnitude * Time.deltaTime;

        if(rb.velocity.magnitude < max_speed)
        {
            rb.AddForce(moveForce ,fm);
        }

        if((h>0.01f) ||(h<-0.01f) || (v>0.01f) ||(v<-0.01f))
        {
            auds.volume = Mathf.Lerp(auds.volume,0.5f,Time.deltaTime*10.0f);
            
        }else
        {
            auds.volume = Mathf.Lerp(auds.volume,0.0f,Time.deltaTime*10.0f);
        }

    }


}
