using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
//using System.Xml.Linq;


    /// <summary>
    /// Description of TokenList.
    /// </summary>
    /// <typeparam name="TEnumTokenType">单词的枚举类型</typeparam>
    public class TokenList<TEnumTokenType> : List<Token<TEnumTokenType>>
        where TEnumTokenType : struct, IComparable, IFormattable, IConvertible
    {
    /*
        void Save(string fileName, bool asXML)
        {
            if (asXML)
            {
                if (string.IsNullOrEmpty(fileName)) fileName = "TokenList.xml";
                else if (!fileName.ToLower().EndsWith(".xml")) fileName += ".xml";
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(this.ToXElement());
                }
            }
            else
            {
                if (string.IsNullOrEmpty(fileName)) fileName = "TokenList.txt";
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(this.ToString());
                }
            }
        }

        /// <summary>
        /// 给出单词列表
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(strTokenList + "[Count:" + this.Count + "]");
            foreach (var v in this)
            {
                builder.AppendLine(v.ToString());
            }
            return builder.ToString();
            //return base.ToString();
        }

        /// <summary>
        /// XML格式的单词列表
        /// </summary>
        /// <returns></returns>
        public XElement ToXElement()
        {
            //XElement[] elements = new XElement[this.Count];
            //int i = 0;
            //foreach (var v in this)
            //{
            //    elements[i] = v.ToXElement();
            //    i++;
            //}
            XElement result = new XElement(strTokenList,
                //elements);
                from tk in this
                select tk.ToXElement());
            return result;
        }
        /// <summary>
        /// public const string strTokenList = "TokenList";
        /// </summary>
        public const string strTokenList = "TokenList";
        */
    }
