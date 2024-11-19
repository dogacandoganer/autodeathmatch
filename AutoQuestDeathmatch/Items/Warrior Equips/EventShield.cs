using System;
using Server;
using Server.Items;


namespace Server.Items
{
              public class EventShield: BaseWaist
{
              
           [Constructable]
            public EventShield(): base ( 7108 )
			{

				Weight = 0;
				Name = "You dont need to put me of for drinking !!";
				Hue = 1153;
              
				Attributes.DefendChance = 15;
				Attributes.AttackChance = 20;
				Attributes.NightSight = 1;
				Attributes.ReflectPhysical = 20;
				LootType = LootType.Blessed; 
				Movable = false;
            }
              public EventShield( Serial serial ) : base( serial )
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
