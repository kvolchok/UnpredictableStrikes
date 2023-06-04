using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int MovingForward = Animator.StringToHash("Moving Forward");
    private static readonly int MovingBack = Animator.StringToHash("Moving Back");
    private static readonly int KickAttack = Animator.StringToHash("Kick Attack");
    private static readonly int BowAttack = Animator.StringToHash("Bow Attack");

    private readonly List<int> _attacks = new();
    
    private Animator _animator;
    private bool _isMovingForward;
    private bool _isMovingBack;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _attacks.Add(KickAttack);
        _attacks.Add(BowAttack);
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
            Attack();
        }
    }

    private void Attack()
    {
        var randomAttackIndex = Random.Range(0, _attacks.Count);
        var randomAttack = _attacks[randomAttackIndex];
        _animator.SetTrigger(randomAttack);
    }
}
