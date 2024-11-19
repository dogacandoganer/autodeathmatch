using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class EventHelm: BoneHelm
{
              
              [Constructable]
              public EventHelm()
{

                          Weight = 0;
                          Name = "Event Helm";
                          Hue = 1109;
              
              Attributes.DefendChance = 5;
              Attributes.EnhancePotions = 5;
              Attributes.ReflectPhysical = 5;
              ArmorAttributes.SelfRepair = 8;
              ColdBonus = 8;
              EnergyBonus = 8;
              FireBonus = 8;
              PhysicalBonus = 12;
              PoisonBonus = 10;
              LootType = LootType.Blessed; 
			  Movable = false;
                  }
              public EventHelm( Serial serial ) : base( serial )
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
