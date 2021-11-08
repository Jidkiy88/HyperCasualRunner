using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardManager : MonoBehaviour
{
    [SerializeField] private GameObject _NPC;
    [SerializeField] public GameObject _player;

    private Animator _anim;

    public static bool endgame = false;
    public bool _timeToGo = false;
    public float playerPosX;
    public float playerPosZ;
    public bool closeToPlayer = false;
    public static bool playerHit = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public IEnumerator PlayerWin()
    {
        yield return new WaitForSeconds(2f);
        _anim.SetBool("Standing", false);
        _anim.SetTrigger("Death");
        yield return new WaitForSeconds(5f);
        Destroy(_NPC.gameObject);
        yield break;
    }
    public IEnumerator PlayerLose()
    {
        _anim.SetBool("Standing", false);
        _anim.SetBool("Walking", true);
        while (closeToPlayer != true)
        {
            _NPC.gameObject.transform.position = Vector3.MoveTowards(_NPC.gameObject.transform.position, new Vector3(playerPosX, _NPC.gameObject.transform.position.y, playerPosZ), 1f);
            yield return new WaitForSeconds(0.1f);
        }
        PlayerLoseContinuator();
        yield break;
    }
    public void StartLose()
    {
        StartCoroutine(PlayerLose());
    }
    public void StartWin()
    {
        StartCoroutine(PlayerWin());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            closeToPlayer = true;
            Debug.LogWarning("Close");
        }
    }
    private void PlayerLoseContinuator()
    {
        _anim.SetBool("Walking", false);
        _anim.SetTrigger("Punch");
        playerHit = true;
        _anim.SetBool("Dance", true);
        StartCoroutine(EndGameAfterPunch());

    }
    private void GameEnder()
    {
        endgame = true;
    }
    private IEnumerator EndGameAfterPunch()
    {
        yield return new WaitForSeconds(8f);
        GameEnder();
        yield break;
    }
}
