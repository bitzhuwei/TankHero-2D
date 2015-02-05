using System;
using System.Collections.Generic;
using System.Text;


    /// <summary>
    /// Description of SyntaxTreeGeneric.
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn 或 某Vt)，建议使用枚举类型</typeparam>
    /// <typeparam name="TTreeNodeValue">语法树结点值，根据语音特性自定义类型进行填充</typeparam>
    public class SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> : ICloneable
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TEnumVType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class, ICloneable, new()
    {
        /// <summary>
        /// 有缩进的树状信息
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            int tabSpace = 0;
            GetBuilder(builder, this, ref tabSpace);
            return builder.ToString();
        }

        private void GetBuilder(StringBuilder builder, SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> tree, ref int tabSpace)
        {
            //builder.AppendLine(GetSpace(tabSpace) + tree.NodeValue.ToString());
            //builder.AppendLine(GetBrantch(tabSpace)/*GetSpace(tabSpace)*/ + tree.NodeValue.ToString());
            //builder.AppendLine(GetPreMarks(tree)/*GetSpace(tabSpace)*/ + tree.NodeValue.ToString());
            builder.AppendLine(GetPreMarks2(tree)/*GetSpace(tabSpace)*/ + tree.NodeValue.ToString());
            tabSpace++;
            foreach (var item in tree.Children)
            {
                GetBuilder(builder, item, ref tabSpace);
            }
            tabSpace--;
        }

        string GetPreMarks2(SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> tree)
        {
            var parent = tree.Parent;
            if (parent == null) return string.Empty;
            List<bool> lstline = new List<bool>();
            while (parent != null)
            {
                var pp = parent.Parent;
                if (pp != null)
                {
                    lstline.Add(pp.Children.IndexOf(parent) < pp.Children.Count - 1);
                }
                parent = pp;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = lstline.Count - 1; i >= 0; i--)
            {
                if (lstline[i])
                    builder.Append("│  ");
                else
                    builder.Append("    ");
            }
            parent = tree.Parent;
            if (parent.Children.IndexOf(tree) < parent.Children.Count - 1)
                builder.Append("├─");
            else
                builder.Append("└─");
            return builder.ToString();
        }
#if DEBUG
        string GetPreMarks(SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> tree)
        {
            var parent = tree.Parent;
            if (parent == null) return string.Empty;
            List<bool> lstline = new List<bool>();
            while (parent != null)
            {
                var pp = parent.Parent;
                if (pp != null)
                {
                    lstline.Add(pp.Children.IndexOf(parent) < pp.Children.Count - 1);
                }
                parent = pp;
            }
            StringBuilder builder = new StringBuilder();
            for (int i = lstline.Count - 1; i >= 0; i--)
            {
                if (lstline[i])
                    builder.Append("│  ");
                else
                    builder.Append("    ");
            }
            builder.Append("└─");
            return builder.ToString();
        }

        string GetBrantch(int tabspace)
        {
            if (tabspace < 1)
                return string.Empty;
            return (GetSpace(tabspace - 1) + "└─"/*"|-"*/);
        }

        string GetSpace(int tabspace)
        {
            lock (spaces)
            {
                if (tabspace < 0)
                    tabspace = 0;
                if (tabspace >= spaces.Count)
                {
                    StringBuilder builder = new StringBuilder(spaces[spaces.Count - 1]);
                    for (int i = spaces.Count - 1; i < tabspace; i++)
                    {
                        builder.Append("    ");
                        spaces.Add(builder.ToString());
                    }
                }
            }
            return spaces[tabspace];
        }

        private static List<string> spaces = new List<string>()
        {
            "",
            "    ",
        };
#endif
        ///// <summary>
        ///// 语法树概要信息
        ///// </summary>
        ///// <returns></returns>
        //public override string ToString()
        //{
        //    string result = string.Format("{0}, Index:{1}, Lengh: {2}, Children: {3}, {4}"
        //        , this.m_NodeValue.ToString(), this.m_MappedTokenStartIndex, this.m_MappedTokenLength, this.m_Children.Count
        //        , this.m_SyntaxError ? this.Tag : "√");
        //    return result;
        //    //return base.ToString();
        //}

        #region 字段和属性
        /// <summary>
        /// 产生此语法树所直接调用的候选式
        /// </summary>
        protected CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue> m_CandidateFunc;
        /// <summary>
        /// 产生此语法树所直接调用的候选式
        /// </summary>
        public CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue> CandidateFunc
        {
            get { return m_CandidateFunc; }
            set
            {
                m_CandidateFunc = value;
                    //as Func<SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>,
                    //ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>,
                    //SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>>;
            }
        }
        private int m_MappedTokenStartIndex = 0;
        /// <summary>
        /// 对应的第一个单词
        /// </summary>
        public int MappedTokenStartIndex
        {
            get { return m_MappedTokenStartIndex; }
            set { m_MappedTokenStartIndex = value; }
        }
        private int m_MappedTokenLength = 0;
        /// <summary>
        /// 对应的单词数目
        /// </summary>
        public int MappedTokenLength
        {
            get { return m_MappedTokenLength; }
            set { m_MappedTokenLength = value; }
        }

        /// <summary>
        /// 对应的单词列表
        /// </summary>
        public TokenList<TEnumTokenType> GetMappedTokenList()
        {
            var result = new TokenList<TEnumTokenType>();
            if (MappedTotalTokenList != null && MappedTotalTokenList.Count > 0)
            {
                if (MappedTokenLength > 0)
                {
                    for (int i = 0, j = MappedTokenStartIndex; i < MappedTokenLength; i++, j++)
                    {
                        result.Add(MappedTotalTokenList[j]);
                    }
                }
            }
            return result;
        }
        private TokenList<TEnumTokenType> m_MappedTotalTokenList = new TokenList<TEnumTokenType>();
        /// <summary>
        /// 整个语法树对应的单词列表
        /// </summary>
        public TokenList<TEnumTokenType> MappedTotalTokenList
        {
            get { return m_MappedTotalTokenList; }
            set { m_MappedTotalTokenList = value; }
        }
        private string m_ErrorInfo = string.Empty;
        /// <summary>
        /// 绑定到此结点的对象，在Clone时无须复制。
        /// </summary>
        public object Tag { get; set; }
        /// <summary>
        /// 标记，若发生语法错误，应在此说明
        /// </summary>
        public string ErrorInfo
        {
            get { return m_ErrorInfo; }
            set { m_ErrorInfo = value; }
        }
        /// <summary>
        /// 是否有语法错误
        /// </summary>
        private bool m_SyntaxError = false;
        /// <summary>
        /// 是否有语法错误
        /// </summary>
        public bool SyntaxError
        {
            get
            {
                if (m_SyntaxError) return true;
                else
                {
                    foreach (var item in m_Children)
                    {
                        if (item.m_SyntaxError)
                            return true;
                    }
                    return false;
                }
            }
            set { m_SyntaxError = value; }
        }
        /// <summary>
        /// 获取此树及其子树中有语法错误的结点的列表
        /// </summary>
        /// <returns></returns>
        public SyntaxTreeList<TEnumTokenType, TEnumVType, TTreeNodeValue>
            GetErrorTreeNodes()
        {
            var result = new SyntaxTreeList<TEnumTokenType, TEnumVType, TTreeNodeValue>();
            this._GetErrorTreeNodes(result);
            return result;
        }

        private void _GetErrorTreeNodes(SyntaxTreeList<TEnumTokenType,TEnumVType,TTreeNodeValue> result)
        {
            if (m_SyntaxError) result.Add(this);
            foreach (var item in m_Children)
            {
                item._GetErrorTreeNodes(result);
            }
        }
        //private ProductionNode<TEnumVType> m_Value = new ProductionNode<TEnumVType>(
        //    default(TEnumVType).ToString(), default(TEnumVType));
        ///// <summary>
        ///// 此结点的值
        ///// </summary>
        //public ProductionNode<TEnumVType> Value
        //{
        //    get { return m_Value; }
        //    set { m_Value = value; }
        //}
        /// <summary>
        /// 此结点的值
        /// </summary>
        private TTreeNodeValue m_NodeValue = new TTreeNodeValue();
        /// <summary>
        /// 此结点的值
        /// </summary>
        public TTreeNodeValue NodeValue
        {
            get { return m_NodeValue; }
            set { m_NodeValue = value; }
        }
        private SyntaxTreeList<TEnumTokenType, TEnumVType, TTreeNodeValue> m_Children = new SyntaxTreeList<TEnumTokenType, TEnumVType, TTreeNodeValue>();
        /// <summary>
        /// 子结点
        /// </summary>
        public SyntaxTreeList<TEnumTokenType, TEnumVType, TTreeNodeValue> Children
        {
            get { return m_Children; }
            set { m_Children = value; }
        }
        private SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> m_Parent = null;
        /// <summary>
        /// 父结点
        /// </summary>
        public SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; }
        }
        #endregion 字段和属性

        /// <summary>
        /// 创建本语法树的深复制对象。
        /// <para>除Tag属性外，其他属性完全相同</para>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var result = new SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>();
            result.CandidateFunc = this.CandidateFunc;
            result.MappedTokenLength = this.MappedTokenLength;
            result.MappedTokenStartIndex = this.MappedTokenStartIndex;
            result.MappedTotalTokenList = this.MappedTotalTokenList;
            result.NodeValue = this.NodeValue.Clone() as TTreeNodeValue;
            result.SyntaxError = this.SyntaxError;
            result.ErrorInfo = this.ErrorInfo;
            foreach (var item in this.Children)
            {
                var c = item.Clone() as SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>;
                result.Children.Add(c);
                c.Parent = result;
            }
            return result;
        }
    }
