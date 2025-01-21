using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator _animator;
    public GameObject _button;
    private void Awake()
    {

        //_animator = GetComponent<Animator>();

    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("IdleOptionWindow");
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        _animator.Play("OpenOptionWindow");
    }
}
