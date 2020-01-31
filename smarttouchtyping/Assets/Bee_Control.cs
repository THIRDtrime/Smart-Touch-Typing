using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bee_Control : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    private void LateUpdate()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            var go = gameObject.transform.GetChild(i);
            go.transform.rotation = Quaternion.Euler(0,180,0);
            go.transform.position = Vector3.Lerp(go.transform.position,new Vector3(go.transform.position.x + 3 * Random.Range(-1, 2), go.transform.position.y + 3 * Random.Range(-1,2),go.transform.position.z + 3 * Random.Range(-1, 2)),Time.deltaTime);
        }
    }
}
