using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private List<GameObject> _players;
    [SerializeField] private Button _swithButton;

    public int _coins;

    [SerializeField] private int _minusCoin = 5;

    [SerializeField] private TMP_Text _coinsText;

    private int _currentIndex = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

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

    public void CollectCoinPlus()
    {
        _coins++;
        _coinsText.text = _coins.ToString();
    }
    public void CollectCoinMinus()
    {
        _coins = _coins - _minusCoin;
        _coinsText.text = _coins.ToString();
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
