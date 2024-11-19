using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Mobiles;

namespace Server.requaner
{
	[CorpseName( "corpse of a Event Boss" )]
	public class DemonKnight1 : BaseCreature
	{
		private int m_ps;
		private bool m_para;

		[Constructable]
		public DemonKnight1() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "RequaNer";
			Hue = 33775;
			Body = 400; 
			m_ps = 8;
			m_para = true;

			SetDamage( 25, 50 );
			Kills = 250;
			SetStr( 5000 );
			SetDex( 500 );
			SetInt( 800 );
			SetHits( 20000 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Cold, 60 );
			SetDamageType( ResistanceType.Fire, 60 );
			SetDamageType( ResistanceType.Energy, 60 );
			SetDamageType( ResistanceType.Poison, 60 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Cold, 60 );
			SetResistance( ResistanceType.Fire, 60 );
			SetResistance( ResistanceType.Energy, 60 );
			SetResistance( ResistanceType.Poison, 60 );

			SetSkill( SkillName.EvalInt, 140.0, 150.0 );
			SetSkill( SkillName.Inscribe, 120.0, 130.0 );
			SetSkill( SkillName.Magery, 120.0, 130.0 );
			SetSkill( SkillName.Meditation, 140.0, 150.0 );
			SetSkill( SkillName.MagicResist, 110.0, 120.0 );
			SetSkill( SkillName.Wrestling, 160.0, 170.0 );
			SetSkill( SkillName.Tactics, 130.0, 140.0 );
			SetSkill( SkillName.Parry, 120.0, 130.0 );
			SetSkill( SkillName.Fencing, 120.0, 130.0 );
			SetSkill( SkillName.Macing, 120.0, 130.0 );
			SetSkill( SkillName.Swords, 120.0, 130.0 );
			SetSkill( SkillName.Focus, 120.0, 130.0 );

			Item shroud = new HoodedShroudOfShadows();
			shroud.Movable = false;
			shroud.LootType = LootType.Blessed;

			AddItem( shroud );
			Frozen = true;
			Hidden = true;
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int Hp
		{
			get{ return HitsMax; }
			set
			{ 
				if ( value > 100 && value < 99000)
					SetHits( value );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool ParaSpawn
		{
			get{ return m_para; }
			set{ m_para = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int PsSayisi
		{
			get{ return m_ps; }
			set
			{
				m_ps = value;

				if ( m_ps < 0 || m_ps > 10 )
					m_ps = 0;
			}
		}

		private PowerScroll CreateRandomPowerScroll()
		{
			int level;
			double random = Utility.RandomDouble();

			if ( 0.01 >= random )
				level = 20;
			else if ( 0.05 > random )
				level = 15;
			else
				level = 10;

			return PowerScroll.CreateRandomNoCraft( level, level );
		}

		/*public void GivePowerScrolls()
		{
			ArrayList toGive = new ArrayList();
            List<int> rights = new List<int>();
            //ArrayList rights = new ArrayList();
			rights = BaseCreature.GetLootingRights( this.DamageEntries, this.HitsMax );

			for ( int i = rights.Count - 1; i >= 0; --i )
			{
				DamageStore ds = (DamageStore)rights[i];

				if ( ds.m_HasRight )
					toGive.Add( ds.m_Mobile );
			}

			if ( toGive.Count == 0 )
				return;

			for ( int i = 0; i < toGive.Count; ++i )
			{
				int rand = Utility.Random( toGive.Count );
				Mobile hold = (Mobile)toGive[i];
				toGive[i] = toGive[rand];
				toGive[rand] = hold;
			}

			for ( int i = 0; i < m_ps; ++i )
			{
				Mobile m = (Mobile)toGive[i % toGive.Count];

				PowerScroll ps = CreateRandomPowerScroll();

				GivePowerScrollTo( m, ps );
			}
		}*/

		public static void GivePowerScrollTo( Mobile m, PowerScroll ps )
		{
			if( ps == null || m == null )
				return;

			m.SendLocalizedMessage( 1049524 ); // You have received a scroll of power!

			if( !Core.SE || m.Alive )
				m.AddToBackpack( ps );
			else
			{
				if( m.Corpse != null && !m.Corpse.Deleted )
					m.Corpse.DropItem( ps );
				else
					m.AddToBackpack( ps );
			}
		}
        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (0.1 >= Utility.RandomDouble())
            {
                HoodedShroudOfShadows m_Shroud = new HoodedShroudOfShadows();
                m_Shroud.LootType = LootType.Cursed;
                c.DropItem(m_Shroud);
            }
        }

		public override bool OnBeforeDeath()
		{
			/*if ( m_ps > 0 )
				GivePowerScrolls();*/

			if ( m_para )
			{
				Map map = this.Map;

				if ( map != null && map != Map.Internal )
				{
					for ( int x = -14; x <= 14; ++x )
					{
						for ( int y = -14; y <= 14; ++y )
						{
							double dist = Math.Sqrt(x*x+y*y);

							if ( dist <= 14 )
								new GoodiesTimer( map, X + x, Y + y ).Start();
						}
					}
				}
			}

			return base.OnBeforeDeath();
		}

		public DemonKnight1( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );

			writer.Write( (int) m_ps );
			writer.Write( (bool) m_para );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			m_ps = reader.ReadInt();
			m_para = reader.ReadBool();
		}

		private class GoodiesTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public GoodiesTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 10.0 ) )
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

				Gold g = new Gold( 1000, 2000 );
				
				g.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.5 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 3 ) )
					{
						case 0: // Fire column
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 5052 );

							if ( Utility.Random( 3 ) > 2 )
								Effects.PlaySound( g, g.Map, 0x208 );

							break;
						}
						case 1: // Explosion
						{
							Effects.SendLocationParticles( EffectItem.Create( g.Location, g.Map, EffectItem.DefaultDuration ), 0x36BD, 20, 10, 5044 );

							if ( Utility.Random( 3 ) > 2 )
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
}
