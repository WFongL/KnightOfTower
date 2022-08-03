using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    public int _knightHealth = 1;
    public float _speed = 0.8f;
    private bool _isFight = false;

    private void Start()
    {
        _animator.SetBool("Run", true);
    }

    private void OnAnimatorMove()
    {
        if (!_isFight)
        {
            _rigidbody.MovePosition(_rigidbody.position + transform.forward * _speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<SkeletController>())
        {
            _isFight = true;
            _animator.SetTrigger("Damage");
            collision.gameObject.GetComponent<SkeletController>().IsDamage();
            Invoke("NotFight", 0.5f);
        }
    }

    private void NotFight()
    {
        _isFight = false;
    }
    public void IsDamage()
    {
        if (_knightHealth > 1)
        {
            _knightHealth--;
        }
        else
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
