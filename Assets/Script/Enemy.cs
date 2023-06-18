using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject finish;
    public float distance;

    public NavMeshAgent _agent;
    
    private void Start() 
    {
        finish = GameObject.Find("Finish");
    }

    void Update()
    {
        distance = Vector3.Distance(finish.transform.position, this.transform.position);
        _agent.SetDestination(finish.transform.position);
    }
}
