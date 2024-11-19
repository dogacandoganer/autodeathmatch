using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfAga : Bag 
	{ 

		[Constructable] 
		public BagOfAga()

		{ 
			Name = "AgilityPotion";
			Hue = 2881;
			DropItem( new GreaterAgilityPotion () ); 
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );
			DropItem( new GreaterAgilityPotion () );

			Weight = 0;
			LootType = LootType.Blessed;

		} 

		public BagOfAga( Serial serial ) : base( serial ) 
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
