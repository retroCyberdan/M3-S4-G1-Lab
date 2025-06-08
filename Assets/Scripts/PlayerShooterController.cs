using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _fireRange;
    [SerializeField] private Bullet _bulletPrefab;

    private float _nextFireTime = 0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _nextFireTime -= Time.time;
        if (_nextFireTime <= 0f)
        {
            Shoot();
            _nextFireTime = 1f / _fireRate;
        }
    }

    private GameObject FindEnemyNearest()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float startDistance = Mathf.Infinity; // <- setto la distanza minima

        foreach (GameObject enemy in enemies) // <- cerco ogni valore nell'Array di GameObjects "enemies"
        {
            float distance = Vector2.Distance(enemy.transform.position, transform.position); // <- calcolo la distanza tramite il metodo "Distance"
            if (distance < startDistance && distance <= _fireRange)
                if (distance <= _fireRange)
                {
                    startDistance = distance;
                    nearestEnemy = enemy;
                }
        }
        return nearestEnemy;
    }

    private void Shoot()
    {
        GameObject target = FindEnemyNearest(); // <- cerco il target più vicino tramite il metodo creato prima
        if (target == null) return; // <- se non ci sono target nel range, non spara
        else
        {
            Bullet bulletClone = Instantiate(_bulletPrefab, transform.position, _bulletPrefab.transform.rotation); // <- creo un clone del Prefab tramite il metodo "Instantiate" e lo metto in scena
            bulletClone.transform.position = transform.position + Vector3.forward * 1.5f; // <- lo faccio spawnare leggermente avanti al player
            Vector2 bulletDirection = (target.transform.position - transform.position).normalized; // <- creao un Vector2 direzione a cui assegno la differenza tra la posizione del target e la mia (normalizzata)
            Rigidbody2D bulletRb = bulletClone.GetComponent<Rigidbody2D>(); // <- accedo alla componente Rigidbody2D del mio clone

            //bulletRb.AddForce(Vector3.right * 10, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, NON SEGUENDO IL TARGET
            bulletRb.velocity = bulletDirection * 10f; // <- altro modo per muovere il clone, SEGUENDO IL TARGET

            //bulletRb.AddForce(bulletDirection * 10f, ForceMode2D.Impulse); // <- tramite "AddForce()" applico una "schicchera" verso destra, SEGUENDO IL TARGET
        }
    }
}