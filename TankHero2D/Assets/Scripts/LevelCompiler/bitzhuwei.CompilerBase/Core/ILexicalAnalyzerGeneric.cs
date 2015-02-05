using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    /// <summary>
    /// 词法分析器接口
    /// <para>编写自己的词法分析器并实现此接口，可立即使用本系列产品的其他功能，如实时词法分析器</para>
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    public interface ILexicalAnalyzer<TEnumTokenType>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
    {
        /// <summary>
        /// 要分析的源代码
        /// </summary>
        string GetSourceCode();
        /// <summary>
        /// 要分析的源代码
        /// </summary>
        void SetSourceCode(string value);
        /// <summary>
        /// 分析源代码获得Token序列
        /// <para>分析之前会重置词法分析器到初始状态</para>
        /// </summary>
        /// <returns></returns>
        TokenList<TEnumTokenType> Analyze();
        /// <summary>
        /// 分析源代码获得Token序列
        /// <para>当得到maxTokenCount数目的Token时（或源代码分析完毕时）返回</para>
        /// </summary>
        /// <param name="maxTokenCount">应分析得到的Token数目最大值</param>
        /// <returns></returns>
        TokenList<TEnumTokenType> Analyze(int maxTokenCount);
        /// <summary>
        /// 重置此词法分析器，这样就可以开始分析新的源代码
        /// <para>重置的目的是保证Token的行、列数正确</para>
        /// </summary>
        void Reset();
    }
