using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UpgradeConfig
{
    public Stage<int, int> speedStage = new Stage<int, int>();

    public Stage<int, int> hpStage = new Stage<int, int>();
    
    public class Stage<T1,T2>:List<Tuple<T1,T2>>
        where T1 : System.IComparable<T1>
    {
        //public T1 value;
        //public T2 cost;
        //public Stage<T1, T2> next;
        //public Stage(T1 value, T2 cost, Stage<T1, T2> next = null)
        //{
        //    this.value = value;
        //    this.cost = cost;
        //    this.next = next;
        //}
        //public override string ToString()
        //{
        //    return string.Format("{0}, {1}", value, cost);
        //    //return base.ToString();
        //}
        public Tuple<T1, T2> Next(T1 value)
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (this[i].item1.CompareTo(value) == 0)
                {
                    return this[i + 1];
                }
            }

            return null;
        }
    }
}
