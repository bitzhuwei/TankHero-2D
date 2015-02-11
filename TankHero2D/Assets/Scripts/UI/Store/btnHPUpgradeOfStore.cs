using UnityEngine;
using System.Collections;
using System;

public class btnHPUpgradeOfStore : MonoBehaviour {

    private UnityEngine.UI.Text txtHP;

    private void UpdateHPBox()
    {
        var heroConfig = GameController.instance.heroConfig;
        var upgradeConfig = heroConfig.GetDefaultUpgradeConfig();
        var next = upgradeConfig.hpStage.Next(heroConfig.fullHP);
        if (next == null)
        {
            txtHP.text = string.Format("HP: {0}{1}{2}",
                heroConfig.fullHP,
                Environment.NewLine,
                "Max HP!");
            var img = this.GetComponent<UnityEngine.UI.Image>();
            img.color = new Color(1, 1, 1, 0);
        }
        else
        {
            txtHP.text = string.Format("HP: {0}{1}Next stage: ￥{2}{1}{3}",
                GameController.instance.heroConfig.fullHP,
                Environment.NewLine,
                next.item2,
                next.item2 > heroConfig.money ? "No enough money!" : "");
        }
    }

    // Use this for initialization
    void Start()
    {
        txtHP = this.transform.parent.GetComponentInChildren<UnityEngine.UI.Text>();
        //UpdateHPBox();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHPBox();
    }

    public void btnHPUpgrade_Click()
    {
        GameController.instance.heroConfig.UpdateHP();
        //UpdateHPBox();
    }
}
