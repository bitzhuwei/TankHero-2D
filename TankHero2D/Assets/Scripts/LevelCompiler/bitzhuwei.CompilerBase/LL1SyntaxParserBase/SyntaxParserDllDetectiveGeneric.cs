using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;


    /// <summary>
    /// 用于检测给定的DLL文件是不是含有实现了ILexicalAnalyzer接口的词法分析器
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
    /// <typeparam name="TTreeNodeValue">语法树结点值，根据语音特性自定义类型进行填充</typeparam>
    public class SyntaxParserDllDetective<TEnumTokenType, TEnumVType, TTreeNodeValue>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
        where TEnumVType : struct, IComparable, IFormattable, IConvertible
        where TTreeNodeValue : class, ICloneable, new()
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("DllDetective: {0}", this.GetDllFile());
            //return base.ToString();
        }
        /// <summary>
        /// 分析的dll文件
        /// </summary>
        public string GetDllFile()
        {
            return m_DllFile;
        }
        /// <summary>
        /// 分析的dll文件
        /// </summary>
        public void SetDllFile(string value)
        {
            m_DllFile = value;
            if (File.Exists(m_DllFile))
            {
                Assembly ass = Assembly.LoadFrom(m_DllFile);
                Type[] types = ass.GetTypes();
                List<Type> tmp = new List<Type>();
                foreach (var v in types)
                {
                    if (Utility.ImplementedInterface(v, typeof(ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>)))
                    {
                        tmp.Add(v);
                    }
                }
                this.SyntaxParserTypeCollection = tmp;
            }

        }    
        private string m_DllFile;


        /// <summary>
        /// 分析得到的词法分析器类型列表
        /// </summary>
        public IList<Type> SyntaxParserTypeCollection { get; private set; }
        //{
        //    get { return m_LexicalAnalyzerTypeCollection; }
        //    private set
        //    {
        //        m_LexicalAnalyzerTypeCollection = value;
        //    }
        //}
        //private List<Type> m_LexicalAnalyzerTypeCollection = new List<Type>();
        private static readonly Type[] noParamType = new Type[] { };
        /// <summary>
        /// 
        /// </summary>
        public SyntaxParserDllDetective()
        {
            m_DllFile = string.Empty;
            SyntaxParserTypeCollection = new List<Type>();
        }
        /// <summary>
        /// 获取第一个分析出来的词法分析器的一个对象
        /// </summary>
        /// <returns></returns>
        public ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue> GetParserAtFirstType()
        {
            if (SyntaxParserTypeCollection.Count == 0) return null;
            var obj = Activator.CreateInstance(SyntaxParserTypeCollection[0]);
            return obj as ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>;
        }
        /// <summary>
        /// 根据给定名称获取词法分析器的一个对象
        /// </summary>
        /// <param name="typeFullName"></param>
        /// <returns></returns>
        public ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue> GetParser(string typeFullName)
        {
            foreach (var v in SyntaxParserTypeCollection)
            {
                if (v.FullName == typeFullName)
                {
                    object obj = null;
                    if (v.GetConstructor(noParamType) != null)
                    {
                        obj = Activator.CreateInstance(v);
                    }
                    return obj as ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>;
                }
            }
            return null;
        }
        /// <summary>
        /// 判断给定的Dll文件是否包含可用的词法分析器类型
        /// </summary>
        /// <param name="dllFileName">包含.dll扩展名</param>
        /// <returns></returns>
        public static bool LegalDll(string dllFileName)
        {
            if (File.Exists(dllFileName))
            {
                Assembly ass = Assembly.LoadFrom(dllFileName);
                Type[] types = ass.GetTypes();
                foreach (var v in types)
                {
                    if (Utility.ImplementedInterface(v, typeof(ISyntaxParser<TEnumTokenType, TEnumVType, TTreeNodeValue>)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
