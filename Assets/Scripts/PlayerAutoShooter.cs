using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoShooter : MonoBehaviour
{
    [SerializeField] private float _fireRate = 1f;
    [SerializeField] private float _fireRange = 5f;
    [SerializeField] private Bullet _bulletPrefab;

    private float _nextFireTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        _nextFireTime -= Time.deltaTime;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;

        float startDistance = 0f;

        foreach (var enemy in enemies)
        {
            if (enemy.CompareTag("Enemy") && _nextFireTime <= 0f)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position); // <- calcolo la distanza tramite il metodo "Distance"
                if (distance < startDistance && distance <= _fireRange)
                    startDistance = distance;
                nearestEnemy = enemy; 
                
                Vector2 bulletDirection = (enemy.transform.position - transform.position).normalized;
                Bullet bulletClone = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation);
                Rigidbody2D bulletRb = bulletClone.GetComponent<Rigidbody2D>(); // <- accedo alla componente Rigidbody2D del mio clone

                //bulletRb.AddForce(Vector3.right * 10, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, NON SEGUENDO IL TARGET
                bulletRb.velocity = bulletDirection * 10f; // <- altro modo per muovere il clone, SEGUENDO IL TARGET

                //bulletRb.AddForce(bulletDirection * 10f, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, SEGUENDO IL TARGET

                _nextFireTime = 1f / _fireRate;
                break;
            }
        }
    }
}
