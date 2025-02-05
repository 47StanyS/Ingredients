using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    [SerializeField] private RectTransform _safeZone;

    [SerializeField] private float _moveSpeed;

    private RectTransform _pointerTransform;
    private Vector3 _targetPosition;

    private int _attempsLeft;
    private int _successCount;

    private GameController _gameController;
    private IngredientsSpawner _ingredientsSpawner;

    private void Start()
    {
        _gameController = GameController.instance;
        _ingredientsSpawner = IngredientsSpawner.Instance;
        _pointerTransform = GetComponent<RectTransform>();
        _targetPosition = _pointB.position;
    }
    private void Update()
    {
        _pointerTransform.position = Vector3.MoveTowards(_pointerTransform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        if (Vector3.Distance(_pointerTransform.position, _pointA.position) < 0.1f)
        {
            _targetPosition = _pointB.position;

        }else if(Vector3.Distance(_pointerTransform.position,_pointB.position) < 0.1f)
        {
            _targetPosition = _pointA.position;

        }

        if (Input.GetMouseButtonDown(0))
        {
            CeckSuccess();
        }

    }

    private void CeckSuccess()
    {
        if(RectTransformUtility.RectangleContainsScreenPoint(_safeZone, _pointerTransform.position, null))
        {
            _successCount++;
            Debug.Log("Seccess");
            MoveRandomY();
            SizeRandomY();
            _moveSpeed = Random.Range(500,1500);
        }
        else
        {
            _attempsLeft--;
            Debug.Log("Fail");
            MoveRandomY();
            SizeRandomY();
            _moveSpeed = Random.Range(500,1500);
        }

        if(_successCount == 3)
        {
            _gameController._cookingScreen.SetActive(false);
            _ingredientsSpawner._canSpawn = true;

            _ingredientsSpawner.NextDifficultyLevel();
        }

    }
    private void MoveRandomY()
    {
        float randomY = Random.Range(240, -280);
        _safeZone.anchoredPosition = new Vector2(_safeZone.anchoredPosition.x, randomY);
    }
    private void SizeRandomY()
    {
        float _randomY = Random.Range(50f, 150f);
        _safeZone.sizeDelta = new Vector2(_safeZone.sizeDelta.x, _randomY);
    }

}
