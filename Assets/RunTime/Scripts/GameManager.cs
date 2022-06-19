using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinValue;
    private int coinsCollected;


    private void Awake()
    {
        if (this != null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coinValue.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumCoins()
    {
        coinsCollected += 1;
        coinValue.text = " " + coinsCollected;
    }
    
}
