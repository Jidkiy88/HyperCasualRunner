using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] public float _speed;
    [SerializeField] public float _controlSpeed;
    [SerializeField] private TextMeshProUGUI _coins;
    [SerializeField] private GameObject _canvasCore;
    [SerializeField] private GameObject _canvasEndGame;
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _winOrLose;
    [SerializeField] private GameObject _guard;

    BarrierSettings barrierSettingsScript;
    GuardManager guardManager;

    private Animator _anim;
    private bool _isTouching;
    private float _touchPosX;
    private int _coinsValue = 0;
    private string _test;
    private int _challengeValue;
    public bool playerAlive = true;

    private void OnMouseDown()
    {
        _isTouching = true;
    }
    private void OnMouseUp()
    {
        _isTouching = false;
    }
    private void ForwardMove()
    {
        _player.transform.position += Vector3.forward * _speed * Time.fixedDeltaTime;
    }
    private void FixedUpdate()
    {
        ForwardMove();
        SideMove();
        HitEndManager();
        HitManager();
        CoinManager();
    }
    private void SideMove()
    {
        if (_isTouching == true)
        {
            _touchPosX += Input.GetAxis("Mouse X") * _controlSpeed * Time.fixedDeltaTime;
        }
        _player.transform.position = new Vector3(_touchPosX, _player.transform.position.y, _player.transform.position.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DeathTrigger")
        {
            _winOrLose.text = ("You lose").ToString();
            GameOver();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GreenFrame")
        {
            if (other.GetComponent<BarrierSettings>().symbolGreen.symbol == '*')
            {
                _coinsValue = _coinsValue * other.GetComponent<BarrierSettings>()._rDigital;
            }
            else
            {
                _coinsValue = _coinsValue + other.GetComponent<BarrierSettings>()._rDigital;
            }
        }
        if (other.gameObject.tag == "RedFrame")
        {
            if (other.GetComponent<BarrierSettings>().symbolRed.symbol == '/')
            {
                _coinsValue = _coinsValue / other.GetComponent<BarrierSettings>()._rDigital;
            }
            else
            {
                _coinsValue = _coinsValue - other.GetComponent<BarrierSettings>()._rDigital;
            }
        }
        if (other.gameObject.tag == "Coin")
        {
            _coinsValue++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "EndGameTrigger")
        {
            _guard = other.GetComponent<ChallengeGenerator>()._giant;
            ScoreUpdate();
            _speed = 0;
            _controlSpeed = 0;
            _anim.SetBool("Run", false);
            _anim.SetBool("Stand", true);
            ChallengeGenerator challengeGenerator = other.GetComponentInChildren<ChallengeGenerator>();
            GuardManager guardManager = other.GetComponentInChildren<GuardManager>();
            _guard.GetComponent<GuardManager>().playerPosX = gameObject.transform.position.x;
            _guard.GetComponent<GuardManager>().playerPosZ = gameObject.transform.position.z + 4f;
            if (_coinsValue >= challengeGenerator.challengeRandom)
            {
                _winOrLose.text = ("You win").ToString();
                _guard.GetComponent<GuardManager>().StartWin();
                StartCoroutine(VictoryEnder());
            }
            if (_coinsValue < challengeGenerator.challengeRandom)
            {
                _guard.GetComponent<GuardManager>().StartLose();
                _winOrLose.text = ("You lose").ToString();
            }
            
        }
    }
    private void ScoreUpdate()
    {
        _score.text = string.Format("Your score: {0}", _coinsValue);
    }
    private void Start()
    {
        _anim = GetComponent<Animator>();
        barrierSettingsScript = GetComponent<BarrierSettings>();
        guardManager = GetComponent<GuardManager>();
        _speed = 0;
        _controlSpeed = 0;
    }
    private void GameOver()
    {
        ScoreUpdate();
        _canvasCore.SetActive(false);
        _canvasEndGame.SetActive(true);
        Time.timeScale = 0;
    }
    private void HitManager()
    {
        if (GuardManager.playerHit == true)
        {
            StartCoroutine(HitAndDestroy());
            GuardManager.playerHit = false;
        }
    }
    private IEnumerator HitAndDestroy()
    {
        yield return new WaitForSeconds(1f);
        _anim.SetBool("Stand", false);
        _anim.SetTrigger("Hit");
        yield return new WaitForSeconds(1f);
        playerAlive = false;
        _player.gameObject.transform.position = new Vector3(0f, 0f, 0f);
        yield return new WaitForSeconds(5f);
        GameOver();
        yield break;
    }
    private void HitEndManager()
    {
        if (GuardManager.endgame == true)
        {
            Debug.LogWarning("EndGame");
            GameOver();
        }
    }
    private IEnumerator VictoryEnder()
    {
        yield return new WaitForSeconds(3f);
        _anim.SetTrigger("Dance");
        yield return new WaitForSeconds(5f);
        GameOver();
    }
    private void CoinManager()
    {
        if (_coinsValue < 0)
        {
            _coinsValue = 0;
        }
        _coins.text = _coinsValue.ToString();
    }
}
