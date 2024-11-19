using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.DeathMatch;
using Server.Engines.Quests;

namespace Server.DeathMatch
{
	public class PvMSpy : BaseQuester
	{
		[Constructable]
		public PvMSpy() : base( "The Spy" )
		{
		}

		public PvMSpy( Serial serial ) : base( serial )
		{
		}

		public override void InitBody()
		{
			InitStats( 100, 100, 25 );

			Hue = 0x83EF;

			Female = false;
			Body = 0x190;
			Name = "Guardian Jack";
		}

		public override void InitOutfit()
		{
			AddItem( new FancyShirt() );
			AddItem( new LongPants( 0x66D ) );
			AddItem( new ThighBoots() );
			AddItem( new TricorneHat( 0x1 ) );
			AddItem( new BodySash( 0x66D ) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 0x66D;
			AddItem( gloves );

			AddItem( new LongBeard( 0x455 ) );

			Item sword = new Cutlass();
			sword.Movable = false;
			AddItem( sword );
		}

		public override void OnTalk( PlayerMobile player, bool contextMenu )
		{
			Direction = GetDirectionTo( player );
			Animate( 33, 20, 1, true, false, 0 );

      		int m_Amount = player.Backpack.GetAmount( typeof( QuestTokens ) ); 
			
			Key a = new Key();
			Container pack = player.Backpack;
			
			if ( m_Amount >= 100 )
			{
				
				player.Backpack.ConsumeTotal( typeof( QuestTokens ), 100 ); // Delete the tokens
				pack.DropItem( a );
				World.Broadcast( 26, false,"{0} Cehennemin Anahtarýný Aldý", player.Name );
				a.KeyValue = 33;
				a.Hue = 38;
				a.Description = "Key Of The Hell";
				

				this.PublicOverheadMessage( Network.MessageType.Regular, 63, false,"Ýþte Anahtar Çantanda,Dikkatli Olun Hahaha!" );
				new WalkTimer(this).Start();
				return;
			}

			PlaySound( 0x42C );
			this.PublicOverheadMessage( Network.MessageType.Regular, 26, false,  "100Quest Token Getirmediniz!" ); 
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}