using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeSpan = 2f;
    [SerializeField] private AudioClip _deathClipSFX;
    AudioSource _deathSFX;

    private void Awake()
    {
        _deathSFX = GetComponent<AudioSource>(); // <- riferimento alla componente AudioSource
    }

    void Start()
    {
        Destroy(gameObject, _lifeSpan); // <- distrugge il Proiettile dopo tot secondi che è stato generato
    }

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); // <- distrugge il Nemico all'impatto
            Destroy(gameObject); // <- distrugge il Proiettile all'impatto
            _deathSFX.clip = _deathClipSFX; // <- riproduco la clip audio per la morte
            _deathSFX.Play();
        }
    }
}
