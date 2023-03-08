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
    [SerializeField] SoundManager _soundManager;
    void Start()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGrounded)
        {
            _rigitbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float targetPosotion = Mathf.Clamp(mousePos.x, -12f, 13f);
        Vector2 targetPosition = new Vector2(targetPosotion, transform.position.y);
       transform.position = Vector2.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
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
