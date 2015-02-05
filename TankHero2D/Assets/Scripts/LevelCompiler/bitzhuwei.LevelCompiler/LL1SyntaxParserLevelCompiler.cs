using System;

/// <summary>
/// LevelCompiler的LL1语法分析器
/// </summary>
public partial class LL1SyntaxParserLevelCompiler : LL1SyntaxParserBase<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
{
    #region 分析表中的元素

    /// <summary>
    /// 对 &lt;Level&gt; ::= &quot;level&quot;... 进行分析
    /// <para>&lt;Level&gt; ::= &quot;level&quot; &quot;{&quot; &lt;TankList&gt; &quot;}&quot;;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_Level___tail_levelLeave;
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;}&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= null;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_TankList___tail_rightBrace_Leave;
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;tank&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt;;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_TankList___tail_tankLeave;
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;|&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt;;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_TankList___tail_or_Leave;
    /// <summary>
    /// 对 &lt;Tank&gt; ::= &quot;tank&quot;... 进行分析
    /// <para>&lt;Tank&gt; ::= &quot;tank&quot; &quot;{&quot; &lt;TankPrefab&gt; &lt;BornPoint&gt; &quot;}&quot;;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_Tank___tail_tankLeave;
    /// <summary>
    /// 对 &lt;Tank&gt; ::= &quot;|&quot;... 进行分析
    /// <para>&lt;Tank&gt; ::= &quot;|&quot;;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_Tank___tail_or_Leave;
    /// <summary>
    /// 对 &lt;TankPrefab&gt; ::= number... 进行分析
    /// <para>&lt;TankPrefab&gt; ::= number;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_TankPrefab___numberLeave;
    /// <summary>
    /// 对 &lt;BornPoint&gt; ::= number... 进行分析
    /// <para>&lt;BornPoint&gt; ::= number;</para>
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsecase_BornPoint___numberLeave;

    /// <summary>
    /// 对 叶结点&quot;level&quot; 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsetail_levelLeave_;
    /// <summary>
    /// 对 叶结点&quot;{&quot; 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsetail_leftBrace_Leave_;
    /// <summary>
    /// 对 叶结点&quot;}&quot; 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsetail_rightBrace_Leave_;
    /// <summary>
    /// 对 叶结点null 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParseepsilonLeave_;
    /// <summary>
    /// 对 叶结点&quot;tank&quot; 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsetail_tankLeave_;
    /// <summary>
    /// 对 叶结点&quot;|&quot; 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsetail_or_Leave_;
    /// <summary>
    /// 对 叶结点number 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsenumberLeave_;
    /// <summary>
    /// 对 叶结点# 进行分析
    /// </summary>
    private static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        FuncParsetail_startEndLeave_;

    #endregion 分析表中的元素
    #region 用于分析栈操作的字段-终结点

    private static readonly EnumVTypeLevelCompiler m_tail_levelLeave = EnumVTypeLevelCompiler.tail_levelLeave;
    private static readonly EnumVTypeLevelCompiler m_tail_leftBrace_Leave = EnumVTypeLevelCompiler.tail_leftBrace_Leave;
    private static readonly EnumVTypeLevelCompiler m_tail_rightBrace_Leave = EnumVTypeLevelCompiler.tail_rightBrace_Leave;
    private static readonly EnumVTypeLevelCompiler m_epsilonLeave = EnumVTypeLevelCompiler.epsilonLeave;
    private static readonly EnumVTypeLevelCompiler m_tail_tankLeave = EnumVTypeLevelCompiler.tail_tankLeave;
    private static readonly EnumVTypeLevelCompiler m_tail_or_Leave = EnumVTypeLevelCompiler.tail_or_Leave;
    private static readonly EnumVTypeLevelCompiler m_numberLeave = EnumVTypeLevelCompiler.numberLeave;
    private static readonly EnumVTypeLevelCompiler m_tail_startEndLeave = EnumVTypeLevelCompiler.tail_startEndLeave;

    #endregion 用于分析栈操作的字段-终结点
    #region 用于分析栈操作的字段-非终结点

    private static readonly EnumVTypeLevelCompiler m_case_Level = EnumVTypeLevelCompiler.case_Level;
    private static readonly EnumVTypeLevelCompiler m_case_TankList = EnumVTypeLevelCompiler.case_TankList;
    private static readonly EnumVTypeLevelCompiler m_case_Tank = EnumVTypeLevelCompiler.case_Tank;
    private static readonly EnumVTypeLevelCompiler m_case_TankPrefab = EnumVTypeLevelCompiler.case_TankPrefab;
    private static readonly EnumVTypeLevelCompiler m_case_BornPoint = EnumVTypeLevelCompiler.case_BornPoint;

    #endregion 用于分析栈操作的字段-非终结点
    #region 获取分析表中的元素

    /// <summary>
    /// 对 &lt;Level&gt; ::= &quot;level&quot;... 进行分析
    /// <para>&lt;Level&gt; ::= &quot;level&quot; &quot;{&quot; &lt;TankList&gt; &quot;}&quot;;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_Level___tail_levelLeave()
    {
        return FuncParsecase_Level___tail_levelLeave;
    }
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;}&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= null;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_TankList___tail_rightBrace_Leave()
    {
        return FuncParsecase_TankList___tail_rightBrace_Leave;
    }
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;tank&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt;;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_TankList___tail_tankLeave()
    {
        return FuncParsecase_TankList___tail_tankLeave;
    }
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;|&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt;;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_TankList___tail_or_Leave()
    {
        return FuncParsecase_TankList___tail_or_Leave;
    }
    /// <summary>
    /// 对 &lt;Tank&gt; ::= &quot;tank&quot;... 进行分析
    /// <para>&lt;Tank&gt; ::= &quot;tank&quot; &quot;{&quot; &lt;TankPrefab&gt; &lt;BornPoint&gt; &quot;}&quot;;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_Tank___tail_tankLeave()
    {
        return FuncParsecase_Tank___tail_tankLeave;
    }
    /// <summary>
    /// 对 &lt;Tank&gt; ::= &quot;|&quot;... 进行分析
    /// <para>&lt;Tank&gt; ::= &quot;|&quot;;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_Tank___tail_or_Leave()
    {
        return FuncParsecase_Tank___tail_or_Leave;
    }
    /// <summary>
    /// 对 &lt;TankPrefab&gt; ::= number... 进行分析
    /// <para>&lt;TankPrefab&gt; ::= number;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_TankPrefab___numberLeave()
    {
        return FuncParsecase_TankPrefab___numberLeave;
    }
    /// <summary>
    /// 对 &lt;BornPoint&gt; ::= number... 进行分析
    /// <para>&lt;BornPoint&gt; ::= number;</para>
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsecase_BornPoint___numberLeave()
    {
        return FuncParsecase_BornPoint___numberLeave;
    }

    /// <summary>
    /// 对 叶结点&quot;level&quot; 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsetail_levelLeave_()
    {
        return FuncParsetail_levelLeave_;
    }
    /// <summary>
    /// 对 叶结点&quot;{&quot; 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsetail_leftBrace_Leave_()
    {
        return FuncParsetail_leftBrace_Leave_;
    }
    /// <summary>
    /// 对 叶结点&quot;}&quot; 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsetail_rightBrace_Leave_()
    {
        return FuncParsetail_rightBrace_Leave_;
    }
    /// <summary>
    /// 对 叶结点null 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParseepsilonLeave_()
    {
        return FuncParseepsilonLeave_;
    }
    /// <summary>
    /// 对 叶结点&quot;tank&quot; 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsetail_tankLeave_()
    {
        return FuncParsetail_tankLeave_;
    }
    /// <summary>
    /// 对 叶结点&quot;|&quot; 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsetail_or_Leave_()
    {
        return FuncParsetail_or_Leave_;
    }
    /// <summary>
    /// 对 叶结点number 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsenumberLeave_()
    {
        return FuncParsenumberLeave_;
    }
    /// <summary>
    /// 对 叶结点# 进行分析
    /// </summary>
    public static CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        GetFuncParsetail_startEndLeave_()
    {
        return FuncParsetail_startEndLeave_;
    }

    #endregion 获取分析表中的元素
    #region 分析表中的元素指向的分析函数

    /// <summary>
    /// 对 &lt;Level&gt; ::= &quot;level&quot;... 进行分析
    /// <para>&lt;Level&gt; ::= &quot;level&quot; &quot;{&quot; &lt;TankList&gt; &quot;}&quot;;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_Level___tail_levelLeave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <Level> ::= "level" "{" <TankList> "}";
        return Derivationcase_Level___tail_levelLeavetail_leftBrace_Leavecase_TankListtail_rightBrace_Leave(result, parser);
    }
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;}&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= null;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_TankList___tail_rightBrace_Leave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <TankList> ::= null;
        return Derivationcase_TankList___epsilonLeave(result, parser);
    }
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;tank&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt;;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_TankList___tail_tankLeave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <TankList> ::= <Tank> <TankList>;
        return Derivationcase_TankList___case_Tankcase_TankList(result, parser);
    }
    /// <summary>
    /// 对 &lt;TankList&gt; ::= &quot;|&quot;... 进行分析
    /// <para>&lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt;;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_TankList___tail_or_Leave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <TankList> ::= <Tank> <TankList>;
        return Derivationcase_TankList___case_Tankcase_TankList(result, parser);
    }
    /// <summary>
    /// 对 &lt;Tank&gt; ::= &quot;tank&quot;... 进行分析
    /// <para>&lt;Tank&gt; ::= &quot;tank&quot; &quot;{&quot; &lt;TankPrefab&gt; &lt;BornPoint&gt; &quot;}&quot;;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_Tank___tail_tankLeave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <Tank> ::= "tank" "{" <TankPrefab> <BornPoint> "}";
        return Derivationcase_Tank___tail_tankLeavetail_leftBrace_Leavecase_TankPrefabcase_BornPointtail_rightBrace_Leave(result, parser);
    }
    /// <summary>
    /// 对 &lt;Tank&gt; ::= &quot;|&quot;... 进行分析
    /// <para>&lt;Tank&gt; ::= &quot;|&quot;;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_Tank___tail_or_Leave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <Tank> ::= "|";
        return Derivationcase_Tank___tail_or_Leave(result, parser);
    }
    /// <summary>
    /// 对 &lt;TankPrefab&gt; ::= number... 进行分析
    /// <para>&lt;TankPrefab&gt; ::= number;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_TankPrefab___numberLeave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <TankPrefab> ::= number;
        return Derivationcase_TankPrefab___numberLeave(result, parser);
    }
    /// <summary>
    /// 对 &lt;BornPoint&gt; ::= number... 进行分析
    /// <para>&lt;BornPoint&gt; ::= number;</para>
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsecase_BornPoint___numberLeave(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        // <BornPoint> ::= number;
        return Derivationcase_BornPoint___numberLeave(result, parser);
    }

    /// <summary>
    /// 对 叶结点&quot;level&quot; 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsetail_levelLeave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.tail_levelLeave;
        result.NodeValue.NodeName = parserLevelCompiler.m_TokenListSource[parserLevelCompiler.m_ptNextToken].Detail;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ptNextToken++;
        result.MappedTokenLength = 1;
        parserLevelCompiler.m_ParserStack.Pop();
        return Next(result, parserLevelCompiler);
    }
    /// <summary>
    /// 对 叶结点&quot;{&quot; 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsetail_leftBrace_Leave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.tail_leftBrace_Leave;
        result.NodeValue.NodeName = parserLevelCompiler.m_TokenListSource[parserLevelCompiler.m_ptNextToken].Detail;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ptNextToken++;
        result.MappedTokenLength = 1;
        parserLevelCompiler.m_ParserStack.Pop();
        return Next(result, parserLevelCompiler);
    }
    /// <summary>
    /// 对 叶结点&quot;}&quot; 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsetail_rightBrace_Leave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.tail_rightBrace_Leave;
        result.NodeValue.NodeName = parserLevelCompiler.m_TokenListSource[parserLevelCompiler.m_ptNextToken].Detail;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ptNextToken++;
        result.MappedTokenLength = 1;
        parserLevelCompiler.m_ParserStack.Pop();
        return Next(result, parserLevelCompiler);
    }
    /// <summary>
    /// 对 叶结点null 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        ParseepsilonLeave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.epsilonLeave;
        result.NodeValue.NodeName = @"null";
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        result.MappedTokenLength = 0;
        parserLevelCompiler.m_ParserStack.Pop();
        return Next(result, parserLevelCompiler);
    }
    /// <summary>
    /// 对 叶结点&quot;tank&quot; 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsetail_tankLeave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.tail_tankLeave;
        result.NodeValue.NodeName = parserLevelCompiler.m_TokenListSource[parserLevelCompiler.m_ptNextToken].Detail;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ptNextToken++;
        result.MappedTokenLength = 1;
        parserLevelCompiler.m_ParserStack.Pop();
        return Next(result, parserLevelCompiler);
    }
    /// <summary>
    /// 对 叶结点&quot;|&quot; 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsetail_or_Leave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.tail_or_Leave;
        result.NodeValue.NodeName = parserLevelCompiler.m_TokenListSource[parserLevelCompiler.m_ptNextToken].Detail;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ptNextToken++;
        result.MappedTokenLength = 1;
        parserLevelCompiler.m_ParserStack.Pop();
        return Next(result, parserLevelCompiler);
    }
    /// <summary>
    /// 对 叶结点number 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        ParsenumberLeave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.numberLeave;
        result.NodeValue.NodeName = parserLevelCompiler.m_TokenListSource[parserLevelCompiler.m_ptNextToken].Detail;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ptNextToken++;
        result.MappedTokenLength = 1;
        parserLevelCompiler.m_ParserStack.Pop();
        return Next(result, parserLevelCompiler);
    }
    /// <summary>
    /// 对 叶结点# 进行分析
    /// <param name="result"></param>
    /// <param name="parser"></param>
    /// </summary>
    /// <returns></returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Parsetail_startEndLeave_(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result, ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        if (result != null)
        {
            result.NodeValue.NodeType = EnumVTypeLevelCompiler.tail_startEndLeave;
            result.NodeValue.NodeName = parserLevelCompiler.m_TokenListSource[parserLevelCompiler.m_ptNextToken].Detail;
            result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
            result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
            result.MappedTokenLength = 1;
        }
        parserLevelCompiler.m_ParserStack.Pop();
        parserLevelCompiler.m_ptNextToken++;
        return Next(result, parserLevelCompiler);
    }

    #endregion 分析表中的元素指向的分析函数
    #region 所有推导式的推导动作函数

    /// <summary>
    /// &lt;Level&gt; ::= &quot;level&quot; &quot;{&quot; &lt;TankList&gt; &quot;}&quot;;
    /// <summary>
    /// <param name="result">需要扩展的结点</param>
    /// <param name="parser">使用的分析器对象</param>
    /// <returns>下一个要扩展的结点</returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Derivationcase_Level___tail_levelLeavetail_leftBrace_Leavecase_TankListtail_rightBrace_Leave(
        SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result,
        ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {//<Level> ::= "level" "{" <TankList> "}";
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.case_Level;
        result.NodeValue.NodeName = EnumVTypeLevelCompiler.case_Level.ToString();
        //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ParserStack.Pop();
        // right-to-left push
        parserLevelCompiler.m_ParserStack.Push(m_tail_rightBrace_Leave);
        parserLevelCompiler.m_ParserStack.Push(m_case_TankList);
        parserLevelCompiler.m_ParserStack.Push(m_tail_leftBrace_Leave);
        parserLevelCompiler.m_ParserStack.Push(m_tail_levelLeave);
        // generate syntax tree
        var tail_levelLeaveTree0 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        tail_levelLeaveTree0.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        tail_levelLeaveTree0.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        tail_levelLeaveTree0.Parent = result;
        //tail_levelLeaveTree0.Value = new ProductionNode(EnumVTypeLevelCompiler.tail_levelLeave);
        result.Children.Add(tail_levelLeaveTree0);
        var tail_leftBrace_LeaveTree1 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        tail_leftBrace_LeaveTree1.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        tail_leftBrace_LeaveTree1.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        tail_leftBrace_LeaveTree1.Parent = result;
        //tail_leftBrace_LeaveTree1.Value = new ProductionNode(EnumVTypeLevelCompiler.tail_leftBrace_Leave);
        result.Children.Add(tail_leftBrace_LeaveTree1);
        var case_TankListTree2 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        case_TankListTree2.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        case_TankListTree2.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        case_TankListTree2.Parent = result;
        //case_TankListTree2.Value = new ProductionNode(EnumVTypeLevelCompiler.case_TankList);
        result.Children.Add(case_TankListTree2);
        var tail_rightBrace_LeaveTree3 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        tail_rightBrace_LeaveTree3.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        tail_rightBrace_LeaveTree3.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        tail_rightBrace_LeaveTree3.Parent = result;
        //tail_rightBrace_LeaveTree3.Value = new ProductionNode(EnumVTypeLevelCompiler.tail_rightBrace_Leave);
        result.Children.Add(tail_rightBrace_LeaveTree3);
        return tail_levelLeaveTree0;
    }//<Level> ::= "level" "{" <TankList> "}";
    /// <summary>
    /// &lt;TankList&gt; ::= &lt;Tank&gt; &lt;TankList&gt;;
    /// <summary>
    /// <param name="result">需要扩展的结点</param>
    /// <param name="parser">使用的分析器对象</param>
    /// <returns>下一个要扩展的结点</returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Derivationcase_TankList___case_Tankcase_TankList(
        SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result,
        ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {//<TankList> ::= <Tank> <TankList>;
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.case_TankList;
        result.NodeValue.NodeName = EnumVTypeLevelCompiler.case_TankList.ToString();
        //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ParserStack.Pop();
        // right-to-left push
        parserLevelCompiler.m_ParserStack.Push(m_case_TankList);
        parserLevelCompiler.m_ParserStack.Push(m_case_Tank);
        // generate syntax tree
        var case_TankTree0 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        case_TankTree0.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        case_TankTree0.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        case_TankTree0.Parent = result;
        //case_TankTree0.Value = new ProductionNode(EnumVTypeLevelCompiler.case_Tank);
        result.Children.Add(case_TankTree0);
        var case_TankListTree1 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        case_TankListTree1.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        case_TankListTree1.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        case_TankListTree1.Parent = result;
        //case_TankListTree1.Value = new ProductionNode(EnumVTypeLevelCompiler.case_TankList);
        result.Children.Add(case_TankListTree1);
        return case_TankTree0;
    }//<TankList> ::= <Tank> <TankList>;
    /// <summary>
    /// &lt;TankList&gt; ::= null;
    /// <summary>
    /// <param name="result">需要扩展的结点</param>
    /// <param name="parser">使用的分析器对象</param>
    /// <returns>下一个要扩展的结点</returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Derivationcase_TankList___epsilonLeave(
        SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result,
        ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {//<TankList> ::= null;
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.case_TankList;
        result.NodeValue.NodeName = EnumVTypeLevelCompiler.case_TankList.ToString();
        //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ParserStack.Pop();
        // right-to-left push
        parserLevelCompiler.m_ParserStack.Push(m_epsilonLeave);
        // generate syntax tree
        var epsilonLeaveTree0 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        epsilonLeaveTree0.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        epsilonLeaveTree0.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        epsilonLeaveTree0.Parent = result;
        //epsilonLeaveTree0.Value = new ProductionNode(EnumVTypeLevelCompiler.epsilonLeave);
        result.Children.Add(epsilonLeaveTree0);
        return epsilonLeaveTree0;
    }//<TankList> ::= null;
    /// <summary>
    /// &lt;Tank&gt; ::= &quot;tank&quot; &quot;{&quot; &lt;TankPrefab&gt; &lt;BornPoint&gt; &quot;}&quot;;
    /// <summary>
    /// <param name="result">需要扩展的结点</param>
    /// <param name="parser">使用的分析器对象</param>
    /// <returns>下一个要扩展的结点</returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Derivationcase_Tank___tail_tankLeavetail_leftBrace_Leavecase_TankPrefabcase_BornPointtail_rightBrace_Leave(
        SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result,
        ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {//<Tank> ::= "tank" "{" <TankPrefab> <BornPoint> "}";
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.case_Tank;
        result.NodeValue.NodeName = EnumVTypeLevelCompiler.case_Tank.ToString();
        //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ParserStack.Pop();
        // right-to-left push
        parserLevelCompiler.m_ParserStack.Push(m_tail_rightBrace_Leave);
        parserLevelCompiler.m_ParserStack.Push(m_case_BornPoint);
        parserLevelCompiler.m_ParserStack.Push(m_case_TankPrefab);
        parserLevelCompiler.m_ParserStack.Push(m_tail_leftBrace_Leave);
        parserLevelCompiler.m_ParserStack.Push(m_tail_tankLeave);
        // generate syntax tree
        var tail_tankLeaveTree0 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        tail_tankLeaveTree0.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        tail_tankLeaveTree0.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        tail_tankLeaveTree0.Parent = result;
        //tail_tankLeaveTree0.Value = new ProductionNode(EnumVTypeLevelCompiler.tail_tankLeave);
        result.Children.Add(tail_tankLeaveTree0);
        var tail_leftBrace_LeaveTree1 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        tail_leftBrace_LeaveTree1.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        tail_leftBrace_LeaveTree1.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        tail_leftBrace_LeaveTree1.Parent = result;
        //tail_leftBrace_LeaveTree1.Value = new ProductionNode(EnumVTypeLevelCompiler.tail_leftBrace_Leave);
        result.Children.Add(tail_leftBrace_LeaveTree1);
        var case_TankPrefabTree2 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        case_TankPrefabTree2.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        case_TankPrefabTree2.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        case_TankPrefabTree2.Parent = result;
        //case_TankPrefabTree2.Value = new ProductionNode(EnumVTypeLevelCompiler.case_TankPrefab);
        result.Children.Add(case_TankPrefabTree2);
        var case_BornPointTree3 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        case_BornPointTree3.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        case_BornPointTree3.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        case_BornPointTree3.Parent = result;
        //case_BornPointTree3.Value = new ProductionNode(EnumVTypeLevelCompiler.case_BornPoint);
        result.Children.Add(case_BornPointTree3);
        var tail_rightBrace_LeaveTree4 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        tail_rightBrace_LeaveTree4.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        tail_rightBrace_LeaveTree4.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        tail_rightBrace_LeaveTree4.Parent = result;
        //tail_rightBrace_LeaveTree4.Value = new ProductionNode(EnumVTypeLevelCompiler.tail_rightBrace_Leave);
        result.Children.Add(tail_rightBrace_LeaveTree4);
        return tail_tankLeaveTree0;
    }//<Tank> ::= "tank" "{" <TankPrefab> <BornPoint> "}";
    /// <summary>
    /// &lt;Tank&gt; ::= &quot;|&quot;;
    /// <summary>
    /// <param name="result">需要扩展的结点</param>
    /// <param name="parser">使用的分析器对象</param>
    /// <returns>下一个要扩展的结点</returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Derivationcase_Tank___tail_or_Leave(
        SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result,
        ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {//<Tank> ::= "|";
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.case_Tank;
        result.NodeValue.NodeName = EnumVTypeLevelCompiler.case_Tank.ToString();
        //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ParserStack.Pop();
        // right-to-left push
        parserLevelCompiler.m_ParserStack.Push(m_tail_or_Leave);
        // generate syntax tree
        var tail_or_LeaveTree0 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        tail_or_LeaveTree0.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        tail_or_LeaveTree0.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        tail_or_LeaveTree0.Parent = result;
        //tail_or_LeaveTree0.Value = new ProductionNode(EnumVTypeLevelCompiler.tail_or_Leave);
        result.Children.Add(tail_or_LeaveTree0);
        return tail_or_LeaveTree0;
    }//<Tank> ::= "|";
    /// <summary>
    /// &lt;TankPrefab&gt; ::= number;
    /// <summary>
    /// <param name="result">需要扩展的结点</param>
    /// <param name="parser">使用的分析器对象</param>
    /// <returns>下一个要扩展的结点</returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Derivationcase_TankPrefab___numberLeave(
        SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result,
        ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {//<TankPrefab> ::= number;
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.case_TankPrefab;
        result.NodeValue.NodeName = EnumVTypeLevelCompiler.case_TankPrefab.ToString();
        //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ParserStack.Pop();
        // right-to-left push
        parserLevelCompiler.m_ParserStack.Push(m_numberLeave);
        // generate syntax tree
        var numberLeaveTree0 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        numberLeaveTree0.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        numberLeaveTree0.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        numberLeaveTree0.Parent = result;
        //numberLeaveTree0.Value = new ProductionNode(EnumVTypeLevelCompiler.numberLeave);
        result.Children.Add(numberLeaveTree0);
        return numberLeaveTree0;
    }//<TankPrefab> ::= number;
    /// <summary>
    /// &lt;BornPoint&gt; ::= number;
    /// <summary>
    /// <param name="result">需要扩展的结点</param>
    /// <param name="parser">使用的分析器对象</param>
    /// <returns>下一个要扩展的结点</returns>
    private static SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>
        Derivationcase_BornPoint___numberLeave(
        SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> result,
        ISyntaxParser<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> parser)
    {//<BornPoint> ::= number;
        var parserLevelCompiler = parser as LL1SyntaxParserLevelCompiler;
        result.NodeValue.NodeType = EnumVTypeLevelCompiler.case_BornPoint;
        result.NodeValue.NodeName = EnumVTypeLevelCompiler.case_BornPoint.ToString();
        //result.NodeValue.Position = EnumProductionNodePosition.NonLeave;
        result.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        result.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        parserLevelCompiler.m_ParserStack.Pop();
        // right-to-left push
        parserLevelCompiler.m_ParserStack.Push(m_numberLeave);
        // generate syntax tree
        var numberLeaveTree0 = new SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>();
        numberLeaveTree0.MappedTotalTokenList = parserLevelCompiler.m_TokenListSource;
        numberLeaveTree0.MappedTokenStartIndex = parserLevelCompiler.m_ptNextToken;
        numberLeaveTree0.Parent = result;
        //numberLeaveTree0.Value = new ProductionNode(EnumVTypeLevelCompiler.numberLeave);
        result.Children.Add(numberLeaveTree0);
        return numberLeaveTree0;
    }//<BornPoint> ::= number;

    #endregion 所有推导式的推导动作函数
    #region FillMapCells()

    private void FillMapCells()
    {
        m_Map.SetCell(EnumVTypeLevelCompiler.case_Level, EnumTokenTypeLevelCompiler.token_level, FuncParsecase_Level___tail_levelLeave);
        m_Map.SetCell(EnumVTypeLevelCompiler.case_TankList, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsecase_TankList___tail_rightBrace_Leave);
        m_Map.SetCell(EnumVTypeLevelCompiler.case_TankList, EnumTokenTypeLevelCompiler.token_tank, FuncParsecase_TankList___tail_tankLeave);
        m_Map.SetCell(EnumVTypeLevelCompiler.case_TankList, EnumTokenTypeLevelCompiler.token_Or_, FuncParsecase_TankList___tail_or_Leave);
        m_Map.SetCell(EnumVTypeLevelCompiler.case_Tank, EnumTokenTypeLevelCompiler.token_tank, FuncParsecase_Tank___tail_tankLeave);
        m_Map.SetCell(EnumVTypeLevelCompiler.case_Tank, EnumTokenTypeLevelCompiler.token_Or_, FuncParsecase_Tank___tail_or_Leave);
        m_Map.SetCell(EnumVTypeLevelCompiler.case_TankPrefab, EnumTokenTypeLevelCompiler.number, FuncParsecase_TankPrefab___numberLeave);
        m_Map.SetCell(EnumVTypeLevelCompiler.case_BornPoint, EnumTokenTypeLevelCompiler.number, FuncParsecase_BornPoint___numberLeave);

        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.token_level, FuncParsetail_levelLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParsetail_levelLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsetail_levelLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.epsilon, FuncParsetail_levelLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.token_tank, FuncParsetail_levelLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.token_Or_, FuncParsetail_levelLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.number, FuncParsetail_levelLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_levelLeave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParsetail_levelLeave_);

        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.token_level, FuncParsetail_leftBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParsetail_leftBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsetail_leftBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.epsilon, FuncParsetail_leftBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.token_tank, FuncParsetail_leftBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.token_Or_, FuncParsetail_leftBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.number, FuncParsetail_leftBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_leftBrace_Leave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParsetail_leftBrace_Leave_);

        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.token_level, FuncParsetail_rightBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParsetail_rightBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsetail_rightBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.epsilon, FuncParsetail_rightBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.token_tank, FuncParsetail_rightBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.token_Or_, FuncParsetail_rightBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.number, FuncParsetail_rightBrace_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_rightBrace_Leave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParsetail_rightBrace_Leave_);

        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.token_level, FuncParseepsilonLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParseepsilonLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParseepsilonLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.epsilon, FuncParseepsilonLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.token_tank, FuncParseepsilonLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.token_Or_, FuncParseepsilonLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.number, FuncParseepsilonLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.epsilonLeave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParseepsilonLeave_);

        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.token_level, FuncParsetail_tankLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParsetail_tankLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsetail_tankLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.epsilon, FuncParsetail_tankLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.token_tank, FuncParsetail_tankLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.token_Or_, FuncParsetail_tankLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.number, FuncParsetail_tankLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_tankLeave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParsetail_tankLeave_);

        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.token_level, FuncParsetail_or_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParsetail_or_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsetail_or_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.epsilon, FuncParsetail_or_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.token_tank, FuncParsetail_or_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.token_Or_, FuncParsetail_or_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.number, FuncParsetail_or_Leave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_or_Leave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParsetail_or_Leave_);

        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.token_level, FuncParsenumberLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParsenumberLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsenumberLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.epsilon, FuncParsenumberLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.token_tank, FuncParsenumberLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.token_Or_, FuncParsenumberLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.number, FuncParsenumberLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.numberLeave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParsenumberLeave_);

        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.token_level, FuncParsetail_startEndLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.token_LeftBrace_, FuncParsetail_startEndLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.token_RightBrace_, FuncParsetail_startEndLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.epsilon, FuncParsetail_startEndLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.token_tank, FuncParsetail_startEndLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.token_Or_, FuncParsetail_startEndLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.number, FuncParsetail_startEndLeave_);
        m_Map.SetCell(EnumVTypeLevelCompiler.tail_startEndLeave, EnumTokenTypeLevelCompiler.token_startEnd, FuncParsetail_startEndLeave_);
    }

    #endregion FillMapCells()
    #region 为分析表中的元素配置分析函数

    private void InitFunc()
    {
        FuncParsecase_Level___tail_levelLeave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_Level___tail_levelLeave);
        FuncParsecase_TankList___tail_rightBrace_Leave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_TankList___tail_rightBrace_Leave);
        FuncParsecase_TankList___tail_tankLeave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_TankList___tail_tankLeave);
        FuncParsecase_TankList___tail_or_Leave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_TankList___tail_or_Leave);
        FuncParsecase_Tank___tail_tankLeave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_Tank___tail_tankLeave);
        FuncParsecase_Tank___tail_or_Leave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_Tank___tail_or_Leave);
        FuncParsecase_TankPrefab___numberLeave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_TankPrefab___numberLeave);
        FuncParsecase_BornPoint___numberLeave =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsecase_BornPoint___numberLeave);

        FuncParsetail_levelLeave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsetail_levelLeave_);
        FuncParsetail_leftBrace_Leave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsetail_leftBrace_Leave_);
        FuncParsetail_rightBrace_Leave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsetail_rightBrace_Leave_);
        FuncParseepsilonLeave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(ParseepsilonLeave_);
        FuncParsetail_tankLeave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsetail_tankLeave_);
        FuncParsetail_or_Leave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsetail_or_Leave_);
        FuncParsenumberLeave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(ParsenumberLeave_);
        FuncParsetail_startEndLeave_ =
            new CandidateFunction<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler>(Parsetail_startEndLeave_);
    }

    #endregion 为分析表中的元素配置分析函数
    /// <summary>
    /// 初始化LL(1)分析表
    /// </summary>
    public override void InitMap()
    {
        InitFunc();
        // init parser map
        SetMapLinesAndColumns();
        FillMapCells();
    }
    /// <summary>
    /// LL1SyntaxParserLevelCompiler的语法分析器
    /// </summary>
    public LL1SyntaxParserLevelCompiler()
        : base(13, 8) { }
    /// LL1SyntaxParserLevelCompiler的语法分析器
    /// </summary>
    /// <param name="tokens">要分析的单词列表</param>
    public LL1SyntaxParserLevelCompiler(TokenList<EnumTokenTypeLevelCompiler> tokens)
        : base(13, 8)
    {
        m_TokenListSource = tokens;
    }
    #region 重置语法分析器到初始状态，这样就可以重新对上次分析过的单词列表进行分析

    /// <summary>
    /// 重置语法分析器到初始状态，这样就可以重新对上次分析过的单词列表进行分析
    /// </summary>
    public override void Reset()
    {
        m_ptNextToken = 0;
        m_ParserStack.Clear();
        m_ParserStack.Push(m_tail_startEndLeave);
        m_ParserStack.Push(m_case_Level);
        if (m_TokenListSource.Count == 0)
        {
            var newToken = new Token<EnumTokenTypeLevelCompiler>()
            {
                Detail = "#",
                Line = 0,
                Column = 0,
                IndexOfSourceCode = 0,
                Length = 1,
                LexicalError = false,
                TokenType = EnumTokenTypeLevelCompiler.token_startEnd
            };
            m_TokenListSource.Add(newToken);
        }
        else
        {
            var token = m_TokenListSource[m_TokenListSource.Count - 1];
            {
                var newToken = new Token<EnumTokenTypeLevelCompiler>()
                {
                    Detail = "#",
                    Line = token.Line,
                    Column = token.Column + token.Length + 1,
                    IndexOfSourceCode = token.IndexOfSourceCode + token.Length + 1,
                    Length = 1,
                    LexicalError = false,
                    TokenType = EnumTokenTypeLevelCompiler.token_startEnd
                };
                m_TokenListSource.Add(newToken);
            }
        }
    }

    #endregion 重置语法分析器到初始状态，这样就可以重新对上次分析过的单词列表进行分析
    #region SetMapLinesAndColumns()

    private void SetMapLinesAndColumns()
    {
        m_Map.SetLine(0, EnumVTypeLevelCompiler.case_Level);
        m_Map.SetLine(1, EnumVTypeLevelCompiler.case_TankList);
        m_Map.SetLine(2, EnumVTypeLevelCompiler.case_Tank);
        m_Map.SetLine(3, EnumVTypeLevelCompiler.case_TankPrefab);
        m_Map.SetLine(4, EnumVTypeLevelCompiler.case_BornPoint);

        m_Map.SetLine(5, EnumVTypeLevelCompiler.tail_levelLeave);
        m_Map.SetLine(6, EnumVTypeLevelCompiler.tail_leftBrace_Leave);
        m_Map.SetLine(7, EnumVTypeLevelCompiler.tail_rightBrace_Leave);
        m_Map.SetLine(8, EnumVTypeLevelCompiler.epsilonLeave);
        m_Map.SetLine(9, EnumVTypeLevelCompiler.tail_tankLeave);
        m_Map.SetLine(10, EnumVTypeLevelCompiler.tail_or_Leave);
        m_Map.SetLine(11, EnumVTypeLevelCompiler.numberLeave);
        m_Map.SetLine(12, EnumVTypeLevelCompiler.tail_startEndLeave);


        m_Map.SetColumn(0, EnumTokenTypeLevelCompiler.token_level);
        m_Map.SetColumn(1, EnumTokenTypeLevelCompiler.token_LeftBrace_);
        m_Map.SetColumn(2, EnumTokenTypeLevelCompiler.token_RightBrace_);
        m_Map.SetColumn(3, EnumTokenTypeLevelCompiler.epsilon);
        m_Map.SetColumn(4, EnumTokenTypeLevelCompiler.token_tank);
        m_Map.SetColumn(5, EnumTokenTypeLevelCompiler.token_Or_);
        m_Map.SetColumn(6, EnumTokenTypeLevelCompiler.number);
        m_Map.SetColumn(7, EnumTokenTypeLevelCompiler.token_startEnd);
    }

    #endregion SetMapLinesAndColumns()
}


