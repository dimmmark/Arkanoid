using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D _rigitbody2D;
    [SerializeField] float _speed;
    [SerializeField] float _jumpSpeed;
    [SerializeField] float _friction;
    public bool _isGrounded;
    [SerializeField] bool _isMoving;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] Animator _animator;
    Vector3 _previosMousePosition;
    float _timer;
    void Start()
    {
        _rigitbody2D = GetComponent<Rigidbody2D>();
        _previosMousePosition = Input.mousePosition;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isGrounded)
        {
            _rigitbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            _animator.CrossFade("Jump Animation", 0.01f);
            _soundManager.Play("jump");
        }
        _timer += Time.deltaTime;
        if (_timer > 0.2f)
        {
            Vector3 _currentPosition = Input.mousePosition;
            if (_previosMousePosition != _currentPosition)
            {
                _animator.CrossFade("Run Animation", 0.01f);
                _soundManager.Play("step");
            }
            else
            {
                _animator.CrossFade("Idle Animation", .01f);
            }
            _previosMousePosition = _currentPosition;
            _timer = 0;
        }
    }
    private void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float targetPosotion = Mathf.Clamp(mousePos.x, -11f, 12f);
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