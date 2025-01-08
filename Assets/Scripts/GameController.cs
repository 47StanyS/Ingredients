using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _players;
    [SerializeField] private Button _swithButton;

    public int _coins;

    private int _currentIndex = 0;

    private void Start()
    {
        if (_players.Count > 0)
        {
            SetActivePlayer();
        }
        if (_swithButton != null)
        {
            _swithButton.onClick.AddListener(SwitchPlayer);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            SwitchPlayer();
        }
    }

    private void SwitchPlayer()
    {
        if (_players.Count == 0) return;

        Vector3 CurrentPosition = _players[_currentIndex].transform.position;

        _players[_currentIndex].SetActive(false);

        _currentIndex = (_currentIndex + 1) % _players.Count;

        _players[_currentIndex].transform.position = CurrentPosition;

        SetActivePlayer();
    }
    private void SetActivePlayer()
    {
        _players[_currentIndex].SetActive(true);
    }
}
