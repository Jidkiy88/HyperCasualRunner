using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChallengeGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _challengeText;
    [SerializeField] public GameObject _giant;
    public int challengeRandom;

    private void Start()
    {
        challengeRandom = Random.Range(25,30);
        _challengeText.text = challengeRandom.ToString();
    }
}
