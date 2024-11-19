using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class EventSandal: BaseShoes
				{
              
              [Constructable]
              public EventSandal(): base( 0x170D )
				{

                          Weight = 0;
                          Name = "Event Sandals";
                          Hue = 1153;
              
              LootType = LootType.Blessed; 
			  			  Movable = false;
                }
              public EventSandal( Serial serial ) : base( serial )
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
