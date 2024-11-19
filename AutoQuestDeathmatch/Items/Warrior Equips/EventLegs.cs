using System;
using Server;
using Server.Items;

namespace Server.Items
{
              public class EventLegs: BoneLegs
				{
              
              [Constructable]
              public EventLegs()
				{

                          Weight = 0;
                          Name = "Event Legs";
                          Hue = 1109;
              
              Attributes.DefendChance = 3;
              Attributes.EnhancePotions = 5;
              Attributes.NightSight = 1;
              Attributes.ReflectPhysical = 5;
              Attributes.CastRecovery = 4;
              Attributes.CastSpeed = 2;
			  Attributes.BonusHits = 45;
              ColdBonus = 20;
              EnergyBonus = 20;
              FireBonus = 25;
              PhysicalBonus = 40;
              PoisonBonus = 20;
              LootType = LootType.Blessed; 
			  			  Movable = false;
                }
              public EventLegs( Serial serial ) : base( serial )
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
