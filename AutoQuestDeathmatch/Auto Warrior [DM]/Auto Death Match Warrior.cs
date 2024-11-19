/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using System.IO;
using System.Diagnostics;
using System.Collections; 
using Server;
using Server.Network; 
using Server.Items; 
using Server.Mobiles; 
using Server.Prompts;
using Server.Misc; 
using Server.Accounting; 
using Server.Gumps;
using Server.DeathMatch;
using Server.Commands;

namespace Server.DeathMatch
{
	public class AutoDeathMatchWarrior : Timer
	{
		
		public static bool Enabled = false; // is the script enabled?

		public static TimeSpan StartTime = TimeSpan.FromHours( 20.0 ); // time of day at which to restart

		private static DateTime m_StartTime;
		private static bool m_Starting;
		
		public static bool Starting
		{
			get{ return m_Starting; }
		}

		public static void Initialize()
		{
			CommandSystem.Register( "AutoWarrior", AccessLevel.Administrator, new CommandEventHandler( Start_OnCommand ) );
			new AutoDeathMatchWarrior().Start();
		}

		public static void Start_OnCommand( CommandEventArgs e )
		{
			if ( Enabled != false )
			{
				e.Mobile.SendMessage( "Etkinlik Ýn-Aktif Edildi" );
				Enabled = false;
			}
			else
			{
				e.Mobile.SendMessage( "Etkinlik Aktif Edildi,{0}", StartTime );
				Enabled = true;
				//m_StartTime = DateTime.Now;
			}
		}

		public AutoDeathMatchWarrior() : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
		{
			m_StartTime = DateTime.Now.Date + StartTime;

			if ( m_StartTime < DateTime.Now )
				m_StartTime += TimeSpan.FromDays( 1.0 );
		}

		protected override void OnTick()
		{
			if ( m_Starting || !Enabled )
				return;

			if ( DateTime.Now < m_StartTime )
				return;

			ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
			
			foreach ( Mobile m in mobs ) 
			{
				if ( m.AccessLevel < AccessLevel.Counselor )
				m.SendGump ( new DeathMatchGumpWarrior() );
				

				new StartTimerWarrior(m).Start();
			}

			World.Broadcast( 1153, false, "Etkinlik Baþlamýþtýr[Warrior]" );
			Stop();		
		}
	}
}