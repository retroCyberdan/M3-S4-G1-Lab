using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _anim;
    private PlayerController _playerController;
    private Bullet _bullet;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _playerController = GetComponent<PlayerController>();
        _bullet = GetComponent<Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController.dir != Vector2.zero)
        {
            _anim.SetFloat("hDir", _playerController.h);
            _anim.SetFloat("vDir", _playerController.v);
        }

        
    }
}
