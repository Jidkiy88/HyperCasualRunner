using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParametrs : MonoBehaviour
{
    [SerializeField] private GameObject _canvasCore;
    [SerializeField] private GameObject _canvasStartGame;
    [SerializeField] private GameObject _canvasEndGame;
    [SerializeField] private GameObject _player;

    MoveForward moveForward;
    private void Start()
    {
        moveForward = _player.GetComponent<MoveForward>();
        moveForward._speed = 0;
        moveForward._controlSpeed = 0;
        _canvasCore.SetActive(false);
        _canvasStartGame.SetActive(true);
        _canvasEndGame.SetActive(false);
    }
}
