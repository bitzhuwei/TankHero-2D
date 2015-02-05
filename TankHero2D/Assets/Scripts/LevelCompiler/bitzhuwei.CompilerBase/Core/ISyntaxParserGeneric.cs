using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    /// <summary>
    /// 语法分析器接口
    /// <para>编写自己的语法分析器并实现此接口，可立即使用本系列产品的其他功能，如直接处理词法分析器的输出</para>
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
    /// <typeparam name="TTreeNodeValue">语法树结点值，根据语音特性自定义类型进行填充</typeparam>
    public interface ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TEnumVType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class,ICloneable, new()
    {
        /// <summary>
        /// 要分析的单词列表
        /// </summary>
        TokenList<TEnumTokenType> GetTokenListSource();
        /// <summary>
        /// 要分析的单词列表
        /// </summary>
        /// <param name="value"></param>
        void SetTokenListSource(TokenList<TEnumTokenType> value);
        /// <summary>
        /// 分析TokenListSource获得语法树
        /// <para>分析之前会重置词法分析器到初始状态</para>
        /// </summary>
        /// <returns></returns>
        SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> Parse();
        /// <summary>
        /// 重置此语法分析器，这样就可以重新分析
        /// <para>重置的目的是保证语法分析器内部TokenListSource的索引指针回到第一个Token的位置</para>
        /// </summary>
        void Reset();
        ///// <summary>
        ///// 获取源代码的规范格式
        ///// </summary>
        ///// <returns></returns>
        //string GetFormattedSourceCode();        
        ///// <summary>
        ///// 获取源代码的规范格式
        ///// </summary>
        ///// <returns></returns>
        //string GetFormattedSourceCode(SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> tree);
        ///// <summary>
        ///// 获取文法
        ///// </summary>
        ///// <returns></returns>
        //ContextfreeGrammar GetGrammar();
        ///// <summary>
        ///// 获取文法
        ///// </summary>
        ///// <param name="tree">语法树</param>
        ///// <returns></returns>
        //ContextfreeGrammar GetGrammar(SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue> tree);
    }
