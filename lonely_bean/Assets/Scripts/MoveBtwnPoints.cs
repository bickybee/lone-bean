using UnityEngine;
using System.Collections;

public class MoveBtwnPoints : MonoBehaviour {

    public Transform gameObj;
    public Transform startTransform;
    public Transform endTransform;
    public float speed;

    Vector3 direction;
    Transform destination;

    void Start()
    {
        SetDestination(startTransform);
    }

    void FixedUpdate()
    {
        gameObj.position = gameObj.position + direction * speed * Time.fixedDeltaTime;
        if (Vector3.Distance(gameObj.position, destination.position) < speed * Time.fixedDeltaTime)
        {
            SetDestination(destination == startTransform ? endTransform: startTransform);
        }
    }

    void SetDestination(Transform dest)
    {
        destination = dest;
        direction = (destination.position - gameObj.position).normalized;
        if (direction.x > 0)
        {
            gameObj.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObj.localScale = Vector3.one;
        }
    }

}
