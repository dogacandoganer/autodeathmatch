using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfCure : Bag 
	{ 

		[Constructable] 
		public BagOfCure()

		{ 
			Name = "CurePotion";
			Hue = 44;
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 			
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			DropItem( new GreaterCurePotion () ); 
			Weight = 0;
			LootType = LootType.Blessed;

		} 

		public BagOfCure( Serial serial ) : base( serial ) 
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
