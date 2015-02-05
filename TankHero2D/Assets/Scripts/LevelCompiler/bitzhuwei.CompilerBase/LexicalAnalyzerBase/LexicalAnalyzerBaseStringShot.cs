using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




#if teaching
using SmileWei.MemoryShot;
    public abstract partial class LexicalAnalyzerBase<TEnumTokenType>
        : ILexicalAnalyzer<TEnumTokenType>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
    {
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
            
            this.m_shotter.Source.Clear();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("TokenList:");
            int index = 0;
            
            while (PtNextLetter < count)
            {
                var tk = NextToken();
                if (tk != null)
                {
                    tokens.Add(tk);

                    string strIndex = string.Format("[{0:000000}]", index);
                    index++;
                    builder.AppendLine(strIndex + ": " + tk.ToString());
                }
                else
                {
                    //string strIndex = string.Format("[{0:000000}]", -1);
                    string strIndex = string.Format("[           ]");
                    builder.AppendLine(strIndex + ": null");
                }
                this.m_shotter.Source.Add(builder.ToString());
            }

            builder.AppendLine("TokenList count: " + tokens.Count);
            this.m_shotter.Source.Add(builder.ToString());
            //this.m_shotter.Save("TokenList");
            this.m_shotter.SaveGif("TokenList", StringShot.defaultHeight, StringShot.defaultDownStep, 2000);
            this.m_shotter.Source.Clear();

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

            if (PtNextLetter <= 0) this.m_shotter.Source.Clear();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("TokenList:");
            int index = 0;

            int count = this.GetSourceCode().Length;
            int foundTokens = 0;
            while (PtNextLetter < count && foundTokens < maxTokenCount)
            {
                var tk = NextToken();
                if (tk != null)
                {
                    tokens.Add(tk);
                    foundTokens++;

                    string strIndex = string.Format("[{0:000000}]", index);
                    index++;
                    builder.AppendLine(strIndex + ": " + tk.ToString());
                }
                else
                {
                    string strIndex = string.Format("[           ]");
                    builder.AppendLine(strIndex + ": null");
                }
            }

            if (PtNextLetter >= count)
            {
                builder.AppendLine("TokenList count: " + tokens.Count);
                this.m_shotter.Source.Add(builder.ToString());
                //this.m_shotter.Save("TokenList");
                this.m_shotter.SaveGif("TokenList", StringShot.defaultHeight, StringShot.defaultDownStep, 2000);
                this.m_shotter.Source.Clear();
            }

            return tokens;
        }

        StringShot m_shotter = new StringShot();
    }
#endif
