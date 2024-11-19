/////////// Created By Lord Mashadow 77777777777777777777777
////7777777777
//77777777777777
using System; 
using Server; 
using Server.Items;

namespace Server.Items 
{ 
	public class BagOfAids : Bag 
	{
		[Constructable] 
		public BagOfAids()

		{ 
			Name = "Bandage Bag";
			Hue = 1154;
			DropItem( new Bandage( 500 ) ); 
			LootType = LootType.Blessed;
			
			Weight = 0;
		} 

		public BagOfAids( Serial serial ) : base( serial ) 
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
