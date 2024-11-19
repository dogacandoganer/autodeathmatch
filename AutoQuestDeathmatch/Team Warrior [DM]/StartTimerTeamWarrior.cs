/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections;
using Server.ContextMenus;
using Server.Gumps;
using Server.EventScoreBoard;
using Server.DeathMatch;

namespace Server.DeathMatch
{
	public class StartTimerTeamWarrior : Timer
	{	
		public Mobile m_Mobile;
		public PlayerMobile pl;
		public int cnt;

		public StartTimerTeamWarrior(Mobile mob) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
		{
			m_Mobile = mob;
			cnt = 60;
		}

		protected override void OnTick()
		{
			if( m_Mobile is PlayerMobile )
			{		
				PlayerMobile pm = m_Mobile as PlayerMobile;
				if( pm.EventType != EventType.None && pm != null )
				{		
					pm.Hits = 200;
					pm.Mana = 200;
					pm.Stam = 200;					
				}
				
				if( !pm.Alive && pm.EventType == EventType.None && pm != null )
				{
					pm.Resurrect();
				}
			}
			
			if( cnt > 16 )
			{
				cnt -= 1;
					
					m_Mobile.SendMessage( 63,"{0}", cnt );
					m_Mobile.Hits = 200;
					m_Mobile.Mana = 200;
					m_Mobile.Stam = 200;
			}

			if( cnt == 35 )
			{
				m_Mobile.CloseGump( typeof( PublicTeamWarriorGump ));
			}			
				
			if( cnt < 17 )
			{
				cnt -= 1;
				m_Mobile.SendMessage( 38,"{0}", cnt );
			}
				
			if( cnt == 0 )
			{
				if( m_Mobile is PlayerMobile )
				{		
					PlayerMobile pm = m_Mobile as PlayerMobile;
					if( pm.EventType == EventType.ATeamWarrior || pm.EventType == EventType.BTeamWarrior )
					{
						pm.Blessed = false;
						pm.Frozen = false;
						pm.Squelched = false;
						pm.Paralyzed = false;
						pm.Hidden = false;
			
						pm.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Head );
						pm.PlaySound( 0x1F5 );
						pm.SendMessage( 43,"Baþladý!Düþmanlarýnýzý Öldürün");
						pm.Warmode = true;
					}	
				}
					
				this.Stop();
            }
			
			if( cnt < 0 )
			{
				cnt = 0;
					
				if( m_Mobile is PlayerMobile )
				{		
					PlayerMobile pm = m_Mobile as PlayerMobile;
					if( pm.EventType == EventType.ATeamWarrior || pm.EventType == EventType.BTeamWarrior )
					{
						pm.Blessed = false;
						pm.Frozen = false;
						pm.Squelched = false;
						pm.Paralyzed = false;
						pm.Hidden = false;
			
						pm.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Head );
						pm.PlaySound( 0x1F5 );
						pm.SendMessage( 43,"Baþladý! Düþmanlarýnýzý Öldürün");
						pm.Warmode = true;
					}	
				}
						
				this.Stop();
			}
		}
    }
}
