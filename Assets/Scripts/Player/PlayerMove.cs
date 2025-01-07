using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private Transform GFX;

    private void Awake()
    {
        GFX = transform.GetChild(0);
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * _speedMove * Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GFX.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GFX.localScale = new Vector3(-1, 1, 1);
        }
    }
}
