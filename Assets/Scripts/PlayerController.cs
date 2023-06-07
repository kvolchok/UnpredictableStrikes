using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int MovingForward = Animator.StringToHash("Moving Forward");
    private static readonly int MovingBack = Animator.StringToHash("Moving Back");
    private static readonly int AttackType = Animator.StringToHash("Attack Type");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private Animator _animator;
    private bool _isMovingForward;
    private bool _isMovingBack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _isMovingForward = true;
        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            _isMovingForward = false;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            _isMovingBack = true;
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            _isMovingBack = false;
        }

        _animator.SetBool(MovingForward, _isMovingForward);
        _animator.SetBool(MovingBack, _isMovingBack);
        
        if (Input.GetMouseButtonDown(0))
        {
            MakeAttack();
        }
    }

    private void MakeAttack()
    {
        _animator.SetTrigger(Attack);
        var randomAttack = Random.Range(0, 10);
        _animator.SetInteger(AttackType, randomAttack);
    }
}
