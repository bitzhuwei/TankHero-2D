using UnityEngine;
using System.Collections;

public class LevelLoader
{
    private static string[] levelsSourceCode = new string[]
    {
        #region level 1
@"
level
{
    
     tank{0 0} |
     tank{0 0} |
     tank{0 1} |
     tank{0 2} |
     tank{0 0} tank{0 1} tank{0 2} |
     tank{0 0} tank{0 1} tank{0 2} tank{0 0} tank{0 1} tank{0 2} |
     tank{0 0} tank{0 1} tank{0 2} tank{0 0} tank{0 1} tank{0 2} |
     tank{0 0} tank{0 1} tank{0 2} tank{0 0} tank{0 1} tank{0 2} tank{0 0} tank{0 1} tank{0 2} |
     tank{0 0} tank{0 1} tank{0 2} tank{0 0} tank{0 1} tank{0 2} tank{0 0} tank{0 1} tank{0 2} tank{0 0} tank{0 1} tank{0 2} 
}
",
        #endregion



    };

    private static Level[] levels;
    static LevelLoader()
    {
        levels = LoadLevels();
    }
    static Level[] LoadLevels()
    {
        return LoadLevels(LevelLoader.levelsSourceCode);
    }

    public static Level[] LoadLevels(string[] levels)
    {
        if (levels == null) { levels = LevelLoader.levelsSourceCode; }

        var result = new Level[levels.Length];
        for (int i = 0; i < result.Length; i++)
        {
            var lexi = new LexicalAnalyzerLevelCompiler(levels[i]);
            var tokens = lexi.Analyze();
            var parser = new LL1SyntaxParserLevelCompiler(tokens);
            var tree = parser.Parse();
            var value = tree.GetValue();
            result[i] = value;
        }

        return result;
    }


    public static Level GetLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levels.Length) { return null; }

        return levels[levelIndex];
    }
}
