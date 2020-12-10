using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "R$" + PlayerStatus.Money.ToString();
    }
}
