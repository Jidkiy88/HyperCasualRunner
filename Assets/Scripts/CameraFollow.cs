using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    MoveForward playerScript;

    private void Update()
    {
        if (playerScript.playerAlive == true)
        {;
            gameObject.transform.position = new Vector3(_player.transform.position.x, gameObject.transform.position.y, _player.transform.position.z - 15);
        }
    }
    private void Start()
    {
        playerScript = _player.GetComponent<MoveForward>();
    }
}
