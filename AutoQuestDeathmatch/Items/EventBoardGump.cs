/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using Server;
using Server.Items;
using System.Net;
using System.Text;
using System.Collections;
using System.Diagnostics;
using Server.Prompts;
using Server.Network;
using Server.Accounting;
using Server.Scripts.Commands;
using Server.Gumps;
using Server.Misc;
using Server.Guilds;
using Server.Factions;
using Server.Mobiles;


namespace Server.EventScoreBoard
{
	
	public class RankSort1 : IComparable
	{
		public Mobile      Killer;
		public int Wins;
		public int Loses;
		public static string Scripter_Name;
		
		public RankSort1(Mobile m)
		{
			Killer = m;
			if(m is PlayerMobile)
			{
				Wins = ((PlayerMobile)m).EventKill;
				Loses = ((PlayerMobile)m).EventDeath;
			}
			
		}

            public int CompareTo( object obj )
            {
                RankSort1 p = (RankSort1)obj;
                
                if( p.Wins - Wins == 0 )
                {
                	return p.Loses - Loses;
                }
                
                return p.Wins - Wins;    
            }
	}
	
	public class EventScoreGump : Gump
	{
		public Mobile m_From;
		public ArrayList m_List;
		
		private const int LabelColor = 0x7FFF;
		private const int SelectedColor = 0x421F;
		private const int DisabledColor = 0x4210;

		private const int LabelColor32 = 0xFFFFFF;
		private const int SelectedColor32 = 0x8080FF;
		private const int DisabledColor32 = 0x808080;

		private const int LabelHue = 0x480;
		private const int GreenHue = 0x40;
		private const int RedHue = 0x20;

		public EventScoreGump( Mobile from, EventScoreGump pageType, ArrayList list, int listPage, string notice, object state ) : base( 50, 40 )
		{
			from.CloseGump( typeof( EventScoreGump ) );
			
			m_List = list;
			m_From = from;
			
			ArrayList playerlist = new ArrayList();

				foreach( Mobile m in World.Mobiles.Values )
				{
					if( m.Player )
					{
						playerlist.Add(new RankSort1(m));
					}
				}
			
				for( int i= 0; i<playerlist.Count;i++ )
                {
					if ( i > 9 )
						break;
					
					RankSort1 p = playerlist[i] as RankSort1;
    				
                 }
				
			
			
			AddPage( 0 );

			AddBackground( 0, 0, 360, 540, 3600 );

			AddBlackAlpha( 10, 10, 340, 520 );
			
			if ( notice != null )
			AddHtml( 12, 392, 396, 36, Color( notice, LabelColor32 ), false, false );

						
			AddLabel( 150, 15, RedHue, "Top 20 Turnuva" );
			AddLabel( 270, 15, RedHue, ServerSettings.Scripter_Name.ToString() );
			AddLabel( 20, 40, LabelHue, "Oyuncular" );
			AddLabel( 185, 40, LabelHue, "Öldürme" );
			AddLabel( 265, 40, LabelHue, "Ölme" );
			
			playerlist.Sort();
			
			for ( int i = 0; i < playerlist.Count; ++i )
			{
				if ( i >= 20 )
				{
					
					break;
					
				}
			
				RankSort1 g = (RankSort1)playerlist[i];

					string name = null;

					if ( (name = g.Killer.Name) != null && (name = name.Trim()).Length <= 15 )
						name = g.Killer.Name;
				
					string wins = null;
    
                    if(g.Killer is PlayerMobile ) 
                        wins = ((PlayerMobile)g.Killer).EventKill.ToString();
                    
                    string loses = null;
                    
                    	if(g.Killer is PlayerMobile ) 
                        loses = ((PlayerMobile)g.Killer).EventDeath.ToString();

					
					AddLabel( 20, 70 + ((i % 20) * 20), RedHue, name );
					AddLabel( 190, 70 + ((i % 20) * 20), GreenHue, wins );
					AddLabel( 270, 70 + ((i % 20) * 20), GreenHue, loses );
			}
		}
		
		public string Color( string text, int color )
		{
			return String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text );
		}

		public void AddBlackAlpha( int x, int y, int width, int height )
		{
			AddImageTiled( x, y, width, height, 2624 );
			AddAlphaRegion( x, y, width, height );
		}		
	}
}