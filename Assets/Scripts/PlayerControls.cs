using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D _rigitbody2D;
    [SerializeField] float _speed;
    [SerializeField] float _jumpSpeed;
    [SerializeField] float _friction;
    public bool _isGrounded;
    void Start()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && _isGrounded )
        {
            _rigitbody2D.velocity = Vector2.up * _jumpSpeed;
        }
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mousePosX = new Vector2(mousePos.x, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, mousePosX, _speed);
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        _isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGrounded = false;    
    }
}
