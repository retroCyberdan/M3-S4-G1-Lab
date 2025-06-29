using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifeSpan = 2f;

    void Start()
    {
        Destroy(gameObject, _lifeSpan); // <- distrugge il Proiettile dopo tot secondi che � stato generato
    }

    // Start is called before the first frame update
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<EnemyAnimator>().TakeDamage();
            //Destroy(collision.gameObject); // <- distrugge il Nemico all'impatto
            Destroy(gameObject); // <- distrugge il Proiettile all'impatto
        }
    }
}
