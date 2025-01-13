using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundManager : MonoBehaviour
{
    [Header("Height")]
    [SerializeField] private float _targetHeight;
    [SerializeField] private float _heightUpStep;
    [SerializeField] private float _heightDownStep;
    [SerializeField] private float _heightSpeed;
    [SerializeField] private float _loseHight;
    private float startY;


    public static GroundManager Instance;

    private void Awake()
    {
        Instance = this;

        startY = transform.position.y;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y = _targetHeight;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _heightSpeed);
    }

    public void NextStep()
    {
        _targetHeight += _heightUpStep;

        _targetHeight = Mathf.Clamp(_targetHeight, startY, _loseHight);

        if (transform.position.y >= _loseHight) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ReciepeCrafted() 
    {
        _targetHeight -= _heightDownStep;

        _targetHeight = Mathf.Clamp(_targetHeight, startY, _loseHight);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trash")) 
        {
            Destroy(collision.gameObject);
            NextStep();
        }

        if (collision.gameObject.CompareTag("Vegetable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
