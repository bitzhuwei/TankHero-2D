    /// <summary>
    /// 文法LevelCompiler的语法树结点枚举类型
    /// </summary>
    public enum EnumVTypeLevelCompiler
    {
        /// <summary>
        /// 未知的语法结点符号
        /// </summary>
        Unknown,
        /// <summary>
        /// &lt;Level&gt; ::= &quot;level&quot; &quot;{&quot; &lt;TankList&gt; &quot;}&quot;;
        /// </summary>
        case_Level,
        /// <summary>
        /// &lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt; | null;
        /// </summary>
        case_TankList,
        /// <summary>
        /// &lt;Tank&gt; ::= &quot;tank&quot; &quot;{&quot; &lt;TankPrefab&gt; &lt;BornPoint&gt; &quot;}&quot; | &quot;|&quot;;
        /// </summary>
        case_Tank,
        /// <summary>
        /// &lt;TankPrefab&gt; ::= number;
        /// </summary>
        case_TankPrefab,
        /// <summary>
        /// &lt;BornPoint&gt; ::= number;
        /// </summary>
        case_BornPoint,
        /// <summary>
        /// &quot;level&quot;
        /// </summary>
        tail_levelLeave,
        /// <summary>
        /// &quot;{&quot;
        /// </summary>
        tail_leftBrace_Leave,
        /// <summary>
        /// &quot;}&quot;
        /// </summary>
        tail_rightBrace_Leave,
        /// <summary>
        /// null
        /// </summary>
        epsilonLeave,
        /// <summary>
        /// &quot;tank&quot;
        /// </summary>
        tail_tankLeave,
        /// <summary>
        /// &quot;|&quot;
        /// </summary>
        tail_or_Leave,
        /// <summary>
        /// number
        /// </summary>
        numberLeave,
        /// <summary>
        /// #
        /// </summary>
        tail_startEndLeave,
    }

