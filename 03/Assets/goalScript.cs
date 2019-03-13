using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other) {
        Debug.Log("enter");
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Finish!!");
           
            Application.LoadLevel(Application.loadedLevel);
            
            Global.Ldoor.Clear();
            Global.Lhallway.Clear();
            SceneManager.LoadScene("MainScene",LoadSceneMode.Single);
            SceneManager.LoadScene("JakScene",LoadSceneMode.Additive);
        }
    }
}
