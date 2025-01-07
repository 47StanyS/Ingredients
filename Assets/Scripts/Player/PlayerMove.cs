using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Vector3 _position;
    private Transform _spriteTransform;

    private void FixedUpdate()
    {
        _position = transform.position;

        if (Input.GetKeyUp(KeyCode.D))
        {
            _position.x += _speedMove;
            _spriteTransform.localScale = new Vector3(1,1,1);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _position.x -= _speedMove;
            _spriteTransform.localScale = new Vector3(-1, 1, 1);
        }
        transform.position = _position;
    }
}
