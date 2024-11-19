/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections;
using Server.ContextMenus;
using Server.Gumps;
using Server.EventScoreBoard;
using Server;

namespace Server.DeathMatch
{
	public class CloseGumpTimer : Timer
	{
		public int cnt;

		public CloseGumpTimer() : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
		{
			cnt = 35;
		}

		protected override void OnTick()
		{
			ArrayList mobs = new ArrayList( World.Mobiles.Values );
			
			if( cnt > 0 )
			{
				cnt -= 1;
				
				if( cnt == 25 )
				World.Broadcast( 63, false, "Turnuvaya Katýlým {0} saniye sonra kapanacaktýr.", cnt );
			}
				
			if( cnt == 0 )
			{
				foreach( Mobile m in mobs  )
				{
					if( m != null )
					{
						m.CloseGump( typeof(PublicMOGump) );
						m.CloseGump( typeof(PublicWOGump) );
						m.CloseGump( typeof(PublicPvMGump) );
					}
				}
						
				World.Broadcast( 63, false, "Turnuvaya Katýl Kapanmýþtýr.");
				this.Stop();
            }
			
			if( cnt < 0 )
			{
				foreach( Mobile m in mobs  )
				{
					if( m != null )
					{
						m.CloseGump( typeof(PublicMOGump) );
						m.CloseGump( typeof(PublicWOGump) );
						m.CloseGump( typeof(DeathMatchGumpMage) );
						m.CloseGump( typeof(DeathMatchGumpWarrior) );
						m.CloseGump( typeof(PublicPvMGump) );
					}
				}
				
				World.Broadcast( 63, false, "Turnuvaya Katýlým Kapanmýþtýr");
				cnt = 0;
				this.Stop();
			}
		}
    }
}
