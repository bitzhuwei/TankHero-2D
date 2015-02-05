using System;
//using System.Xml.Linq;


    /// <summary>
    /// 单词，即词法分析器输出列表的元素
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    public class Token<TEnumTokenType>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
    {
        private TEnumTokenType m_TokenType = default(TEnumTokenType);
        /// <summary>
        /// 单词类型
        /// </summary>
        public TEnumTokenType TokenType
        {
            get { return m_TokenType; }
            set { m_TokenType = value; }
        }

        private string m_Detail = string.Empty;
        /// <summary>
        /// 具体信息
        /// </summary>
        public string Detail
        {
            get { if (m_Detail == null) m_Detail = string.Empty; return m_Detail; }
            set
            {
                if (value == null)
                    m_Detail = string.Empty;
                else
                    m_Detail = value;
            }
        }

        private string m_errorInfo = string.Empty;
        /// <summary>
        /// 异常信息，一般在LexicalError为true的时候不为空
        /// </summary>
        public string ErrorInfo
        {
            get { if (m_errorInfo == null) m_errorInfo = string.Empty; return m_errorInfo; }
            set
            {
                if (value == null)
                    m_errorInfo = string.Empty;
                else
                    m_errorInfo = value;
            }
        }
        /// <summary>
        /// 附属到此单词对象上的某对象。
        /// </summary>
        public object Tag { get; set; }

        private bool m_LexicalError = false;
        /// <summary>
        /// 标识是否是正确的单词
        /// </summary>
        public bool LexicalError
        {
            get { return m_LexicalError; }
            set { m_LexicalError = value; }
        }

        private int m_Line = -1;
        /// <summary>
        /// 所在行（从0开始）
        /// </summary>
        public int Line
        {
            get { return m_Line; }
            set { m_Line = value; }
        }

        private int m_Column = -1;
        /// <summary>
        /// 所在列（从0开始）
        /// </summary>
        public int Column
        {
            get { return m_Column; }
            set { m_Column = value; }
        }

        private int m_IndexOfSourceCode = -1;
        /// <summary>
        /// 第一个字符在源代码字符串中的索引
        /// </summary>
        public int IndexOfSourceCode
        {
            get { return m_IndexOfSourceCode; }
            set { m_IndexOfSourceCode = value; }
        }

        private int m_Length = 0;
        /// <summary>
        /// 单词长度（字符个数）
        /// </summary>
        public int Length
        {
            get { return m_Length; }
            set { m_Length = value; }
        }

        /// <summary>
        /// 显示[具体信息]$[单词类型]$[行数]$[列数]$[是否是正确的单词]$[备注说明]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0}]$[{1}]$[{2},{3}]$[{4}]$[{5}]"
                , Detail.ToString().Replace("\r\n", "$").Replace('\r', '$').Replace('\n', '$')
                , TokenType, Line, Column, LexicalError
                , ErrorInfo.Replace("\r\n", "$").Replace('\r', '$').Replace('\n', '$'));
        }
    /*
        /// <summary>
        /// XML格式的单词信息
        /// </summary>
        /// <returns></returns>
        public XElement ToXElement()
        {
            XElement result = new XElement(strToken,
                new XAttribute(strTokenType, TokenType),
                new XAttribute(strLine, Line),
                new XAttribute(strColumn, Column),
                new XAttribute(strLexicalError, LexicalError),
                new XAttribute(strIndexOfSourceCode, IndexOfSourceCode),
                new XAttribute(strLength, Length),
                new XElement(strDetail,
                
                    new XCData(Detail.ToString())),
                new XElement(strTag, new XCData(ErrorInfo)));
            return result;
        }
        /// <summary>
        /// 从XML生成一个单词
        /// </summary>
        /// <param name="xToken"></param>
        /// <returns></returns>
        public static Token<TEnumTokenType> From(XElement xToken)
        {
            if (xToken == null) return null;
            if (xToken.Name != strToken) return null;
            var result = new Token<TEnumTokenType>();
            result.TokenType = (TEnumTokenType)Enum.Parse(typeof(TEnumTokenType), xToken.Attribute(strTokenType).Value);
            result.Line = int.Parse(xToken.Attribute(strLine).Value);
            result.Column = int.Parse(xToken.Attribute(strColumn).Value);
            result.LexicalError = bool.Parse(xToken.Attribute(strLexicalError).Value);
            //XElement xDetail=xToken.Element(strDetail);
            result.Detail = xToken.Element(strDetail).Value; //xDetail.Value;
            result.ErrorInfo = xToken.Element(strTag).Value;
            result.IndexOfSourceCode = int.Parse(xToken.Attribute(strIndexOfSourceCode).Value);
            result.Length = int.Parse(xToken.Attribute(strLength).Value);
            return result;
        }
*/
        /// <summary>
        /// 检验两个单词是否一样
        /// </summary>
        /// <param name="tk"></param>
        /// <returns></returns>
        public bool SameWith(Token<TEnumTokenType> tk)
        {
            if (tk == null) return false;
            if (this.Column != tk.Column) return false;
            if (this.Detail != tk.Detail) return false;
            if (this.IndexOfSourceCode != tk.IndexOfSourceCode) return false;
            if (this.Length != tk.Length) return false;
            if (this.LexicalError != tk.LexicalError) return false;
            if (this.Line != tk.Line) return false;
            if (this.ErrorInfo != tk.ErrorInfo) return false;
            if (this.TokenType.CompareTo(tk.TokenType) != 0) return false;
            return true;
        }

        /// <summary>
        /// public const string strToken = "Token";
        /// </summary>
        public const string strToken = "Token";

        private const string strDetail = "Detail";

        //private const string strDetailType = "DetailType";

        private const string strTokenType = "TokenType";

        private const string strLine = "Line";

        private const string strColumn = "Column";

        private const string strLexicalError = "LexicalError";

        private const string strTag = "Tag";

        private const string strIndexOfSourceCode = "IndexOfSourceCode";

        private const string strLength = "Length";
    }
