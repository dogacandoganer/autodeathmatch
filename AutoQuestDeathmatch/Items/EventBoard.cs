/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Factions;
using Server.EventScoreBoard;



namespace Server.Items
{
	[Flipable( 0x1E5E, 0x1E5F )]
	public class EventBoard : Base1ScoreBoard
	{
		
		public int itemID;
			
		[Constructable]
		public EventBoard( ) : base( 0x1E5E )
		{
			
		}
		
		public EventBoard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public abstract class Base1ScoreBoard : Item
	{
		private string m_BoardName;
		public int hue;
		public Faction m_Faction;
		

		[CommandProperty( AccessLevel.GameMaster )]
		public string BoardName
		{
			get{ return m_BoardName; }
			set{ m_BoardName = value; }
		}

		public Base1ScoreBoard( int itemID ) : base( itemID )
		{
			Name = "Top 20 Turnuva";
			m_BoardName = "Top 20";
			Movable = false;
			this.hue = 0x0544;
		}

		public virtual void Cleanup()
		{
            List<string> items = new List<string>();
			//ArrayList items = this.Items;

			for ( int i = items.Count - 1; i >= 0; --i )
			{
				if ( i >= items.Count )
					continue;

			}
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( CheckRange( from ) )
			{
				Cleanup();
				if ( !from.InRange( GetWorldLocation(), 2 ) )
				from.LocalOverheadMessage( MessageType.Regular, 0x3B2, 1019045 ); // I can't reach that.
				else 
				{
					from.CloseGump( typeof( EventScoreGump));
					from.SendGump( new EventScoreGump( from, null, null, 0, null, null ));
				}
			}
			
		}

		public virtual bool CheckRange( Mobile from )
		{
			if ( from.AccessLevel >= AccessLevel.GameMaster )
				return true;

			return ( from.Map == this.Map && from.InRange( GetWorldLocation(), 2 ) );
		}

		public Base1ScoreBoard( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

			writer.Write( (string) m_BoardName );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_BoardName = reader.ReadString();
					break;
				}
			}
		}
	}
}
