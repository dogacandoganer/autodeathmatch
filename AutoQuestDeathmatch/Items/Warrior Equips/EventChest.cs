using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class EventChest: BoneChest
	{
        [Constructable]
        public EventChest()
		{
				Weight = 0;
				Name = "Event Chest";
				Hue = 1109;
              Attributes.DefendChance = 5;
              Attributes.EnhancePotions = 15;
              Attributes.ReflectPhysical = 5;
              ColdBonus = 5;
              EnergyBonus = 5;
              FireBonus = 5;
              PhysicalBonus = 25;
              PoisonBonus = 5;
              LootType = LootType.Blessed; 
			  Movable = false;
		}
        public EventChest( Serial serial ) : base( serial )
        {
        }
              
        public override void Serialize( GenericWriter writer )
        {
                base.Serialize( writer );
                writer.Write( (int) 0 );
        }
			
        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
		}
	}
}

