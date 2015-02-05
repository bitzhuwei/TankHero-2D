using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


    /// <summary>
    /// 创建一个候选式函数的对象
    /// </summary>
    /// <typeparam name="TEnumTokenType"></typeparam>
    /// <typeparam name="TEnumVType"></typeparam>
    /// <typeparam name="TTreeNodeValue"></typeparam>
    public class CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TEnumVType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class,ICloneable, new()
    {
        /// <summary>
        /// 创建一个候选式函数的对象
        /// </summary>
        /// <param name="candidateFunc">此对象包含的委托</param>
        public CandidateFunction(
        Func<SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>,
            ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>,
            SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>> candidateFunc)
        {
            Debug.Assert(candidateFunc != null);
            this.m_CandidateFunc = candidateFunc;
        }
        /// <summary>
        /// 产生此语法树所直接调用的候选式
        /// </summary>
        protected Func<SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>,
            ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>,
            SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>> m_CandidateFunc;
        /// <summary>
        /// 产生此语法树所直接调用的候选式
        /// </summary>
        public Func<SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>,
            ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>,
            SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>> CandidateFunc
        {
            get { return m_CandidateFunc; }
            set { m_CandidateFunc = value; }
        }
        /// <summary>
        /// 调用本候选式函数包含的所有委托
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        public SyntaxTree<TEnumTokenType, TEnumVType,TTreeNodeValue> Call(
            SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> treeNode,
            ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue> parser)
        {
            if (this.m_CandidateFunc != null)
            {
                var result = this.m_CandidateFunc(treeNode, parser);
                return result;
            }
            else 
                return null;
        }
        /// <summary>
        /// 显示委托函数名称。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if(this.m_CandidateFunc!=null)
                return string.Format("{0}", m_CandidateFunc.Method.Name);
            //return base.ToString();
            else return string.Format("{0}", "candidate function not set.");
        }
        /// <summary>
        /// 添加一个候选式函数对象的所有委托到本对象
        /// </summary>
        /// <param name="function"></param>
        public void Add(CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue> function)
        {
            if (function != null)
                this.m_CandidateFunc += function.m_CandidateFunc;
        }


    }
