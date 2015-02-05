//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//
//{
//    /// <summary>
//    /// 2型文法（上下文无关文法）
//    /// </summary>
//    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
//    public class ContextfreeGrammar
//    {

        

//        /// <summary>
//        /// 获取规范化之后的上下文无关文法
//        /// </summary>
//        /// <returns></returns>
//        public ContextfreeGrammar Normalize()
//        {
//            var result = new ContextfreeGrammar();

//            var startProduction = this.ProductionCollection[0].Dump();
//                //this.ProductionCollection[0].Clone() as ContextfreeProduction<TEnumVType>;
//            result.ProductionCollection.Add(startProduction);

//            ContextfreeProduction production = null;
//            for (int i = 1; i < this.ProductionCollection.Count;i++ )
//            {//将production加入文法中
//                production = this.m_ProductionCollection[i];
//                bool thisAdded = false;
//                foreach (var added in result.ProductionCollection)//尝试并入原有产生式
//                {
//                    if (added.Left.Equals(production.Left))//左部相同，应该合并
//                    {
//                        foreach (var waiting in production.RightCollection)
//                        {//将新的候选式加入右部
//                            if (!added.Contains(waiting))
//                            {
//                                added.RightCollection.Add(waiting);
//                            }
//                        }
//                        thisAdded = true;
//                    }
//                }
//                if (!thisAdded)//添加新的产生式
//                {
//                    result.ProductionCollection.Add(production);
//                }
//            }

//            return result;
//        }
//        /// <summary>
//        /// 获取规范化之后的上下文无关文法
//        /// </summary>
//        /// <param name="overrideGrammarName">标识是否使用起始非叶节点名作为文法名</param>
//        /// <returns></returns>
//        public ContextfreeGrammar Normalize(bool overrideGrammarName)
//        {
//            var result = Normalize();
//            if (overrideGrammarName)
//                result.m_GrammarName = m_ProductionCollection[0].Left.NodeName;
//            return result;
//        }
//        /// <summary>
//        /// 获取规范化之后的上下文无关文法
//        /// </summary>
//        /// <param name="grammarName">规范化之后的文法名</param>
//        /// <returns></returns>
//        public ContextfreeGrammar Normalize(string grammarName)
//        {
//            var result = Normalize();
//            this.GrammarName = grammarName;
//            return result;
//        }

//        public override string ToString()
//        {
//            return string.Format("Name:{0}{1}{2}", m_GrammarName,Environment.NewLine,this.m_ProductionCollection.ToString());
//            //return base.ToString();
//        }
//        ///// <summary>
//        ///// 产生文法字符串
//        ///// </summary>
//        ///// <returns></returns>
//        //public override string ToString()
//        //{
//        //    return ToString(EnumProductionPrintType.SeperateProductionWithAngleBracket);
//        //}

//        ///// <summary>
//        ///// 根据指定的输出类型给出输出
//        ///// </summary>
//        ///// <param name="printType"></param>
//        ///// <returns></returns>
//        //public string ToString(EnumProductionPrintType printType)
//        //{
//        //    StringBuilder builder = new StringBuilder();
//        //    builder.Append(GrammarName + ":");
//        //    if (HeadNode != null)
//        //        builder.Append(HeadNode.ToString(printType));
//        //    else
//        //        builder.AppendLine("此文法没有指定开始符号");
//        //    builder.AppendLine();
//        //    if (ProductionCollection != null)
//        //    {
//        //        int count = ProductionCollection.Count;
//        //        if (count == 0)
//        //            builder.AppendLine("此文法不含产生式");
//        //        else
//        //            for (int i = 0; i < ProductionCollection.Count; i++)
//        //            {
//        //                builder.AppendLine(ProductionCollection[i].ToString(printType));
//        //            }
//        //    }
//        //    else
//        //        builder.AppendLine("此文法的产生式列表指针为空");
//        //    return builder.ToString();
//        //}

//        #region 属性和字段


//        //List<ProductionNode<TEnumVType>> m_NonterminalList = new List<ProductionNode<TEnumVType>>();
//        ///// <summary>
//        ///// 非终结点列表
//        ///// </summary>
//        //public List<ProductionNode<TEnumVType>> NonterminalList
//        //{
//        //    get { return m_NonterminalList; }
//        //    set { m_NonterminalList = value; }
//        //}

//        //List<ProductionNode<TEnumVType>> m_TerminalList = new List<ProductionNode<TEnumVType>>();
//        ///// <summary>
//        ///// 终结点列表
//        ///// </summary>
//        //public List<ProductionNode<TEnumVType>> TerminalList
//        //{
//        //    get { return m_TerminalList; }
//        //    set { m_TerminalList = value; }
//        //}

//        ContextfreeProductionList m_ProductionCollection = new ContextfreeProductionList();
//        /// <summary>
//        /// 产生式列表
//        /// </summary>
//        public ContextfreeProductionList ProductionCollection
//        {
//            get { return m_ProductionCollection; }
//            set { m_ProductionCollection = value; }
//        }

//        //ProductionNode<TEnumVType> m_HeadNode;
//        ///// <summary>
//        ///// 开始结点
//        ///// </summary>
//        //public ProductionNode<TEnumVType> HeadNode
//        //{
//        //    get { return m_HeadNode; }
//        //    set { m_HeadNode = value; }
//        //}

//        public string m_GrammarName = "DefaultGrammar";
//        /// <summary>
//        /// 文法名
//        /// </summary>
//        public string GrammarName
//        {
//            get { return m_GrammarName; }
//            set
//            {
//                if (!string.IsNullOrEmpty(value))
//                {
//                    if ('0' <= value[0] && value[0] <= '9')
//                        this.m_GrammarName = "_" + value;
//                    else
//                        this.m_GrammarName = value;
//                }
//            }
//        }

//        #endregion 属性和字段

//    }
//}
