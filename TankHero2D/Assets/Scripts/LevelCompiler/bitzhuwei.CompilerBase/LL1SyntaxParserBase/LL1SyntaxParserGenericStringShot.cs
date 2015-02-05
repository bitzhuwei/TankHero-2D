using System;
using System.Collections.Generic;



#if teaching
    using SmileWei.MemoryShot;
    using System.Text;

    public abstract partial class SyntaxParserLL1Base<TEnumTokenType, TEnumVType, TTreeNodeValue>
        : ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>
        where TEnumVType : struct, IComparable, IConvertible, IFormattable
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class, ICloneable, new()
    {
        /// <summary>
        /// 进行语法分析，获取语法树
        /// </summary>
        /// <returns></returns>
        public SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> Parse()
        {
            Reset();

            m_inputTokenShotter.Source.Clear();
            m_parserStackShotter.Source.Clear();
            m_parserMapShotter.Source.Clear();
            m_syntaxTreeShotter.Source.Clear(); ;

            StringBuilder inputTokensBuilder = new StringBuilder();
            StringBuilder parserStackBuilder = new StringBuilder();
            StringBuilder parserMapBuilder = new StringBuilder();
            StringBuilder syntaxTreeBuilder = new StringBuilder();

            var result = new SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>();
            var tmp = result;
            while (m_ptNextToken < m_TokenListSource.Count)
            {
                var nodeType = m_ParserStack.Peek();
                var currToken = m_TokenListSource[m_ptNextToken];
                var function = m_Map.GetFunction(nodeType, currToken.TokenType);

                inputTokensBuilder.AppendLine(string.Format("->[{0:00000}]{1}", m_ptNextToken, currToken));
                m_inputTokenShotter.Source.Add(inputTokensBuilder.ToString());

                var stack = m_ParserStack.ToArray();
                for (int i = stack.Length - 1; i >= 0; i--)
                    parserStackBuilder.AppendLine(stack[i].ToString());
                m_parserStackShotter.Source.Add(parserStackBuilder.ToString());
                parserStackBuilder.Clear();

                ShotParserMap(nodeType, currToken, function);

                syntaxTreeBuilder.AppendLine(result.ToString());
                m_syntaxTreeShotter.Source.Add(syntaxTreeBuilder.ToString());
                syntaxTreeBuilder.Clear();

                if (tmp != null)
                    tmp.CandidateFunc = function;
                if (function != null)
                {
                    tmp = function(tmp, this);
                }
                else
                {
                    if (tmp != null)
                        tmp.SyntaxError = true;
                    break;
                }
            }
            result.MappedTokenLength = m_TokenListSource.Count;

            inputTokensBuilder.AppendLine(string.Format("->[     ] End Of Token list"));
            m_inputTokenShotter.Source.Add(inputTokensBuilder.ToString());

            var stack2 = m_ParserStack.ToArray();
            for (int i = stack2.Length - 1; i >= 0; i--)
                parserStackBuilder.AppendLine(stack2[i].ToString());
            m_parserStackShotter.Source.Add(parserStackBuilder.ToString());

            if (m_ParserStack.Count>0)
                ShotParserMap(m_ParserStack.Peek(), null, null);

            syntaxTreeBuilder.AppendLine(result.ToString());
            m_syntaxTreeShotter.Source.Add(syntaxTreeBuilder.ToString());


            m_inputTokenShotter.SaveGif("输入的单词流", StringShot.defaultHeight, StringShot.defaultDownStep, 2000);
            m_parserStackShotter.SaveGif("LL1分析栈", StringShot.defaultHeight, StringShot.defaultDownStep, 2000);
            m_parserMapShotter.SaveGif("LL1分析表", StringShot.defaultHeight, StringShot.defaultDownStep, 2000);
            m_syntaxTreeShotter.SaveGif("语法树", StringShot.defaultHeight, StringShot.defaultDownStep, 2000);

            return result;
        }

        private void ShotParserMap(TEnumVType nodeType, Token<TEnumTokenType> currToken,
            Func<SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>,
                ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>,
                SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>> function)
        {
            var method = function.Method;
            string map = string.Format("ParserMap{0}Stack top: {1}{0}current token: {2}{0}method:{3}",
                Environment.NewLine,
                Environment.NewLine + nodeType,
                Environment.NewLine + currToken,
                Environment.NewLine + method.Name + "( ... )");
            m_parserMapShotter.Source.Add(map);
            //if (m_LL1Grammar == null)
            //{

            //}
            //throw new NotImplementedException();
        }

        //private static string m_LL1Grammar = null;
        private StringShot m_syntaxTreeShotter = new StringShot();
        private StringShot m_parserStackShotter = new StringShot();
        private StringShot m_parserMapShotter = new StringShot();
        private StringShot m_inputTokenShotter = new StringShot();
    }
#endif
