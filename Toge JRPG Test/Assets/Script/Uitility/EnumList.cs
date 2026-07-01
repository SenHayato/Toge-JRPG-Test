using UnityEngine;

public class EnumList
{    }

public enum SkillTargetType
{
    SingleEnemy, MultipleEnemy, Area, SingleAlly, Self, MultipleAlly
}

public enum SkillPosition
{
    Still, MoveToTarget
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
    BattleStart, PlayerTurn, EnemyTurn, ActionState, Victory, Defeat, BattleEnd, CheckBattle
}

public enum BossInState
{
    Idle, Attack, Hurt, Dead, Walk
}
