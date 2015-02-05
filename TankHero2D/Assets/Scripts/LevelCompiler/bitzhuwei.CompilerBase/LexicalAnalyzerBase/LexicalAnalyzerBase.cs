using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




    /// <summary>
    /// 词法分析器，对一个字符串进行词法分析
    /// <para>当初次分析一个字符串之后，可保留分析状态，便于在字符串改动之后继续分析</para>
    /// <para>若直接继承此类，就不必再继承或实现ILexicalAnalyzer接口，用override重写必要的单词分析方法即可实现新的词法分析器</para>
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    public abstract partial class LexicalAnalyzerBase<TEnumTokenType>
        : ILexicalAnalyzer<TEnumTokenType>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
    {
        /// <summary>
        /// 词法分析抽象基类
        /// </summary>
        public LexicalAnalyzerBase()
            : this(string.Empty)
        {
        }
        /// <summary>
        /// 词法分析器
        /// </summary>
        /// <param name="sourceCode">要分析的源代码</param>
        public LexicalAnalyzerBase(string sourceCode)
        {
            this.SetSourceCode(sourceCode);
        }
        /// <summary>
        ///  要分析的源代码
        /// </summary>
        public virtual string GetSourceCode()
        { return m_SourceCode; }
        /// <summary>
        ///  要分析的源代码
        /// </summary>
        public virtual void SetSourceCode(string value)
        {
            m_SourceCode = value;
            Reset();
        }

#if teaching
#else
        #region noted for StringShot (do not delete this)
        /// <summary>
        /// 分析源代码获得Token序列
        /// <para>分析之前会重置词法分析器到初始状态</para>
        /// </summary>
        /// <returns></returns>
        public TokenList<TEnumTokenType> Analyze()
        {
            var tokens = new TokenList<TEnumTokenType>();
            if (string.IsNullOrEmpty(this.GetSourceCode())) return tokens;
            Reset();
            int count = this.GetSourceCode().Length;
            while (PtNextLetter < count)
            {
                var tk = NextToken();
                if (tk != null)
                    tokens.Add(tk);
            }
            return tokens;
        }

        /// <summary>
        /// 分析源代码获得Token序列
        /// <para>当得到maxTokenCount数目的Token时（或源代码分析完毕时）返回</para>
        /// <para>下次执行时，将从上次执行结束的字符开始</para>
        /// </summary>
        /// <param name="maxTokenCount">应分析得到的Token数目最大值</param>
        /// <returns></returns>
        public TokenList<TEnumTokenType> Analyze(int maxTokenCount)
        {
            var tokens = new TokenList<TEnumTokenType>();
            if (string.IsNullOrEmpty(this.GetSourceCode())) return tokens;
            //analyze source code
            int count = this.GetSourceCode().Length;
            int foundTokens = 0;
            while (PtNextLetter < count && foundTokens < maxTokenCount)
            {
                var tk = NextToken();
                if (tk != null)
                {
                    tokens.Add(tk);
                    foundTokens++;
                }
            }
            return tokens;
        }
        #endregion
#endif

        /// <summary>
        /// 重置此词法分析器，这样就可以开始分析新的源代码
        /// <para>重置的目的是保证Token的行、列数正确</para>
        /// </summary>
        public void Reset()
        {
            this.m_CurrentLine = 0;
            this.m_CurrentColumn = 0;
            this.m_ptNextLetter = 0;
        }

        /// <summary>
        /// 从ptNextLetter开始获取下一个Token
        /// </summary>
        /// <returns></returns>
        protected abstract Token<TEnumTokenType> NextToken();

       
        #region 属性和字段

        /// <summary>
        /// 将要分析的字符索引（从0开始）
        /// </summary>
        public virtual int PtNextLetter
        {
            get { return m_ptNextLetter; }
            protected set
            {
                m_CurrentColumn += value - m_ptNextLetter;
                m_ptNextLetter = value;
            }
        }
        /// <summary>
        /// 源代码
        /// </summary>
        protected string m_SourceCode = string.Empty;
        /// <summary>
        /// 将要分析的字符索引（从0开始）
        /// </summary>
        protected int m_ptNextLetter;
        /// <summary>
        /// ptNextLetter所在行（从0开始）
        /// </summary>
        protected int m_CurrentLine;
        /// <summary>
        /// ptNextLetter所在列（从0开始）
        /// </summary>
        protected int m_CurrentColumn;

        #endregion 属性和字段

    }
