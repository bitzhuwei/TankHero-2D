using System;
using System.Collections.Generic;



    /// <summary>
    /// LL1语法分析器基类
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
    /// <typeparam name="TTreeNodeValue">语法树结点值，根据语音特性自定义类型进行填充</typeparam>
    public abstract partial class LL1SyntaxParserBase<TEnumTokenType, TEnumVType, TTreeNodeValue> : ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>
        where TEnumVType : struct, IComparable, IConvertible, IFormattable
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class, ICloneable, new()
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public SyntaxParserLL1Base() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line">分析表行数，应为非叶节点+叶节点</param>
        /// <param name="column">分析表列数，应为非叶节点+1</param>
        public LL1SyntaxParserBase(int line, int column)
        {
            //m_Map = new SyntaxParserMap<TEnumTokenType, TEnumVType, SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>>(line, column);
            if (m_Map == null)
            {
                m_Map = new LL1SyntaxParserMap<TEnumTokenType, TEnumVType, TTreeNodeValue>(line, column); 
                InitMap();
            }
        }
        /// <summary>
        /// 初始化LL(1)分析表
        /// </summary>
        public abstract void InitMap();
        /// <summary>
        /// 单词列表源
        /// </summary>
        protected TokenList<TEnumTokenType> m_TokenListSource = new TokenList<TEnumTokenType>();
        /// <summary>
        /// 单词列表源
        /// </summary>
        public TokenList<TEnumTokenType> GetTokenListSource()
         { return m_TokenListSource; }
        /// <summary>
        /// 单词列表源
        /// </summary>
        /// <param name="value"></param>
        public void SetTokenListSource(TokenList<TEnumTokenType> value)
        { m_TokenListSource = value; }
        /// <summary>
        /// 将要进行分析的单词的索引
        /// </summary>
        protected int m_ptNextToken = 0;
        /// <summary>
        /// 分析表
        /// </summary>
        /// <summary>
        /// 将要进行分析的单词的索引
        /// </summary>
        public int PtNextToken
        {
            get { return m_ptNextToken; }
            set { m_ptNextToken = value; }
        }
        
        /// <summary>
        /// 分析表
        /// </summary>
        protected static LL1SyntaxParserMap<TEnumTokenType, TEnumVType, TTreeNodeValue> m_Map;

#if teaching
#else

        #region do not delete this
        /// <summary>
        /// 进行语法分析，获取语法树
        /// </summary>
        /// <returns></returns>
        public SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> Parse()
        {
            Reset();
#if DEBUG
            PrintState();
            //Console.ReadLine();
#endif
            var result = new SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>();
            var currentNode = result;
            while (m_ptNextToken < m_TokenListSource.Count)
            {
                var nodeType = m_ParserStack.Peek();
                var tokenType = m_TokenListSource[m_ptNextToken].TokenType;
                var function = m_Map.GetFunction(nodeType, tokenType);
                if (currentNode != null)
                    currentNode.CandidateFunc = function;
                if (function != null)
                {
                    currentNode = function.Call(currentNode, this);
#if DEBUG
                    //PrintState();
                    //Console.ReadLine();
#endif
                }
                else
                {
                    if (currentNode != null)
                        currentNode.SyntaxError = true;
                    break;
                }
            }
            result.MappedTokenLength = m_TokenListSource.Count;
            return result;
        }

#if DEBUG
        private void PrintState()
        {
            Console.WriteLine("m_ParserStack:");
            foreach (var v in m_ParserStack.ToArray())
            {
                Console.Write(v + " ");
            }
            int index = m_ptNextToken < m_TokenListSource.Count ? m_ptNextToken : m_TokenListSource.Count - 1;
            Console.WriteLine("m_ptNextToken: {0}, {1}", m_ptNextToken, m_TokenListSource[index].Detail);
            Console.WriteLine();

        }

#endif

        #endregion

#endif

        /// <summary>
        /// 重置语法分析器到初始状态，这样就可以重新对上次分析过的单词列表进行分析
        /// </summary>
        public abstract void Reset();
        //public abstract TEnumTokenType GetstartEnd_ofToken();
        //public abstract TEnumVType GetStart_ofSyntaxTreeNode();
        //public abstract TEnumVType GetstartEndLeave_ofSyntaxTreeNode();

        //public void Reset2()
        //{
        //    m_ptNextToken = 0;
        //    m_ParserStack.Clear();
        //    m_ParserStack.Push(GetstartEndLeave_ofSyntaxTreeNode());
        //    m_ParserStack.Push(GetStart_ofSyntaxTreeNode());
        //    if (m_TokenListSource.Count == 0)
        //    {
        //        var newToken = new Token<TEnumTokenType>()
        //        {
        //            Detail = "#",
        //            Line = 0,
        //            Column = 0,
        //            IndexOfSourceCode = 0,
        //            Length = 1,
        //            LexicalError = false,
        //            TokenType = GetstartEnd_ofToken()
        //        };
        //        m_TokenListSource.Add(newToken);
        //    }
        //    else
        //    {
        //        var token = m_TokenListSource[m_TokenListSource.Count - 1];
        //        {
        //            var newToken = new Token<TEnumTokenType>()
        //            {
        //                Detail = "#",
        //                Line = token.Line,
        //                Column = token.Column + token.Length + 1,
        //                IndexOfSourceCode = token.IndexOfSourceCode + token.Length + 1,
        //                Length = 1,
        //                LexicalError = false,
        //                TokenType = GetstartEnd_ofToken()
        //            };
        //            m_TokenListSource.Add(newToken);
        //        }
        //    }
        //}
        ///// <summary>
        ///// 获取文法
        ///// </summary>
        ///// <returns></returns>
        //public abstract ContextfreeGrammar GetGrammar();
        ///// <summary>
        ///// 获取文法
        ///// </summary>
        ///// <param name="tree">语法树</param>
        ///// <returns></returns>
        //public abstract ContextfreeGrammar GetGrammar(SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> tree);
        ///// <summary>
        ///// 获取源代码的规范格式
        ///// </summary>
        ///// <returns></returns>
        //public abstract string GetFormattedSourceCode();
        ///// <summary>
        ///// 获取源代码的规范格式
        ///// </summary>
        ///// <returns></returns>
        //public abstract string GetFormattedSourceCode(SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> tree);
        /// <summary>
        /// 下一个要扩展的语法树
        /// </summary>
        /// <param name="result"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        protected static SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> 
            Next(SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> result, 
            LL1SyntaxParserBase<TEnumTokenType,TEnumVType,TTreeNodeValue> parser)
        {
            if (result == null) return null;
            var parent = result.Parent;
            if (parent == null) return null;
            int i = 0;
            for (; i < parent.Children.Count; i++)
            {
                if (parent.Children[i] == result) break;
            }
            if (i + 1 < parent.Children.Count)
            {
                return parent.Children[i + 1];
            }
            else
            {
                if (i + 1 == parent.Children.Count)
                {
                    parent.MappedTokenLength = parser.m_ptNextToken - parent.MappedTokenStartIndex;
                }
                return Next(parent, parser);
            }
        }
        /// <summary>
        /// 分析栈
        /// </summary>
        protected Stack<TEnumVType> m_ParserStack = new Stack<TEnumVType>();


    }
