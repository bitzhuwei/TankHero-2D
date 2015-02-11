using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class WeaponSelector : MonoBehaviour
{
    public int selectIndex;
    Weapon[] weapons;

    void Awake()
    {
        this.weapons = this.GetComponents<Weapon>();
        selectIndex = 0;
        this.weapons[0].enabled = true;
        for (int i = 1; i < this.weapons.Length; i++)
        {
            this.weapons[i].enabled = false;
        }
    }
    
    void Start()
    {

    }
    public void Select(Type weaponType)
    {
        foreach (var item in this.weapons)
        {
            item.enabled = (item.GetType() == weaponType);
        }
    }

    public void Select(int index)
    {
        //if (index < 0 || index >= this.weapons.Length) { return; }

        foreach (var item in this.weapons)
        {
            item.enabled = false;
        }

        this.weapons[index].enabled = true;
    }

    public void SelectNext()
    {
        if (this.weapons.Length <= 1) { return; }

        this.weapons[selectIndex].enabled = false;
        if(this.selectIndex+1<this.weapons.Length)
        {
            this.weapons[selectIndex + 1].enabled = true;
            this.selectIndex++;
        }
        else
        {
            this.weapons[0].enabled = true;
            this.selectIndex = 0;
        }
    }
}
