using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    public int money;
    private Health healthScript;

    void Awake()
    {
        healthScript = this.GetComponentInChildren<Health>();
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            var maxHealing = (int)(healthScript.maxHealth - healthScript.health);
            if (money >= maxHealing)
            {
                money -= maxHealing;
                healthScript.FillHealth(maxHealing);
            }
            else
            {
                var healing = money;
                money = 0;
                healthScript.FillHealth(healing);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != Tags.coin) { return; }

        var coinInfo = other.GetComponent<CoinInfo>();
        if (coinInfo == null) { return; }
        if (coinInfo.value > 0)
        {
            if (this.money >= int.MaxValue - coinInfo.value)
            { this.money = int.MaxValue; }
            else 
            { this.money += coinInfo.value; }
        }
        else
        {
            if (this.money < int.MinValue - coinInfo.value)
            { this.money = 0; }
            else 
            {
                this.money += coinInfo.value;

                if (this.money < 0) 
                { this.money = 0; }
            }
        }
    }
}
