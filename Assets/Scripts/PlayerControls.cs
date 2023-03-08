using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
       
       
    }
    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosX = new Vector2(mousePos.x, transform.position.y);
        //transform.position = Vector2.Lerp(transform.position, mousePosX, _speed);
        Vector2 direction = (mousePosX - (Vector2)transform.position);
        var directionClamped =(Mathf.Clamp(direction.x, -3, 3));
        _rigitbody2D.AddForce(Vector2.right * directionClamped * _speed);
       // _rigitbody2D.MovePosition((Vector2)transform.position + direction * _speed * Time.deltaTime);
        Debug.Log(directionClamped);
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
