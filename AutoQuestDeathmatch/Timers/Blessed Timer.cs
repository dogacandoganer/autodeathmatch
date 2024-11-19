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
	public class BlessedTimer : Timer
	{
			
		private Mobile m_Mobile;
		public int cnt;

		public BlessedTimer( Mobile mob ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
		{
			m_Mobile = mob;
			cnt = 7;
		}

		protected override void OnTick()
		{
			PlayerMobile pm = m_Mobile as PlayerMobile;
			if( cnt > 0 )
			{
				cnt -= 1;
				if( cnt == 5 )
				{
					m_Mobile.SendMessage( 63," {0} Saniye korunacaksýnýz.", cnt );
					m_Mobile.Hits = 200;
					m_Mobile.Mana = 200;
					m_Mobile.Stam = 200;
				}
			}
				
			if( cnt == 0 )
			{
				m_Mobile.SendMessage( 38,"You are no longer blessed." );
				m_Mobile.Blessed = false;
				m_Mobile.Warmode = true;
					
				if( pm.EventType == EventType.ATeamMage  )
				{				
					pm.SendMessage( 1161,"A-Team Points <> {0}", TeamMageControl.ATeamPoints );
					pm.SendMessage( 1161,"B-Team Points <> {0}", TeamMageControl.BTeamPoints );
					pm.SendMessage( 1161,"Finish Points  <> {0}", TeamMageControl.TeamFinishPoints );
				}
				
				if( pm.EventType == EventType.ATeamWarrior  )
				{				
					pm.SendMessage( 1161,"A-Takým Puaný <> {0}", TeamWarriorControl.ATeamPoints );
					pm.SendMessage( 1161,"B-Takým Puaný <> {0}", TeamWarriorControl.BTeamPoints );
					pm.SendMessage( 1161,"Son Puanlar  <> {0}", TeamWarriorControl.TeamFinishPoints );
				}
					
				this.Stop();
            }
			
			if( cnt < 0 )
			{
				cnt = 0;
				m_Mobile.Blessed = false;
				m_Mobile.Warmode = true;
				pm.SendMessage( 38,"You are no longer blessed.");
					
				if( pm.EventType == EventType.ATeamMage  )
				{				
					pm.SendMessage( 1161,"A-Takým Puaný <> {0}", TeamMageControl.ATeamPoints );
					pm.SendMessage( 1161,"B-Takým Puaný <> {0}", TeamMageControl.BTeamPoints );
					pm.SendMessage( 1161,"Son Puanlar  <> {0}", TeamMageControl.TeamFinishPoints );
				}
				
				if( pm.EventType == EventType.ATeamWarrior  )
				{				
					pm.SendMessage( 1161,"A-Takým Puaný <> {0}", TeamWarriorControl.ATeamPoints );
					pm.SendMessage( 1161,"B-Takým Puaný <> {0}", TeamWarriorControl.BTeamPoints );
					pm.SendMessage( 1161,"Son Puanlar  <> {0}", TeamWarriorControl.TeamFinishPoints );
				}
					
				this.Stop();
			}
		}
    }
}
