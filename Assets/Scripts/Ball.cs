using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] float _speedBounce;
    [SerializeField] float _speedBounceJump;
    [SerializeField] PlayerControls _playerControls;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerControls>())
        {
            Vector2 vectorAtract = collision.contacts[0].normal;
            Debug.Log(vectorAtract);
            if(_playerControls._isGrounded)
            {
                _rigidbody2D.AddForce(vectorAtract * _speedBounce, ForceMode2D.Impulse);
            }
            else
            {
                _rigidbody2D.AddForce(vectorAtract * _speedBounceJump, ForceMode2D.Impulse);
            }
            
        }
    }
}
