using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform clone;

    [SerializeField] private float followSpeed = 5f;
    
    private List<Vector3> trailPositions = new List<Vector3>();


    void Start()
    {
        StartCoroutine(RecordTrail());
    }


    
    IEnumerator RecordTrail()
    {
        while (true)
        {
            
            trailPositions.Add(player.position);

            
            yield return new WaitForSeconds(0.1f);
        }
    }


    void Update()
    {

            
            Vector3 targetPos = trailPositions[0];

            
            
            clone.position = Vector3.MoveTowards(clone.position, targetPos, followSpeed * Time.deltaTime);

            
            if (Vector3.Distance(clone.position, targetPos) < 0.05f)
            {
                
                trailPositions.RemoveAt(0);
            }
        
    }
}
