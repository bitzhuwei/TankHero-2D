using UnityEngine;
using System.Collections;

public class CoinManager : MonoBehaviour {

    private Health healthScript;
    private HeroConfig heroConfig;

    void Awake()
    {
        healthScript = this.GetComponentInChildren<Health>();
    }

    void Start()
    {
        heroConfig = GameController.instance.heroConfig;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            var maxHealing = (int)(healthScript.fullHP - healthScript.HP);
            if (heroConfig.money >= maxHealing)
            {
                heroConfig.money -= maxHealing;
                healthScript.FillHealth(maxHealing);
            }
            else
            {
                var healing = heroConfig.money;
                heroConfig.money = 0;
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
            if (heroConfig.money >= int.MaxValue - coinInfo.value)
            { heroConfig.money = int.MaxValue; }
            else
            { heroConfig.money += coinInfo.value; }
        }
        else
        {
            if (heroConfig.money < int.MinValue - coinInfo.value)
            { heroConfig.money = 0; }
            else 
            {
                heroConfig.money += coinInfo.value;

                if (heroConfig.money < 0)
                { heroConfig.money = 0; }
            }
        }
    }
}
