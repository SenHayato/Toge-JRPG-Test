using UnityEngine;

public class EnumList
{    }

public enum SkillTargetType
{
    SingleEnemy, MultipleEnemy, Area, SingleAlly, Self, MultipleAlly, Guard
}

public enum SkillType
{
    Attack, Heal, Mana, Guard
}

public enum SkillTarget
{
    Ally, Enemy
}

public enum SkillPosition
{
    Still, MoveToTarget
}

public enum QTEType
{
    Mash, Time, NoNeed
}

public enum GameState
{
    Exploration, Battle, Dialog, Cutscene
}

public enum CharactherInState
{
    Idle, Move, Hurt, Attack, Dead
}

public enum BattleInProgress
{
    BattleStart, PlayerTurn, EnemyTurn, ActionState, Victory, Defeat, BattleEnd, CheckBattle
}
