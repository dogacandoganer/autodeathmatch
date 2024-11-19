using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfHeal : Bag 
	{ 

		[Constructable] 
		public BagOfHeal()

		{ 
			Name = "HealPotion";
			Hue = 1161;
			
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () ); 
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			DropItem( new GreaterHealPotion () );
			LootType = LootType.Blessed;			
			Weight = 0;


		} 

		public BagOfHeal( Serial serial ) : base( serial ) 
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
