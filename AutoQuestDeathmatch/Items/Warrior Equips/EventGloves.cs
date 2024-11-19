using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class EventGloves: BoneGloves
{
              
              [Constructable]
              public EventGloves()
{

                          Weight = 0;
                          Name = "Event Gloves";
                          Hue = 1109;
              
              Attributes.DefendChance = 5;
              Attributes.EnhancePotions = 5;
              Attributes.ReflectPhysical = 5;
              ColdBonus = 15;
              EnergyBonus = 15;
              FireBonus = 15;
              PhysicalBonus = 30;
              PoisonBonus = 15;
              LootType = LootType.Blessed; 
			  Movable = false;
                  }
              public EventGloves( Serial serial ) : base( serial )
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
