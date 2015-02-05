using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

public static partial class GetLevel
{
    public static Level GetValue(this SyntaxTree<EnumTokenTypeLevelCompiler,
        EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> syntaxTree)
    {
        if (syntaxTree == null) { return null; }

        var result = new Level();
        _GetLevel(result, syntaxTree);
        return result;
    }

    private static void _GetLevel(Level result, SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> syntaxTree)
    {
        if (syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_Level___tail_levelLeave())
        {
            GetTankList(result, syntaxTree.Children[2]);
        }
    }

    private static void GetTankList(Level level, SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> syntaxTree)
    {
        if (syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_TankList___tail_tankLeave()
            || syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_TankList___tail_or_Leave())
        {
            var egg = GetTank(syntaxTree.Children[0]);
            level.Add(egg);
            GetTankList(level, syntaxTree.Children[1]);
        }
        else if (syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_TankList___tail_rightBrace_Leave())
        {
            //nothing to do
        }

    }

    private static TankEgg GetTank(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> syntaxTree)
    {
        if (syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_Tank___tail_tankLeave())
        {
            var tankPrefab = GetTankPrefab(syntaxTree.Children[2]);
            var bornPoint = GetBornPoint(syntaxTree.Children[3]);
            var result = new TankEgg(tankPrefab, bornPoint);
            return result;
        }
        else if (syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_Tank___tail_or_Leave())
        {
            var result = new TankEgg(-1, -1);
            return result;
        }

        return null;
    }

    private static int GetBornPoint(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> syntaxTree)
    {
        if (syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_BornPoint___numberLeave())
        {
            var result = int.Parse(syntaxTree.Children[0].NodeValue.NodeName);
            return result;
        }

        return 0;
    }

    private static int GetTankPrefab(SyntaxTree<EnumTokenTypeLevelCompiler, EnumVTypeLevelCompiler, TreeNodeValueLevelCompiler> syntaxTree)
    {
        if (syntaxTree.CandidateFunc == LL1SyntaxParserLevelCompiler.GetFuncParsecase_TankPrefab___numberLeave())
        {
            var result = int.Parse(syntaxTree.Children[0].NodeValue.NodeName);
            return result;
        }

        return 0;
    }
}
