using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpUIManager : MonoBehaviour
{
    [SerializeField] private Transform powerup_panels;
    private TMP_Text[] powerUpText;

    void Start()
    {
        powerUpText = new TMP_Text[3];

        for (int i = 0; i < powerUpText.Length; i++)
        {
            Transform child = powerup_panels.Find("powerup" + i);
            powerUpText[i] = child.GetComponentInChildren<TMP_Text>();
            powerUpText[i].text = "";
        }
                
    }

    public void UpdatePowerUps(int _index, string _name)
    {
        powerUpText[_index].text = _name;
    }
}
