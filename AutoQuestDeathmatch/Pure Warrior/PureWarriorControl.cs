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
	public class PureWarriorControl : Item
	{			
		public static bool m_Running;	
		
		public static Point3D m_WarriorArena;
		public static Point3D m_StaffPoint;
		
		public static Map m_StaffMap;
		public static Map m_WarriorArenaMap;
		
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static bool Running
		{
			get { return m_Running; }
			set {m_Running = value; }
		}
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Point3D WarriorArena
        {
            get { return m_WarriorArena; }
            set { m_WarriorArena = value; }
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
        public static Map WarriorArenaMap
        {
            get { return m_WarriorArenaMap; }
            set { m_WarriorArenaMap = value; }
        }			
		
		[Constructable]
		public PureWarriorControl(): base ( 3796 )
		{
			this.Hue = 1172;
			this.Movable = false;
			this.Name = "Pure Warrior Kontrol Taþý";
		}
		
		public PureWarriorControl( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( Running );
			writer.Write((Point3D)m_WarriorArena);
			writer.Write((Point3D)m_StaffPoint);
			writer.Write((Map)m_StaffMap);
			writer.Write((Map)m_WarriorArenaMap);
		}
			
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 0:
				{
					m_Running = reader.ReadBool();
					m_WarriorArena = reader.ReadPoint3D();
					m_StaffPoint = reader.ReadPoint3D();
					m_StaffMap = reader.ReadMap();
					m_WarriorArenaMap = reader.ReadMap();
					break;
				}
			}	
		}
	}	
}