using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BarrierSettings : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _barrierText;

    public List<SymbolGreen> symbolsGreen = new List<SymbolGreen>();
    public List<SymbolRed> symbolsRed = new List<SymbolRed>();

    public SymbolGreen symbolGreen;
    public SymbolRed symbolRed;

    public int _rDigital;
    public int test = 2;

    public void Generate()
    {
        _rDigital = Random.Range(1, 10);
        if (gameObject.tag == "GreenFrame")
        {
            symbolGreen = symbolsGreen[Random.Range(0, symbolsGreen.Count)];
            _barrierText.text = symbolGreen.symbolText + _rDigital.ToString();
        }
        if (gameObject.tag == "RedFrame")
        {
            symbolRed = symbolsRed[Random.Range(0, symbolsRed.Count)];
            _barrierText.text = symbolRed.symbolText + _rDigital.ToString();
        }
    }
    public class SymbolGreen
    {
        public char symbol;
        public string symbolText;
    }
    public void Start()
    {
        symbolsGreen.Add(new SymbolGreen { symbol = '+', symbolText = "+" });
        symbolsRed.Add(new SymbolRed { symbol = '-', symbolText = "-" });
        symbolsGreen.Add(new SymbolGreen { symbol = '*', symbolText = "*" });
        symbolsRed.Add(new SymbolRed { symbol = '/', symbolText = "/" });
        Generate();
    }
    public class SymbolRed
    {
        public char symbol;
        public string symbolText;
    }
}
