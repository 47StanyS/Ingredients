using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator _animator;
    public GameObject _button;

    private bool _pressed = false;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        if (_pressed) 
        {
            _pressed = false;
            _animator.Play("CloseOptionWindow");
        }
        else 
        {
            _pressed = true;
            _animator.Play("OpenOptionWindow");
        }
    }
}
