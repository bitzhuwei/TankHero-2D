//using System;
//using System.Collections.Generic;

//
//{
//    /// <summary>
//    /// 上下文无关产生式
//    /// </summary>
//    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
//    public class ContextfreeProduction : ICloneable
//    {
//        ///// <summary>
//        ///// 获取一个消除了左递归的产生式
//        ///// </summary>
//        ///// <returns></returns>
//        //public List<ContextfreeProduction<TEnumVType>> EliminateLeftRecursion()
//        //{
//        //    var result = new List<ContextfreeProduction<TEnumVType>>();
//        //    var origin = this.Clone() as ContextfreeProduction<TEnumVType>;
//        //    var recuresionList = new List<ProductionNodeList<TEnumVType>>();
//        //    var nonRecuresionList = new List<ProductionNodeList<TEnumVType>>();

//        //    foreach (var item in origin.RightCollection)
//        //    {
//        //        if (item[0].Equals(origin.Left))
//        //        {
//        //            recuresionList.Add(item);
//        //        }
//        //        else
//        //        {
//        //            nonRecuresionList.Add(item);
//        //        }
//        //    }
//        //    if (recuresionList.Count == 0)
//        //    {
//        //        result.Add(origin);
//        //        return result;
//        //    }
//        //    else
//        //    {
//        //        var newProduction = new ContextfreeProduction<TEnumVType>();
//        //        //var newLeft = new ProductionNode<TEnumVType>(origin.Left.NodeName+"_Recuresion",);
//        //        foreach (var item in recuresionList)
//        //        {

//        //        }
//        //    }
//        //}
//        /// <summary>
//        /// 获取一个归并了产生式右部的重复内容的新的产生式
//        /// <para>原有产生式不受影响</para>
//        /// </summary>
//        /// <returns></returns>
//        public ContextfreeProduction Dump()
//        {
//            var result = this.Clone() as ContextfreeProduction;
//            //for (int i = result.RightCollection.Count - 1; i > 0;i-- )
//            //{
//            //    for (int j = 0; j < i; j++)
//            //    {
//            //        if (result.RightCollection[j].Equals(result.RightCollection[i]))
//            //        {
//            //            result.RightCollection.Remove(result.RightCollection[i]);
//            //            break;
//            //        }
//            //    }
//            //}
//            for (int i = 0; i < result.RightCollection.Count - 1; i++)
//            {
//                for (int j = i + 1; j < result.RightCollection.Count; j++)
//                {
//                    if (result.RightCollection[i].Equals(result.RightCollection[j]))
//                    {
//                        result.RightCollection.Remove(result.RightCollection[j]);
//                        j--;
//                    }
//                }
//            }
//            return result;
//        }
//        /// <summary>
//        /// 给出产生式内容
//        /// </summary>
//        /// <returns></returns>
//        public override string ToString()
//        {
//            return string.Format("{0} ::= {1};", Left.ToString(), RightCollection.ToString());
//            //return base.ToString();
//        }
//        /*
//         * G:
//         * S ::= ABC
//         * 
//         * S ::= A B C
//         * [S] ::= [A][B][C]
//         */
//        /// <summary>
//        /// 产生式左部
//        /// </summary>
//        public ProductionNode Left { get; set; }
//        /// <summary>
//        /// 产生式右部
//        /// </summary>
//        public ProductionNodeListList RightCollection { get; set; }
//        /// <summary>
//        /// 判定此产生式右部是否包含给定的候选式
//        /// </summary>
//        /// <param name="candidate"></param>
//        /// <returns></returns>
//        public bool Contains(ProductionNodeList candidate)
//        {
//            if (candidate == null) return false;
//            foreach (var originalCandidate in this.RightCollection)
//            {
//                if (originalCandidate.Equals(candidate))
//                {
//                    return true;
//                }
//            }
//            return false;
//        }
//        /// <summary>
//        /// 获取此上下文无关产生式的复制品
//        /// </summary>
//        /// <returns></returns>
//        public object Clone()
//        {
//            var result = new ContextfreeProduction();
//            if (this.Left != null)
//                result.Left = this.Left.Clone() as ProductionNode;
//            if (this.RightCollection != null)
//                result.RightCollection = this.RightCollection.Clone() as ProductionNodeListList;
//            return result;
//        }
//    }
//}
