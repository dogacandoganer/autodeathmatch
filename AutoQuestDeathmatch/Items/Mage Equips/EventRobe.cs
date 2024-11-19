using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class EventRobe: BaseOuterTorso 
{
              
              [Constructable]
              public EventRobe(): base( 0x2683 )
{
	int hue = Utility.RandomList( 1161, 1153, 1152, 1154, 1266, 1288, 62, 38, 3, 1, 1109, 1170, 1166,  1165, 1164, 1159 );
                          Weight = 0;
                          Name = "Event Robe";
                          Hue = hue;
			  Layer = Layer.OuterTorso;
              LootType = LootType.Blessed; 
			  Movable = false;
                  }
              public EventRobe( Serial serial ) : base( serial )
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
