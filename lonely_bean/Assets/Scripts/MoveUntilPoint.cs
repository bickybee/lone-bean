using UnityEngine;
using System.Collections;

public class MoveUntilPoint : MonoBehaviour {

    private Transform objectTransform;
    private Vector2 startingPoint;
    public float distance;
    public float speed;
    public bool arrived = false;

    public Vector3 direction;

    void Start()
    {
        objectTransform = gameObject.transform;
        startingPoint = new Vector2(objectTransform.position.x, objectTransform.position.y);
        if (objectTransform.localScale.x < 0) direction = -direction;
        if (objectTransform.localScale.y < 0) direction = -direction;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(startingPoint, objectTransform.position) >= distance)
        {
            Destroy(gameObject);
        }
        objectTransform.position += direction * speed * Time.fixedDeltaTime;

        
    }

}
