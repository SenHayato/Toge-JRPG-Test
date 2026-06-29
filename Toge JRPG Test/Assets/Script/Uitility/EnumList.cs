using UnityEngine;

public class EnumList
{    }

public enum SkillTargetType
{
    Single, Multiple, Area
}

public enum QTEType
{
    Mash, Time
}

public enum GameState
{
    Exploration, Battle, Dialog, Cutscene
}

public enum PlayerInState
{
    Idle, Walk, Hurt, Attack, Dead
}

public enum BattleInProgress
{
    BattleStart, PlayerTurn, EnemyTurn, ActionState, Victory, Defeat, BattleEnd
}
