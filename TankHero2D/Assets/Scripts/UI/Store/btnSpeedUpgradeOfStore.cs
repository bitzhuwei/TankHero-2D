using UnityEngine;
using System.Collections;
using System;

public class btnSpeedUpgradeOfStore : MonoBehaviour
{

    private UnityEngine.UI.Text txtSpeed;

    private void UpdateSpeedBox()
    {
        var heroConfig = GameController.instance.heroConfig;
        var upgradeConfig = heroConfig.GetDefaultUpgradeConfig();
        var next = upgradeConfig.speedStage.Next(heroConfig.fullSpeed);
        if (next == null)
        {
            txtSpeed.text = string.Format("Speed: {0}{1}{2}",
                heroConfig.fullSpeed,
                Environment.NewLine,
                "Max Speed!");
            var img = this.GetComponent<UnityEngine.UI.Image>();
            img.color = new Color(1, 1, 1, 0);
        }
        else
        {
            txtSpeed.text = string.Format("Speed: {0}{1}Next stage: ￥{2}{1}{3}",
                GameController.instance.heroConfig.fullSpeed,
                Environment.NewLine,
                next.item2,
                next.item2 > heroConfig.money ? "No enough money!" : "");
        }
    }

    // Use this for initialization
    void Start()
    {
        txtSpeed = this.transform.parent.GetComponentInChildren<UnityEngine.UI.Text>();
        UpdateSpeedBox();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void btnSpeedUpgrade_Click()
    {
        GameController.instance.heroConfig.UpgradeSpeed();
        UpdateSpeedBox();
    }
}
