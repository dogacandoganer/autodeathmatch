Ultima Online Custom Quest Script,

You can activate the quest at certain times or whenever you want.

PureMage,Warrior
AutoMage,Warrior
AutoMage,Warrior[DM]
PvM quest is available.

Also PlayMobile.cs plugin is as below.

using Server.Engines.Quests;

public enum EventType
{

PureMage,
PureWarrior,
PvM,
AutoMage,
AutoWarrior,
AutoPvM,
ATeamMage,
BTeamMage,
ATeamWarrior,
BTeamWarrior
}

also;

private int m_EventDeath;
private int m_EventKill;
private EventType m_EventType;

[CommandProperty(AccessLevel.GameMaster)]
public int EventKill
{
get { return m_EventKill; }
set { m_EventKill = value; InvalidateProperties(); }
}

[CommandProperty(AccessLevel.GameMaster)]
public int EventDeath
{
get { return m_EventDeath; }
set { m_EventDeath = value; InvalidateProperties(); }
}

If you add it, it will be a nice autoquest on your server.

Thanks.
