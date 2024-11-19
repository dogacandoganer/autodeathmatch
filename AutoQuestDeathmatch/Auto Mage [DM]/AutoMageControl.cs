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
using Server.Multis;
using Server.ContextMenus;
using Server.DeathMatch;
using Server.EventScoreBoard;

namespace Server.DeathMatch
{	
	public class AutoMageControl : Item
	{
		public static void Initialize()
		{
			EventSink.PlayerDeath += new PlayerDeathEventHandler(OnPlayerDeath);
		}		
		
		public static int m_Reward;
		public static int m_MagePoints;
		public static bool m_Running;
		public static Point3D m_StaffPoint;
		public static Map m_StaffMap;
		
		public static Point3D m_ExitPoint;
		public static Map m_ExitMap;
		
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
		public static int Reward
		{
			get { return m_Reward; }
			set { m_Reward = value; }
		}
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static int MagePoints
		{
			get { return m_MagePoints; }
			set { m_MagePoints = value; }
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
        public static Map ExitMap
        {
            get { return m_ExitMap; }
            set { m_ExitMap = value; }
        }	
		
		[Constructable]
		public AutoMageControl(): base ( 3796 )
		{
			this.Hue = 1172;
			this.Movable = false;
			this.Name = "Auto Mage Kontrol Taþý";
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
			ArrayList mobs = new ArrayList( World.Mobiles.Values );
			
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
			}
			
			foreach(Mobile m in mobs )
			{
				PlayerMobile pm = null;
				if(m is PlayerMobile)
				{
					pm = m as PlayerMobile;
				}
				
				if(pm != null && pm.EventType == EventType.AutoMage )
				{
					pm.MoveToWorld( m_ExitPoint, m_ExitMap );
					pm.EventType = EventType.None;
					pm.EventDeath = 0;
					pm.EventKill = 0;
				}
			}
			AutoMageControl.m_Running = false;
		}
		
		private static void OnPlayerDeath(PlayerDeathEventArgs e)
		{	
			PlayerMobile pd = e.Mobile as PlayerMobile;
				
			if (pd != null && pd.EventType == EventType.AutoMage)
			{
				pd.Resurrect();
				pd.EventDeath += 1;
				pd.Blessed = true;
				new BlessedTimer(pd).Start();
				HandleCorpse(pd);
				
				if(pd.LastKiller != null && pd.LastKiller is PlayerMobile )
				{
					PlayerMobile lk = pd.LastKiller as PlayerMobile;
					
					if( lk.EventType == EventType.AutoMage )
					{
						lk.EventKill += 1;
						lk.SendMessage( 63,"+1, Toplam Kill = {0}", lk.EventKill );
					}
				
					if (( lk.EventType == EventType.AutoMage )&&( lk.EventKill >= m_MagePoints ))
					{ 
						FinishGame();
						
						lk.SendMessage( 63,"{0} puana ulaþtý ve galip geldi.", m_MagePoints );
						
						if( m_Reward > 1000 && lk.Backpack != null )
						{
                            lk.AddToBackpack(new BankCheck(100000));
						}
					
						World.Broadcast( 0x481, false, "{0} Etkinlik Galibi Olmuþtur[Mage]", lk.Name );
					
						Item a = new DeathMatchClearGate();
					
						a.X = 2367;
						a.Y = 1127;
						a.Z = -90;
						a.Map = Map.Malas;
					}
				}
			}
		}
		
		public AutoMageControl( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( Reward );
			writer.Write( MagePoints );
			writer.Write( Running );
           	        writer.Write((Point3D)m_ExitPoint);
			writer.Write((Map)m_ExitMap);
			writer.Write((Point3D)m_StaffPoint);
			writer.Write((Map)m_StaffMap);
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
					m_MagePoints = reader.ReadInt();
					m_Running = reader.ReadBool();
					m_ExitPoint = reader.ReadPoint3D();
					m_ExitMap = reader.ReadMap();
					m_StaffPoint = reader.ReadPoint3D();
					m_StaffMap = reader.ReadMap();
					break;
				}
			}	
		}
	}	
}