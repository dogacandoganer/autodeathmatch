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
	public class PureMageControl : Item
	{			
		public static bool m_Running;	
		
		public static Point3D m_MageArena;
		public static Point3D m_StaffPoint;
		
		public static Map m_StaffMap;
		public static Map m_MageArenaMap;
		
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static bool Running
		{
			get { return m_Running; }
			set {m_Running = value; }
		}
		
        [CommandProperty(AccessLevel.GameMaster)]
        public static Point3D MageArena
        {
            get { return m_MageArena; }
            set { m_MageArena = value; }
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
        public static Map	MageArenaMap
        {
            get { return m_MageArenaMap; }
            set { m_MageArenaMap = value; }
        }			
		
		[Constructable]
		public PureMageControl(): base ( 3796 )
		{
			this.Hue = 1172;
			this.Movable = false;
			this.Name = "Pure Mage Kontrol Taþý";
		}
		
		public PureMageControl( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( Running );
			writer.Write((Point3D)m_MageArena);
			writer.Write((Point3D)m_StaffPoint);
			writer.Write((Map)m_StaffMap);
			writer.Write((Map)m_MageArenaMap);
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
					m_MageArena = reader.ReadPoint3D();
					m_StaffPoint = reader.ReadPoint3D();
					m_StaffMap = reader.ReadMap();
					m_MageArenaMap = reader.ReadMap();
					break;
				}
			}	
		}
	}	
}