using System;
using System.Collections.Generic;
using System.Text;


    /// <summary>
    /// Description of TokenList.
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
    /// <typeparam name="TTreeNodeValue">语法树结点值，根据语音特性自定义类型进行填充</typeparam>
    public class SyntaxTreeList<TEnumTokenType, TEnumVType, TTreeNodeValue> : List<SyntaxTree<TEnumTokenType, TEnumVType, TTreeNodeValue>>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TEnumVType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class,ICloneable, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.Count - 1; i++)
            {
                result.Append(this[i].NodeValue.ToString() + ", ");
            }
            result.Append(this[this.Count - 1].NodeValue.ToString());
            return result.ToString();
        }
    }
