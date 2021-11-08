using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _canvasCore;
    [SerializeField] private GameObject _canvasStartGame;
    [SerializeField] private GameObject _player;

    private Animator _animator;
    MoveForward moveForward;

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
        moveForward._speed = 15;
        moveForward._controlSpeed = 30;
        _canvasStartGame.SetActive(false);
        _canvasCore.SetActive(true);
        _animator.SetBool("Run", true);
    }
    private void Start()
    {
        _animator = _player.GetComponent<Animator>();
        moveForward = _player.GetComponent<MoveForward>();
    }
}
