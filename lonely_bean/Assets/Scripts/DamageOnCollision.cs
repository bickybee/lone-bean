using UnityEngine;
using System.Collections;

public class DamageOnCollision : MonoBehaviour
{

    public float damageAmount;
    public bool destroyOnCollision;
    public float backlashX;
    public float backlashY;

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (col.CompareTag("Player"))
        {
            player.SendMessage("ApplyDamage", damageAmount);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(backlashX, backlashY), ForceMode2D.Impulse);
        }
        if (destroyOnCollision)
        {
            Destroy(gameObject);
        }
    }
}
