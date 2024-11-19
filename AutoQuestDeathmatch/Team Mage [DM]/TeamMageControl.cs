/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections; 
using Server.Prompts;
using Server.Misc; 
using Server.Gumps;
using Server.Network;
using Server.Multis;
using Server.ContextMenus;
using Server.DeathMatch;
using Server.EventScoreBoard;
using Server.Spells;

namespace Server.DeathMatch
{	
	public class TeamMageControl : Item
	{
		public static void Initialize()
		{
			EventSink.PlayerDeath += new PlayerDeathEventHandler(OnPlayerDeath);
		}		
		
		public static int m_Reward;
		public static int m_ATeamPoints;
		public static int m_BTeamPoints;
		public static int m_TeamFinishPoints;
		public static bool m_Running;	
		public static Point3D m_ATeamArena;
		public static Point3D m_BTeamArena;
		public static Point3D m_StaffPoint;
		public static Map m_StaffMap;
		public static Map m_TeamArenaMap;
		
		
		public static Point3D m_ExitPoint;
		public static Map m_ExitMap;
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static int Reward
		{
			get { return m_Reward; }
			set { m_Reward = value; }
		}
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static int ATeamPoints
		{
			get { return m_ATeamPoints; }
			set { m_ATeamPoints = value; }
		}
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static int BTeamPoints
		{
			get { return m_BTeamPoints; }
			set { m_BTeamPoints = value; }
		}
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static int TeamFinishPoints
		{
			get { return m_TeamFinishPoints; }
			set { m_TeamFinishPoints = value; }
		}
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static bool Running
		{
			get { return m_Running; }
			set {m_Running = value; }
		}
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Point3D ExitPoint
        {
            get { return m_ExitPoint; }
            set { m_ExitPoint = value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Point3D ATeamArena
        {
            get { return m_ATeamArena; }
            set { m_ATeamArena = value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Point3D BTeamArena
        {
            get { return m_BTeamArena; }
            set { m_BTeamArena = value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Point3D StaffPoint
        {
            get { return m_StaffPoint; }
            set { m_StaffPoint = value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Map StaffMap
        {
            get { return m_StaffMap; }
            set { m_StaffMap= value; }
        }
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Map TeamArenaMap
        {
            get { return m_TeamArenaMap; }
            set { m_TeamArenaMap = value; }
        }		
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Map ExitMap
        {
            get { return m_ExitMap; }
            set { m_ExitMap = value; }
        }	
		
		[Constructable]
		public TeamMageControl(): base ( 3796 )
		{
			this.Hue = 63;
			this.Movable = false;
			this.Name = "Team Mage Kontrol Taþý";
		}
		
		public static void HandleCorpse(Mobile from)
		{
			if (from.Corpse != null)
			{
				Corpse c = (Corpse)from.Corpse;
				c.Delete();
			}
		}

		public static void FinishGame()
		{
			ArrayList items = new ArrayList( World.Items.Values );
			foreach( Item i in items )
					
			if( i != null )
			{						
				if(( i is EventRobe )&&( i != null ))
				{
					i.Delete();
				}
							
				if(( i is EventLantern)&&( i != null ))
				{
					i.Delete();
				}
				
				if(( i is FullSpellBook)&&( i != null ))
				{
					if( i.Hue == 3 || i.Hue == 38 )
					{
						i.Delete();
					}
				}
			}
			
			ArrayList mobs = new ArrayList( World.Mobiles.Values );
			foreach(Mobile m in mobs )
			{
				PlayerMobile pm = null;
				if(m is PlayerMobile)
				{
					pm = m as PlayerMobile;
				}
					
				if(pm != null && (pm.EventType == EventType.ATeamMage || pm.EventType == EventType.BTeamMage ))
				{
					pm.MoveToWorld( m_ExitPoint, m_ExitMap );
					pm.EventType = EventType.None;
					pm.EventDeath = 0;
					pm.EventKill = 0;
				}
			}
			TeamMageControl.m_Running = false;
			TeamMageControl.ATeamPoints = 0;
			TeamMageControl.BTeamPoints = 0;
		}
		
		private static void OnPlayerDeath(PlayerDeathEventArgs e)
		{	
			PlayerMobile pd = e.Mobile as PlayerMobile;
			
			if ( pd != null && pd.EventType == EventType.ATeamMage )
			{
				pd.Resurrect();
				if( pd.LastKiller != null )
				{
					TeamMageControl.BTeamPoints += 1;
				}
				
				pd.Blessed = true;
				new BlessedTimer(pd).Start();
				HandleCorpse(pd);
				
				if( pd.LastKiller != null )
				{
					PlayerMobile lb = pd.LastKiller as PlayerMobile;
					
					if( lb.EventType == EventType.BTeamMage )
					{
						lb.SendMessage( 1161,"+1," );					
						lb.SendMessage( 1161,"A-Takým Puaný <> {0}", TeamMageControl.ATeamPoints );
						lb.SendMessage( 1161,"B-Takým Puaný <> {0}", TeamMageControl.BTeamPoints );
						lb.SendMessage( 1161,"Son Puanlar  <> {0}", TeamMageControl.TeamFinishPoints );
					}
				}
				
				if( TeamMageControl.BTeamPoints < TeamMageControl.TeamFinishPoints )
				{
				}
				
				if( TeamMageControl.BTeamPoints >= TeamMageControl.TeamFinishPoints )
				{
					World.Broadcast( 1153, false,"B-Takýmý Turnuvayý Kazanmýþtýr.");
					
					ArrayList mobs = new ArrayList( World.Mobiles.Values );
					foreach(Mobile m in mobs )
					{
						PlayerMobile pm = null;
						if(m is PlayerMobile)
						{
							pm = m as PlayerMobile;
						}
					
						if( pm != null && pm.EventType == EventType.BTeamMage )
						{
							pm.AddToBackpack( new BankCheck(250000));
						}
					}
					FinishGame();
				}
			}
			
			if (pd != null && pd.EventType == EventType.BTeamMage )
			{
				pd.Resurrect();
				if( pd.LastKiller != null )
				{
					TeamMageControl.ATeamPoints += 1;
				}
				pd.Blessed = true;
				new BlessedTimer(pd).Start();
				HandleCorpse(pd);
	
				if( pd.LastKiller != null )
				{
					PlayerMobile la = pd.LastKiller as PlayerMobile;
					
					if( la.EventType == EventType.ATeamMage )
					{
						la.SendMessage( 1161,"+1," );
						la.SendMessage( 1161,"A-Takým Puaný <> {0}", TeamMageControl.ATeamPoints );
						la.SendMessage( 1161,"B-Takým Puaný <> {0}", TeamMageControl.BTeamPoints );
						la.SendMessage( 1161,"Son Puanlar  <>  {0}", TeamMageControl.TeamFinishPoints );
					}
				}
				
				if( TeamMageControl.ATeamPoints < TeamMageControl.TeamFinishPoints )
				{
				}
				
				if( TeamMageControl.ATeamPoints >= TeamMageControl.TeamFinishPoints )
				{
					World.Broadcast( 1153, false,"A-Takýmý Turnuvayý Kazanmýþtýr.");
					
					ArrayList mobs = new ArrayList( World.Mobiles.Values );
					foreach(Mobile m in mobs )
					{
						PlayerMobile pm = null;
						if(m is PlayerMobile)
						{
							pm = m as PlayerMobile;
						}
					
						if( pm != null && pm.EventType == EventType.ATeamMage )
						{
							pm.AddToBackpack( new BankCheck(250000));
						}
					}
					FinishGame();
				}
			}
		}
		
		public TeamMageControl( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( Reward );
			writer.Write( TeamFinishPoints );
			writer.Write( Running );
            writer.Write((Point3D)m_ExitPoint);
			writer.Write((Map)m_ExitMap);
			writer.Write((Point3D)m_ATeamArena);
			writer.Write((Point3D)m_BTeamArena);
			writer.Write((Point3D)m_StaffPoint);
			writer.Write((Map)m_StaffMap);
			writer.Write((Map)m_TeamArenaMap);
		}
			
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 0:
				{
					m_Reward = reader.ReadInt();
					m_TeamFinishPoints = reader.ReadInt();
					m_Running = reader.ReadBool();
					m_ExitPoint = reader.ReadPoint3D();
					m_ExitMap = reader.ReadMap();
					m_ATeamArena = reader.ReadPoint3D();
					m_BTeamArena = reader.ReadPoint3D();
					m_StaffPoint = reader.ReadPoint3D();
					m_StaffMap = reader.ReadMap();
					m_TeamArenaMap = reader.ReadMap();
					break;
				}
			}	
		}
	}	
}