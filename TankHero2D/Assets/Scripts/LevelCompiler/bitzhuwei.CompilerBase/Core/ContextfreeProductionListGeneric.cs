//using System;
//using System.Collections.Generic;
//using System.Text;

//
//{
//    /// <summary>
//    /// 上下文无关产生式列表（文法的主要数据结构）
//    /// </summary>
//    public class ContextfreeProductionList : List<ContextfreeProduction>
//    {
//        /// <summary>
//        /// 判定两个产生式列表（文法的主要数据结构）是否相同
//        /// </summary>
//        /// <param name="obj"></param>
//        /// <returns></returns>
//        public override bool Equals(object obj)
//        {
//            var another = obj as ContextfreeProductionList;
//            if (another == null) return false;
//            if (this.Count != another.Count) return false;
//            for (int i = 0; i < this.Count; i++)
//            {
//                if (!this[i].Equals(another))
//                {
//                    return false;
//                }
//            }
//            return true;
//        }
//        /// <summary>
//        /// 获取哈希值
//        /// </summary>
//        /// <returns></returns>
//        public override int GetHashCode()
//        {
//            StringBuilder builder = new StringBuilder();
//            foreach (var element in this)
//            {
//                builder.Append(element.GetHashCode());
//            }
//            return builder.ToString().GetHashCode();
//            //return base.GetHashCode();
//        }
//        /// <summary>
//        /// 输出各个产生式
//        /// </summary>
//        /// <returns></returns>
//        public override string ToString()
//        {
//            StringBuilder result = new StringBuilder();
//            foreach (var v in this)
//            {
//                result.Append(v.ToString());
//                result.AppendLine();
//            }
//            return result.ToString();
//        }
//    }
//}
