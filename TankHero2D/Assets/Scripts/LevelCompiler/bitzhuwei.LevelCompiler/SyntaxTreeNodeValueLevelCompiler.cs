/// <summary>
/// 文法LevelCompiler的语法树结点的值
/// </summary>
public class TreeNodeValueLevelCompiler : System.ICloneable
{
    private string m_NodeName = string.Empty;
    /// <summary>
    /// 结点名称
    /// </summary>
    public string NodeName
    {
        get { return m_NodeName; }
        set { m_NodeName = value; }
    }
    private EnumVTypeLevelCompiler m_NodeType = EnumVTypeLevelCompiler.Unknown;
    /// <summary>
    /// 结点类型
    /// </summary>
    public EnumVTypeLevelCompiler NodeType
    {
        get { return m_NodeType; }
        set { m_NodeType = value; }
    }
    /// <summary>
    /// "名称, 类型"
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return string.Format("{0}, {1}", m_NodeName, m_NodeType);
    }
    public object Clone()
    {
        var result = new TreeNodeValueLevelCompiler();
        result.NodeName = this.NodeName;
        result.NodeType = this.NodeType;
        return result;
    }
}


