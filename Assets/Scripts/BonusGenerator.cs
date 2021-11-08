using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] _greenBarrier;
    [SerializeField] private TextMeshProUGUI[] _redBarrier;

    //List<Symbol> symbols = new List<Symbol>();
    private string _randomSymbol;
    private int _rDigital;
    private string[] _rSymbol = {"+", "-", "*", "/"};
    //private void BonusGenerate()
    //{
    //    for (int i = 0; i < _greenBarrier.Length; i++)
    //    {
    //        //_rDigital = Random.Range(1, 10);
    //        //_randomSymbol = _rSymbol[Random.Range(0, _rSymbol.Length)];
    //        //Debug.Log(_rDigital);
    //        //Debug.Log(_greenBarrier[i].name);
    //        //_greenBarrier[i].text = _rDigital.ToString();

    //        Symbol symbol = symbols[Random.Range(0, symbols.Count)];
    //        _greenBarrier[i].text = symbol.symbolText;
    //    }
    //    for (int g = 0; g < _redBarrier.Length; g++)
    //    {
    //        _rDigital = Random.Range(1, 10);
    //        Debug.Log(_rDigital);
    //        _redBarrier[g].text = _rDigital.ToString();
    //    }
    }
    //private void Start()
    //{
    //    BonusGenerate();
    //    //symbols.Add(new Symbol { symbol = '+', symbolText = "+" });
    //    //symbols.Add(new Symbol { symbol = '-', symbolText = "-" });
    //    //symbols.Add(new Symbol { symbol = '*', symbolText = "*" });
    //    //symbols.Add(new Symbol { symbol = '/', symbolText = "/" });
    //}
    //private class Symbol
    //{

    //    public char symbol;

    //    public string symbolText;

    //}

