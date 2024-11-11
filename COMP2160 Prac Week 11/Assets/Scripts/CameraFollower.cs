using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Marble; 
    [SerializeField] private Transform Follower; 
    private Vector3 offset;

    private void Start()
    {
        
        offset = Follower.position - Marble.position;
    }

    private void Update()
    {
        
        Follower.position = Marble.position + offset;
    }
}
