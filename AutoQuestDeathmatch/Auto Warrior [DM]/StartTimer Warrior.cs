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
using Server.DeathMatch;

namespace Server.DeathMatch
{
	public class StartTimerWarrior : Timer
	{
		public Mobile m_Mobile;
		public int cnt;

		public StartTimerWarrior(Mobile mob) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
		{
			m_Mobile = mob;
			cnt = 60;
		}

		protected override void OnTick()
		{		
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
				m_Mobile.CloseGump( typeof( DeathMatchGumpWarrior ));
			}
				
			if( cnt == 30 && m_Mobile.Backpack != null )
			{
				Wearing(m_Mobile);
			}				
				
			if( cnt < 17 )
			{
				cnt -= 1;
				m_Mobile.SendMessage( 38,"{0}", cnt );
			}
				
			if( cnt == 0 )
			{
				if(( m_Mobile.X < 2397 )&&( m_Mobile.X > 2330)&&( m_Mobile.Y > 1087 )&&( m_Mobile.Y <  1162 )&&( m_Mobile.Map == Map.Malas )&&( m_Mobile.AccessLevel == AccessLevel.Player))
				{					
					m_Mobile.Blessed = false;
					m_Mobile.Frozen = false;
					m_Mobile.Squelched = false;
					m_Mobile.Paralyzed = false;
					m_Mobile.Hidden = false;
			
					m_Mobile.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Head );
					m_Mobile.PlaySound( 0x1F5 );
					m_Mobile.SendMessage( 43,"Baþladý! Herkesi Öldür Para Kazan!");
					m_Mobile.Warmode = true;
				}	
					
				this.Stop();
            }
		
			if( cnt < 0 )
			{
				cnt = 0;
					
				if(( m_Mobile.X < 2397 )&&( m_Mobile.X > 2330)&&( m_Mobile.Y > 1087 )&&( m_Mobile.Y <  1162 )&&( m_Mobile.Map == Map.Malas )&&( m_Mobile.AccessLevel == AccessLevel.Player))
				{					
					m_Mobile.Blessed = false;
					m_Mobile.Frozen = false;
					m_Mobile.Squelched = false;
					m_Mobile.Paralyzed = false;
					m_Mobile.Hidden = false;
			
					m_Mobile.FixedParticles( 0x373A, 10, 15, 5018, EffectLayer.Head );
					m_Mobile.PlaySound( 0x1F5 );
					m_Mobile.SendMessage( 43,"Baþladý! Herkesi Öldür Para Kazan!");
					m_Mobile.Warmode = true;
				}
						
				this.Stop();
			}
		}
			
		public void Wearing( Mobile m )
		{				
			if( m.X < 2397 && m.X > 2330 && m.Y > 1087 && m.Y <  1162 && m.Map == Map.Malas && m.AccessLevel == AccessLevel.Player && m.Backpack != null )
			{	
				m.EquipItem( new EventKryss() );
				m.EquipItem( new EventShield() );
				m.EquipItem( new EventChest() );
				m.EquipItem( new EventGloves() );
				m.EquipItem( new EventHelm() );
				m.EquipItem( new EventLegs() );					
				m.EquipItem( new EventSandal() );	
			}
		}
    }
}
