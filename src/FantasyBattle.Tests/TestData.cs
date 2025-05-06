using System.Collections.Generic;

namespace FantasyBattle.Tests;

public static class TestData
{
    public static BasicItem shield = new BasicItem("round shield", 0, 1.4f);
    public static BasicItem sword = new BasicItem("Flashy sword of danger", 10, 1.0f);
    public static BasicItem excalibur = new BasicItem("Excalibur", 20, 1.5f);
    public static BasicItem helmet = new BasicItem("helmet of swiftness", 0, 1.2f);
    public static BasicItem boots = new BasicItem("ten league boots", 0, 0.1f);
    public static BasicItem breastplate = new BasicItem("breastplate of steel", 0, 1.4f);
    public static SimpleEnemy enemy = new SimpleEnemy(
        new SimpleArmor(5), 
        new List<Buff>() {new BasicBuff(1.0f, 1.0f)}
    );
}