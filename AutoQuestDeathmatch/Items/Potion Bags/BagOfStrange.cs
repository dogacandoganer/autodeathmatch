using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfStr : Bag 
	{
		[Constructable] 
		public BagOfStr()

		{ 
			Name = "Strength Potion";
			Hue = 1153;
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			DropItem( new GreaterStrengthPotion () ); 
			LootType = LootType.Blessed;
			
			Weight = 0;
		} 

		public BagOfStr( Serial serial ) : base( serial ) 
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
