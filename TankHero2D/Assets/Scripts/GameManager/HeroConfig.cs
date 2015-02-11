using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroConfig
{
    public int fullSpeed = 3;
    public int fullHP = 100;
    public int money = 10000;
    private static UpgradeConfig upgradeConfig;
    private static readonly object synObj = new object();

    public HeroConfig()
    {
        var config = GetDefaultUpgradeConfig();
        this.fullSpeed = config.speedStage[0].item1;
        this.fullHP = config.hpStage[0].item1;
    }
    public UpgradeConfig GetDefaultUpgradeConfig()
    {
        if (upgradeConfig == null)
        {
            lock (synObj)
            {
                if (upgradeConfig == null)
                {
                    var config = new UpgradeConfig();
                    config.speedStage.Add(new Tuple<int, int>(3, 0));
                    config.speedStage.Add(new Tuple<int, int>(4, 1000));
                    config.speedStage.Add(new Tuple<int, int>(5, 2000));
                    config.speedStage.Add(new Tuple<int, int>(6, 5000));
                    config.speedStage.Add(new Tuple<int, int>(7, 10000));
                    config.speedStage.Add(new Tuple<int, int>(8, 20000));
                    config.hpStage.Add(new Tuple<int, int>(100, 0));
                    config.hpStage.Add(new Tuple<int, int>(150, 1000));
                    config.hpStage.Add(new Tuple<int, int>(200, 2000));
                    config.hpStage.Add(new Tuple<int, int>(300, 5000));
                    config.hpStage.Add(new Tuple<int, int>(500, 10000));
                    config.hpStage.Add(new Tuple<int, int>(1000, 20000));
                    upgradeConfig = config;
                }
            }
        }

        return upgradeConfig;
    }

    public void UpgradeSpeed()
    {
        var next = GetDefaultUpgradeConfig().speedStage.Next(this.fullSpeed);
        if (next != null)
        {
            if (next.item2 <= this.money)
            {
                this.money -= next.item2;
                this.fullSpeed = next.item1;
            }
        }
    }

    public void UpdateHP()
    {
        var next = GetDefaultUpgradeConfig().hpStage.Next(this.fullHP);
        if (next != null)
        {
            if (next.item2 <= this.money)
            {
                this.money -= next.item2;
                this.fullHP = next.item1;
            }
        }
    }
}
