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
	public class PvMControl : Item
	{	
		public static int m_TitanCount;
		public static bool m_Running;	
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static int TitanCount
		{
			get { return m_TitanCount; }
			set { m_TitanCount = value; }
		}
		
		[CommandProperty(AccessLevel.GameMaster)]
		public static bool Running
		{
			get { return m_Running; }
			set { m_Running = value; }
		}
		
		[Constructable]
		public PvMControl(): base ( 3796 )
		{
			this.Hue = 1161;
			this.Movable = false;
			this.Name = "Titan Quest Kontroller";
		}
		
		public PvMControl( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
			writer.Write( TitanCount );
			writer.Write( Running );
		}
			
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch ( version )
			{
				case 0:
				{
					m_TitanCount = reader.ReadInt();
					m_Running = reader.ReadBool();
					break;
				}
			}	
		}
	}	
}