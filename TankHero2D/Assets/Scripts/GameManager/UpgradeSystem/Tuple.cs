using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Tuple<T1, T2>
{
    public T1 item1;
    public T2 item2;
    public Tuple(T1 item1, T2 item2)
    {
        this.item1 = item1;
        this.item2 = item2;
    }
    public override string ToString()
    {
        return string.Format("{0}, {1}", item1, item2);
        //return base.ToString();
    }
}
