using System;
using Server;

namespace Server.Items

{
              
              public class EventKryss : Kryss
              {
              public override int ArtifactRarity{ get{ return 3162; } } 
              public override int AosMinDamage{ get{ return 12; } }
              public override int AosMaxDamage{ get{ return 13; } }
              
                      [Constructable]
                      public EventKryss() 
                      {
                                        Weight = 0;
                                        Name = "Event Kryss";
                                        Hue = 1153;
              
                                        WeaponAttributes.DurabilityBonus = 20;
                                        WeaponAttributes.ResistColdBonus = 2; 
										WeaponAttributes.HitLeechMana = 35;
                                        WeaponAttributes.ResistEnergyBonus = 2;
                                        WeaponAttributes.ResistPhysicalBonus = 10;
                                        WeaponAttributes.ResistPoisonBonus = 2;
                                        WeaponAttributes.SelfRepair = 5;
              
                                        Attributes.DefendChance = 2;
										Attributes.AttackChance = 15;
                                        Attributes.NightSight = 1;
                                       Attributes.ReflectPhysical = 5;
                                        Attributes.WeaponDamage = 75;
                                        Attributes.WeaponSpeed = 25;
										LootType = LootType.Blessed; 
										Poison = Poison.Deadly;
										PoisonCharges = 5;
													  Movable = false;
              
                                    }
              
                      public EventKryss( Serial serial ) : base( serial )  
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
