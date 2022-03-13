using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int curMoney;
    public Text moneyText;
    public GameObject moneyManager;

    // Start is called before the first frame update
    void Start()
    {
        moneyManager = GameObject.FindGameObjectWithTag("MoneyManager");
        moneyText = moneyManager.GetComponent<Text>();
    }
    public void AddjustMoney(int gains)
    {
        curMoney += gains;
        moneyText.text = "Money: " + curMoney.ToString();
    }
}
