using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazierFollow : MonoBehaviour
{
    [SerializeField]
    private Transform[] route;

    private int RouteToGo;

    private float tParam;

    private Vector2 CatPos;


    private float speed;

    private bool coroutineAllowed;

    public GameObject mother;
    // Start is called before the first frame update
    void Start()
    {
        RouteToGo = 0;
        tParam = 0;
        speed = 2;
        coroutineAllowed = true;

        for (int i = 0; i < Cat_Jump.ins.stored.Count;i++)
        {
            var ina = Instantiate(mother, new Vector3(mother.transform.position.x + 250 * i,mother.transform.position.y,mother.transform.position.z),Quaternion.identity);
            mother.transform.GetChild(0).position = gameObject.transform.position;
            mother.transform.GetChild(3).position = Cat_Jump.ins.stored[i + 1].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(coroutineAllowed)
        {
            StartCoroutine(GoByRoute(RouteToGo));
        }
    }

    IEnumerator GoByRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector2 p0 = route[routeNumber].GetChild(0).position, p1 = route[routeNumber].GetChild(1).position, 
            p2 = route[routeNumber].GetChild(2).position, p3 = route[routeNumber].GetChild(3).position;

        while (tParam<1)
        {
            tParam += Time.deltaTime * speed;
            CatPos = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            transform.position = CatPos;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0;
        RouteToGo += 1;
        if(RouteToGo > route.Length - 1)
        {
            RouteToGo = 0;
        }
        coroutineAllowed = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Balloon")
        {
            Cat_Jump.ins.ind++;
        }
    }
}
