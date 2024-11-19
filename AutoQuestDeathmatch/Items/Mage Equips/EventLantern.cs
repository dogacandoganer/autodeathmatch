using System;
using Server;
using Server.Items;

namespace Server.Items
{

              public class EventLantern: BaseShield
{
              
              [Constructable]
              public EventLantern() : base( 0xA22 )
{

                          Weight = 0;
                          Name = "Event Lantern";
                          Hue = 0;
              
              LootType = LootType.Blessed; 
			  Movable = false;
                  }
              public EventLantern( Serial serial ) : base( serial )
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
