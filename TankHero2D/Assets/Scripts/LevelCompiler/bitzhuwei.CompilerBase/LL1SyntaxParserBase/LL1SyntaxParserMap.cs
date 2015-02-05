using System;
using System.Collections.Generic;


    /// <summary>
    /// 分析表
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
    /// <typeparam name="TTreeNodeValue">语法树结点值，根据语音特性自定义类型进行填充</typeparam>
    public class LL1SyntaxParserMap<TEnumTokenType, TEnumVType, TTreeNodeValue>
        where TEnumVType : struct, IComparable, IConvertible, IFormattable
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class, ICloneable, new()
    {
        /// <summary>
        /// 分析表
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        public LL1SyntaxParserMap(int line, int column)
        {
            this.m_ParserMap = new CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue>[line, column];
            this.m_LeftNodes = new Dictionary<TEnumVType, int>();
            this.m_NextLeaves = new Dictionary<TEnumTokenType, int>();
            this.m_LineCount = line;
            this.m_ColumnCount = column;
        }
        /// <summary>
        /// 设置某行的结点类型
        /// </summary>
        /// <param name="line"></param>
        /// <param name="leftNode"></param>
        public void SetLine(int line, TEnumVType leftNode)
        {
            if (0 <= line && line < this.m_LineCount)
                this.m_LeftNodes.Add(leftNode, line);
            else
                throw new ArgumentOutOfRangeException("line", line, "LL1分析表行数设置错误！");
        }
        /// <summary>
        /// 设置某列的结点类型
        /// </summary>
        /// <param name="column"></param>
        /// <param name="nextLeave"></param>
        public void SetColumn(int column, TEnumTokenType nextLeave)
        {
            if (0 <= column && column < this.m_ColumnCount)
                this.m_NextLeaves.Add(nextLeave, column);
            else
                throw new ArgumentOutOfRangeException("column", column, "LL1分析表列数设置错误！");
        }
        /// <summary>
        /// 设置给定行、列位置的分析函数
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <param name="function"></param>
        public void SetCell(int line, int column, CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue> function)
        {
            if (0 <= line && line < this.m_LineCount)
            {
                if (0 <= column && column < this.m_ColumnCount)
                    this.m_ParserMap[line, column] = function;
                else
                    throw new ArgumentOutOfRangeException("column", column, "LL1分析表列数设置错误！");
            }
            else
                throw new ArgumentOutOfRangeException("line", line, "LL1分析表行数设置错误！");
        }
        /// <summary>
        /// 设置给定语法类型、单词类型所对应的分析函数
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="nextLeave"></param>
        /// <param name="function"></param>
        public void SetCell(TEnumVType leftNode, TEnumTokenType nextLeave,
            CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue> function)
        {
            SetCell(this.m_LeftNodes[leftNode], this.m_NextLeaves[nextLeave], function);
        }

        /// <summary>
        /// 获取处理函数
        /// </summary>
        /// <param name="leftNode">当前结非终点类型</param>
        /// <param name="nextLeave">要处理的终结点类型</param>
        /// <returns></returns>
        public CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue> GetFunction(TEnumVType leftNode, TEnumTokenType nextLeave)
        {
#if DEBUG
            if (this.m_LeftNodes.ContainsKey(leftNode)
                && this.m_NextLeaves.ContainsKey(nextLeave))
#endif
                return this.GetFunction(this.m_LeftNodes[leftNode], this.m_NextLeaves[nextLeave]);
#if DEBUG
            else
                return null;
#endif
        }
        /// <summary>
        /// 获取处理函数
        /// </summary>
        /// <param name="line">行数</param>
        /// <param name="column">列数</param>
        /// <returns></returns>
        public CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue> GetFunction(int line, int column)
        {
#if DEBUG
            if (0 <= line && line < this.m_LineCount
                && 0 <= column && column < this.m_ColumnCount)
#endif
            return this.m_ParserMap[line, column];
#if DEBUG
            else
                return null;
#endif
        }

        private int m_LineCount;
        private int m_ColumnCount;
        private CandidateFunction<TEnumTokenType, TEnumVType, TTreeNodeValue>[,] m_ParserMap = null;
        private Dictionary<TEnumVType, int> m_LeftNodes = null;
        private Dictionary<TEnumTokenType, int> m_NextLeaves = null;
    }


