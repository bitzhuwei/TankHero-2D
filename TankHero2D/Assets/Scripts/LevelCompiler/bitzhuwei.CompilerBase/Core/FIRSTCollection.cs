//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Diagnostics;

//
//{
//    /// <summary>
//    /// FIRST集
//    /// </summary>
//    /// <typeparam name="TEnumVType">语法分析中的结点类型(某Vn or 某Vt)，建议使用枚举类型</typeparam>
//    class FIRSTCollection<TEnumVType>
//        where TEnumVType : struct, IComparable, IFormattable, IConvertible
//    {
//        /// <summary>
//        /// 构造FIRST集
//        /// </summary>
//        /// <param name="grammar">此FIRST集对应的文法</param>
//        public FIRSTCollection(ContextfreeGrammar grammar)
//        {
//            Debug.Assert(grammar != null);
//            this.m_MappedGrammar = grammar;
//            GenerateFIRSTCollection();
//        }

//        private void GenerateFIRSTCollection()
//        {
//            throw new NotImplementedException();
//        }

//        private List<ProductionNodeList> m_FirstCollection = new List<ProductionNodeList>();

//        public List<ProductionNodeList> FirstCollection
//        {
//            get { return m_FirstCollection; }
//            set { m_FirstCollection = value; }
//        }

//        /// <summary>
//        /// 此FIRST集对应的文法
//        /// </summary>
//        private ContextfreeGrammar m_MappedGrammar;
//        /// <summary>
//        /// 此FIRST集对应的文法
//        /// </summary>
//        public ContextfreeGrammar MappedGrammar
//        {
//            get { return m_MappedGrammar; }
//        }
//    }
//}
