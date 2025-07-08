using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshController : MonoBehaviour
{
    //[SerializeField]
    public NavMeshSurface surface;

    // Start is called before the first frame update
    void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        Debug.Log(surface);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RebuildNavMesh()
    {
        surface.BuildNavMesh();
    }
}
