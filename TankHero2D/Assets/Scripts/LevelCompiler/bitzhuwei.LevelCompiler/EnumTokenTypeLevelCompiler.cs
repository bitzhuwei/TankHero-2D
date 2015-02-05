    /// <summary>
    /// 文法LevelCompiler的单词枚举类型
    /// </summary>
    public enum EnumTokenTypeLevelCompiler
    {
        /// <summary>
        /// 未知的单词符号
        /// </summary>
        unknown,
        /// <summary>
        /// &quot;level&quot;
        /// </summary>
        token_level,
        /// <summary>
        /// &quot;{&quot;
        /// </summary>
        token_LeftBrace_,
        /// <summary>
        /// &quot;}&quot;
        /// </summary>
        token_RightBrace_,
        /// <summary>
        /// null
        /// </summary>
        epsilon,
        /// <summary>
        /// &quot;tank&quot;
        /// </summary>
        token_tank,
        /// <summary>
        /// &quot;|&quot;
        /// </summary>
        token_Or_,
        /// <summary>
        /// number
        /// </summary>
        number,
        /// <summary>
        /// #
        /// </summary>
        token_startEnd,
        /// <summary>
        /// 标识符
        /// </summary>
        identifier,
    }

