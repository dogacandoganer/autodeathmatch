using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfPoison: Bag 
	{ 
		[Constructable] 
		public BagOfPoison()

		{ 
			Name = "PoisonPotion";
			Hue = 63;
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			DropItem( new DeadlyPoisonPotion () ); 
			Weight = 0;
			LootType = LootType.Blessed;
			
		} 

		public BagOfPoison( Serial serial ) : base( serial ) 
		{ 
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
