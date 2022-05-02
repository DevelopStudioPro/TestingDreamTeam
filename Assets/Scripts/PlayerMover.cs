using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameObject _Shield;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;


    private Vector2 _moveDirection;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        _animator.SetTrigger("Attack");
        OnBlockDisable();
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        _Shield.SetActive(true);
    }
    public void OnBlockDisable()
    {
        _Shield.SetActive(false);
    }

    private void Move(Vector2 direction)
    {
        float scaleMovieSpeed = _speed * Time.deltaTime;

        Vector3 moveDirection = new Vector3(direction.x, 0, direction.y);
        _animator.SetFloat("Speed", Vector3.ClampMagnitude(moveDirection, 1).magnitude);
        transform.position += moveDirection * scaleMovieSpeed;
        if(direction.magnitude>Mathf.Abs(0.05f))
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(moveDirection), _speedRotation * Time.deltaTime);
    }

    private void Update()
    {
        Move(_moveDirection);
    }
}
