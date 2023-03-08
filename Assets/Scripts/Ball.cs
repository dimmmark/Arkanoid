using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] float _speedBounce;
    [SerializeField] float _speedBounceJump;
    [SerializeField] float _friction;
    [SerializeField] PlayerControls _playerControls;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] Game game;
    public static event Action OnCollidedDot;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 vectorAtract = collision.contacts[0].normal;

        if (collision.gameObject.GetComponent<PlayerControls>())
        {
            _soundManager.Play("kickJump");
            _rigidbody2D.AddForce(vectorAtract * (_playerControls._isGrounded? _speedBounce : _speedBounceJump),
                ForceMode2D.Impulse);
            
        }
        else if(collision.gameObject.GetComponent<Dot>())
        {
            _soundManager.Play("hit");
            _rigidbody2D.AddForce(vectorAtract * _speedBounceJump, ForceMode2D.Impulse);
            OnCollidedDot?.Invoke();
        }
        else if(collision.gameObject.GetComponent<Floor>())
        {
            game.RestartLevel();
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.GetComponent<DotBig>())
        {
            _soundManager.Play("hitBig");
            _rigidbody2D.AddForce(vectorAtract * _speedBounceJump, ForceMode2D.Impulse);
        }
        else
            _soundManager.Play("hitWall");
    }
    
}
