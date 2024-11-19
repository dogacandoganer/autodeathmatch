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
	public class WalkTimer : Timer
	{	
		private Mobile m_Mobile;

		public WalkTimer( Mobile mob ) : base( TimeSpan.FromSeconds( 0.30 ), TimeSpan.FromSeconds( 0.30 ) )
		{
			m_Mobile = mob;
		}

		protected override void OnTick()
		{
			m_Mobile.Direction = Direction.North;
			m_Mobile.Y -= 1;
			if( m_Mobile != null )
			{
				if( m_Mobile.Y == 949)
				{
					m_Mobile.PublicOverheadMessage( Network.MessageType.Regular, 63, false,"Dont follow me bitch");
				}
				
				if( m_Mobile.Y == 863)
				{
					m_Mobile.Delete();
					this.Stop();
				}
			
				if( m_Mobile.Y == 862)
				{
					m_Mobile.Delete();
					this.Stop();
				}
			
				if( m_Mobile.Y == 861)
				{
					m_Mobile.Delete();
					this.Stop();
				}
			}
			else
			{
				this.Stop();
			}
		}
    }
}
