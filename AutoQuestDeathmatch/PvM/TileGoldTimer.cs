/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using System.Collections;
using Server;
using Server.Items;
using Server.DeathMatch;

namespace Server.DeathMatch
{
	public class TileTokenTimer : Timer
	{
		private Map m_Map;
		private int m_X, m_Y;

		public TileTokenTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 10.0 ) )
		{
			m_Map = map;
			m_X = x;
			m_Y = y;
		}

		protected override void OnTick()
		{
			int z = m_Map.GetAverageZ( m_X, m_Y );
			bool canFit = m_Map.CanFit( m_X, m_Y, z, 6, false, false );

			for ( int i = -3; !canFit && i <= 3; ++i )
			{
				canFit = m_Map.CanFit( m_X, m_Y, z + i, 6, false, false );

				if ( canFit )
					z += i;
			}

			if ( !canFit )
				return;

			Gold g = new Gold( 500, 1000 );
				
			g.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

			if ( 0.5 >= Utility.RandomDouble() )
			{
				switch ( Utility.Random( 3 ) )
				{
					case 0: // Fire column
					{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );
						Effects.PlaySound( g, g.Map, 0x208 );

						break;
					}
					
					case 1: // Explosion
					{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 20, 10, 5044 );
						Effects.PlaySound( g, g.Map, 0x307 );

						break;
					}
					case 2: // Ball of fire
					{
						Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 10, 5052 );

						break;
					}
				}
			}
		}
	}
}
		