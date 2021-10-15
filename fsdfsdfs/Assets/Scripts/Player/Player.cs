using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = System.Diagnostics.Debug;

public class Player : MonoBehaviour
{
    private RaycastHit _hit;
    private Ray _ray;
    float _speed = 2f; 
    bool _isMoving;
    public bool canMove = true;
    private Vector3 _direction;
    
    // References
    [FormerlySerializedAs("_animator")] [SerializeField] private Animator animator;
    [FormerlySerializedAs("_rigidbody")] [SerializeField] private new Rigidbody rigidbody;
    
    // Hash of animator parameters
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Vertical = Animator.StringToHash("Vertical");
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private void FixedUpdate()
    {
        CheckPosition(_hit.point);
        Move();
        
        if (!Input.GetMouseButton(0)) return;
        if (!canMove) return;
        
        // Say that Main Camera != null
        Debug.Assert(Camera.main != null, "Camera.main != null");
            
        // Throw ray and write raycast hit in _hit field
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(_ray, out _hit, 1000);

        // Calculate direction
        var position = transform.position;
        _direction.x = (_hit.point - position).x;
        _direction.z = (_hit.point - position).z;
            
        // If raycast hit Ground move character
        if (_hit.transform != null && _hit.transform.gameObject.CompareTag("Ground"))
        {
            _isMoving = true;
        }

    }

    private void Move()
    {
        if (!canMove)
            return;
        
        if (_isMoving)
        {
            rigidbody.velocity = _direction * _speed;
            animator.SetFloat(Speed, _speed);
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
            animator.SetFloat(Speed, 0f);
        }
        animator.SetFloat(Vertical, rigidbody.velocity.z / 100);
        animator.SetFloat(Horizontal, rigidbody.velocity.x / 100);
    }

    private void CheckPosition(Vector3 hitPosition)
    {
        if (transform.position.x > hitPosition.x - .2 && transform.position.x < hitPosition.x + .2)  
        {
            _isMoving = false;
        }
    }

    public void ChangeAnimatorController(AnimatorController newAnimator)
    {
        animator.runtimeAnimatorController = newAnimator;
    }
}