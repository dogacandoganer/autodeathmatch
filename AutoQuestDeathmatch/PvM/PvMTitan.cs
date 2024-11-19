/*****************************************************
Lord RequaNer  ( Do�acanDo�aner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;
using Server.DeathMatch;

namespace Server.DeathMatch
{
    [CorpseName( "corpse of a fucked" )]
    public class PvMTitan : BaseCreature
    {
        //public override bool HasBreath{ get{ return true ; } }
        public override bool AutoDispel{ get{ return true; } }
        public override Poison HitPoison{ get{ return Poison. Deadly ; } }
        public override bool AlwaysMurderer{ get{ return true; } }
	
		[Constructable]
        public PvMTitan() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
        {
			Name = "Guardian Of The Hell";
            Hue = 2219;
            Body = 189; 
            BaseSoundID = 0x45A; 
            SetStr( 500 );
            SetDex( 100 );
            SetInt( 1000 );
            SetHits( 7000 );
            SetDamage( 25 );
            SetDamageType( ResistanceType.Physical, 100 );
            SetDamageType( ResistanceType.Cold, 0 );
            SetDamageType( ResistanceType.Fire, 0 );
            SetDamageType( ResistanceType.Energy, 0 );
            SetDamageType( ResistanceType.Poison, 100 );

            SetResistance( ResistanceType.Physical, 40 );
            SetResistance( ResistanceType.Cold, 100 );
            SetResistance( ResistanceType.Fire, 100 );
            SetResistance( ResistanceType.Energy, 100 );
            SetResistance( ResistanceType.Poison, 100 );
            Fame = 25000;
            Karma = -25000;
            VirtualArmor = 64;
     
            PackGold( 500, 1000 );
            PackItem( new Longsword() ); 
            PackItem( new BankCheck(10000) ); 
	    
        }
		
		public override void OnDeath( Container c )
		{
			Mobile o = new PvMSpy();
			base.OnDeath( c );
			
			if( this.LastKiller != null )
			{
				this.LastKiller.AddToBackpack( new QuestTokens(18));
			}

			if( PvMControl.Running == true )
				PvMControl.TitanCount -= 1;
			if( PvMControl.TitanCount <= 0 )
			{
				o.X = 5729;
				o.Y = 973;
				o.Z = 0;
				o.Map = Map.Trammel;
				o.CantWalk = true;
				PvMControl.TitanCount = 0;
			}
		}

		public PvMTitan( Serial serial ) : base( serial )
        {
        }

		public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( (int) 0 );
        }

        public override void Deserialize( GenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
        }
    }
}
