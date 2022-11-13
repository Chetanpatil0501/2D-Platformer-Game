using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_area : MonoBehaviour
{
    private Enemy_behaviour Enemy_parent;
    [SerializeField] private float damage = 1;

    private void Awake()
    {
        Enemy_parent = GetComponentInParent<Enemy_behaviour>();
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Enemy_parent.target = collision.transform;
            Enemy_parent.inRange = true;
            Enemy_parent.HotZone.SetActive(true);

            collision.GetComponent<Health>().TakeDamage(damage);

        }
    } 
}
