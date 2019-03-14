using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class gamePlayCore : MonoBehaviour
{
    
    public NavMeshSurface navSurface;
    [SerializeField]
    public GameObject startPointsList;

    [SerializeField]
    public GameObject endPointsLists;

    public List<Vector3> startVecList;
    public List<Vector3> endVecList;

    public GameObject startObject;
    public GameObject endObject;
    private NavMeshAgent navAgent;

    public bool FoundEndPoint = false;

    private NavMeshPath navPath;
    public bool debug_automove = false;

    // Start is called before the first frame update
    void Start()
    {

        Scene LevelScene = SceneManager.GetSceneByName("JakScene");
        if(!LevelScene.isLoaded)
        {
            SceneManager.LoadScene("JakScene",LoadSceneMode.Additive);
        }

        Random.seed = (int)System.DateTime.Now.Ticks;
        navPath = new NavMeshPath();
        
        //check all start point
        startVecList = new List<Vector3>();
        foreach (Transform item in startPointsList.transform)
        {
            startVecList.Add(item.position);
            item.gameObject.active = false;
        }

        startObject.transform.position = startVecList[Random.Range(0,startVecList.Count)];
        navAgent = startObject.GetComponent<NavMeshAgent>();

        //checl all end point
        endVecList = new List<Vector3>();
        foreach (Transform item in endPointsLists.transform)
        {
            endVecList.Add(item.position);
            item.gameObject.active = false;
        }
        endObject.transform.position = endVecList[Random.Range(0,endVecList.Count)];
        FoundEndPoint = false;
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if(!FoundEndPoint)
        {
            Global.randomAll();
            navSurface.BuildNavMesh();
            
            navAgent.CalculatePath(endObject.transform.position,navPath);
            
            if(navPath.status == NavMeshPathStatus.PathComplete)
            {
                FoundEndPoint = true;
                Debug.Log("Found!!!!");
                
            }else
            {
                Debug.Log("Not found");
            }
        }

        if(debug_automove)
        {
            navAgent.SetPath(navPath);
        }
       
    }
}
