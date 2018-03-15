using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(HeroineBow))]
[RequireComponent(typeof(HeroineHealth))]
public class HeroineController : MonoBehaviour
{
    private enum HeroineBehaviour
    {
        Idle,
        Shoot,
        Walk,
        Hit,
        Die
    }

    private readonly int _shootHash = Animator.StringToHash("Shoot");
    private readonly int _walkHash = Animator.StringToHash("Walk");
    private readonly int _hitHash = Animator.StringToHash("Hit");
    private readonly int _dieHash = Animator.StringToHash("Die");

    private Transform _transform;
    private Animator _animator;
    private HeroineBow _bow;
    private HeroineHealth _health;
    private IInputController _inputController;
    private HeroineBehaviour _previousBehaviour;
    private Vector2 _moveDirection;
    private bool _isDead;

    [SerializeField]
    private Transform _aim;
    [SerializeField] 
    [Range(0.1f, 10f)]
    private float _movementSpeed;

	private void Start()
	{
        _transform = transform;
        _animator = GetComponent<Animator>();
        _bow = GetComponent<HeroineBow>();

        _moveDirection = Vector2.zero;
	}

	private void Update()
	{
        Vector2 currentPosition = _transform.position;

        if (_inputController.IsClicked()) {
            Vector2 moveTowards = _inputController.GetPosition();

            _moveDirection = moveTowards - currentPosition;
            _moveDirection.Normalize();
        }

        Vector2 target = _moveDirection + currentPosition;
        _transform.position = Vector2.Lerp(currentPosition, target, _movementSpeed * Time.deltaTime);
	}

    public void Idle()
    {
        SetBehaviour(HeroineBehaviour.Walk);
    }

    public void Walk()
    {
        if (_isDead) {
            return;
        }

        SetBehaviour(HeroineBehaviour.Walk);
    }

    public void Shoot()
    {
        if (_isDead) {
            return;
        }

        if (_bow.Shoot(_aim.position)) {
            SetBehaviour(HeroineBehaviour.Shoot);
        }
    }

    public void Hit()
    {
        if (_isDead) {
            return;
        }

        if (_health.Hit()) {
            SetBehaviour(HeroineBehaviour.Hit);
        }
        else {
            SetBehaviour(HeroineBehaviour.Die);
        }
    }

    private void SetBehaviour(HeroineBehaviour nextBehaviour)
    {
        switch (nextBehaviour) {
            case HeroineBehaviour.Idle:
                if (_previousBehaviour == HeroineBehaviour.Walk) {
                    _animator.SetBool(_walkHash, false);
                }
                else if (_previousBehaviour == HeroineBehaviour.Die) {
                    _animator.SetBool(_dieHash, false);
                    _isDead = false;
                }

                break;
            case HeroineBehaviour.Shoot:
                _animator.SetTrigger(_shootHash);
                nextBehaviour = HeroineBehaviour.Idle;

                break;
            case HeroineBehaviour.Walk:
                _animator.SetBool(_walkHash, true);

                break;
            case HeroineBehaviour.Hit:
                _animator.SetTrigger(_hitHash);
                nextBehaviour = HeroineBehaviour.Idle;

                break;
            case HeroineBehaviour.Die:
                _animator.SetBool(_dieHash, true);
                _isDead = true;

                break;
        }

        _previousBehaviour = nextBehaviour;
    }
}