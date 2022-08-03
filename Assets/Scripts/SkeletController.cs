using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    public int _skeletHealth = 2;
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
        if (collision.gameObject.GetComponent<KnightController>())
        {
            _isFight = true;
            _animator.SetTrigger("Damage");
            collision.gameObject.GetComponent<KnightController>().IsDamage();
            Invoke("NotFight", 0.5f);
        }
    }

    private void NotFight()
    {
        _isFight = false;
    }
    public void IsDamage()
    {
        if (_skeletHealth > 1)
        {
            _skeletHealth--;
        }
        else
        {
            Destroy(gameObject, 0.5f);
            GameObject _displayController = GameObject.Find("DisplayController");
            _displayController.GetComponent<DisplayController>().AddScores(5);
        }
    }
}
