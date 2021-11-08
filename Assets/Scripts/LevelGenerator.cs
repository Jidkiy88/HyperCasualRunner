using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _tiles;
    [SerializeField] private GameObject _player;

    private float _spawnPos = 0;
    private float _tileLength = 35;

    private void SpawnTile(int tileIndex)
    {
        Instantiate(_tiles[tileIndex], transform.forward * _spawnPos, transform.rotation);
        _spawnPos += _tileLength;
    }
    private void Start()
    {
        for (int i = 0; i < _tiles.Length; i++)
        {
            SpawnTile(i);

            if (_tiles[i].GetComponent<FinalTile>() != null)
            {
                _tiles[i].GetComponent<FinalTile>().GuardManager._player = _player;
            }
        }
    }
}
