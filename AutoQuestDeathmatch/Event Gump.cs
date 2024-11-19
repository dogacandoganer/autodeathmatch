/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using System.Collections; 
using Server;
using Server.Network; 
using Server.Items; 
using Server.Mobiles; 
using Server.Misc; 
using Server.Accounting; 
using Server.Gumps;
using Server.DeathMatch;
using Server.requaner;

namespace Server.DeathMatch
{
    public class EventGump : Gump
    {
        public static Point3D Cell1 = new Point3D(5707, 887, -5);
        public static Point3D Cell2 = new Point3D(5755, 887, -5);
        public static Point3D Cell3 = new Point3D(5707, 903, -5);
        public static Point3D Cell4 = new Point3D(5755, 903, -5);
        public static Point3D Cell5 = new Point3D(5707, 919, -5);
        public static Point3D Cell6 = new Point3D(5755, 919, -5);
        public static Point3D Cell7 = new Point3D(5707, 935, -5);
        public static Point3D Cell8 = new Point3D(5755, 935, -5);
        public static Point3D Cell9 = new Point3D(5707, 951, -5);
        public static Point3D Cell10 = new Point3D(5755, 951, -5);
        public static Point3D Cell11 = new Point3D(5707, 967, -5);
        public static Point3D Cell12 = new Point3D(5755, 967, -5);
        public static Point3D CellDemon = new Point3D(5731, 983, 0);

        public EventGump()
            : base(0, 0)
        {
            this.Closable = false;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(148, 260, 505, 300, 2600);
            this.AddImage(329, 28, 1418);
            //this.AddCheck(213, 301, 210, 211, false, 50);//GM Topuk
            this.AddCheck(213, 333, 210, 211, false, 51);//MO
            this.AddCheck(213, 365, 210, 211, false, 52);//WO
            this.AddCheck(213, 397, 210, 211, false, 53);//PvM
            //this.AddCheck(213, 431, 210, 211, false, 54);//Auto-Mage
            //this.AddCheck(213, 463, 210, 211, false, 55);//Auto-Warrior
            this.AddCheck(213, 495, 210, 211, false, 56);//CTF
            this.AddCheck(388, 431, 210, 211, false, 57);//Team Mage
            this.AddCheck(388, 463, 210, 211, false, 58);//Team Warrior
            this.AddImage(602, 226, 1417);
            this.AddImage(116, 512, 1417);
            this.AddImage(98, 199, 10400);
            //this.AddLabel(245, 301, 62, @"GM Topuk");
            this.AddLabel(245, 333, 62, @"Pure Mage");
            this.AddLabel(245, 365, 62, @"Pure Warrior");
            this.AddLabel(245, 397, 62, @"Titan Quest");
            this.AddLabel(245, 429, 62, @"Auto Mage [DM]");
            this.AddLabel(245, 461, 62, @"Auto Warrior [DM]");
            this.AddLabel(245, 493, 62, @"Null");
            this.AddLabel(420, 431, 62, @"Team Mage [DM]");
            this.AddLabel(420, 463, 62, @"Team Warrior [DM]");
            this.AddButton(355, 512, 10820, 10800, (int)Buttons.Start, GumpButtonType.Reply, 0);
            this.AddButton(491, 512, 10840, 10800, (int)Buttons.Cancel, GumpButtonType.Reply, 0);
            this.AddLabel(388, 517, 0, @"Start!");
            this.AddLabel(524, 517, 0, @"Cancel!");
            this.AddImage(388, 296, 11413);
            this.AddLabel(189, 209, 1153, ServerSettings.Server_Name.ToString());
            this.AddImage(621, 520, 10412);
            this.AddLabel(527, 584, 1153, ServerSettings.Scripter_Name.ToString());
        }

        public enum Buttons
        {
            Start,
            Cancel,
        }

        public override void OnResponse(NetState state, RelayInfo info) 
		{ 		
			Mobile m = state.Mobile;
			//BaseCreature oski = new GMTopukMonster();
		
			switch ( info.ButtonID ) 
			{
				case (int)Buttons.Start:
				{
					/*if( info.IsSwitched ( 50 ) )
					{
						if( info.Switches.Length == 1 )
						{
							World.Broadcast( 0x481, false, "Run Away (GM Topuk) Has Been Started." );
							
							/
							GMTopukControl.Running = true;
							oski.MoveToWorld( GMTopukControl.MonsterPoint, GMTopukControl.ArenaMap );
							/
							
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
							
							foreach ( Mobile pl in mobs ) 
							{
								new GMTopukTimer(pl).Start();
								
								if ( pl.AccessLevel > AccessLevel.Player)
								{
									pl.SendMessage(26,"{0} has started the run away tourney !",m.Name );
								}
								
								else if ((pl.AccessLevel == AccessLevel.Player)&&( !pl.Alive ))
								{
									pl.Resurrect();
									pl.SendGump( new GMTopukGump());
								}
								
								else if ((pl.AccessLevel == AccessLevel.Player)&&( pl.Alive ))
								{
									pl.SendGump( new GMTopukGump());
								}
								
								else
								{
									pl.SendMessage(38,"An Error Occured");
								}
							}
							
							m.MoveToWorld( GMTopukControl.StaffPoint, GMTopukControl.StaffMap );
							m.Hidden = true;
						}
						
						else
						{
							m.SendMessage( 38,"Bir queste daha ev sahipliði yapamazsýn");
							m.SendGump( new EventGump());
						}
					}*/
					
					if( info.IsSwitched ( 51 ) )
					{
						if( info.Switches.Length == 1 )
						{
							World.Broadcast( 0x481, false, "Pure Mage Turnuvasý Baþlamýþtýr." );
							new CloseGumpTimer().Start();
							
							/**/
							PureMageControl.Running = true;
							/**/
							
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
							
							foreach ( Mobile pl in mobs ) 
							{
								if ( pl.AccessLevel > AccessLevel.Player)
								{
									pl.SendMessage(26,"{0} Pure Mage Turnuvasý Baþladý !",m.Name );
								}
								
								else if ((pl.AccessLevel == AccessLevel.Player)&&( !pl.Alive ))
								{
									pl.Resurrect();
									pl.SendGump( new PublicMOGump());
								}
								
								else if ((pl.AccessLevel == AccessLevel.Player)&&( pl.Alive ))
								{
									pl.SendGump( new PublicMOGump());
								}
								
								else
								{
									pl.SendMessage(38,"Bir Hata Oluþtu");
								}
							}
							
							m.MoveToWorld( PureMageControl.StaffPoint, PureMageControl.StaffMap );
							m.Hidden = true;
						}
						
						else
						{
							m.SendMessage( 38,"Bir queste daha ev sahipliði yapamazsýn");
							m.SendGump( new EventGump());
						}
					}
					
					if( info.IsSwitched ( 52 ) )
					{
						if( info.Switches.Length == 1 )
						{
							World.Broadcast( 0x481, false, "Pure Warrior Turnuvasý Baþlamýþtýr." );
							new CloseGumpTimer().Start();
							
							/**/
							PureWarriorControl.Running = true;
							/**/
							
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
							
							foreach ( Mobile pl in mobs ) 
							{
								if ( pl.AccessLevel > AccessLevel.Player)
								{
									pl.SendMessage(26,"{0} Pure Warrior Turnuvasý Baþladý !",m.Name );
								}
								
								else if ((pl.AccessLevel == AccessLevel.Player)&&( !pl.Alive ))
								{
									pl.Resurrect();
									pl.SendGump( new PublicWOGump());
								}
								
								else if ((pl.AccessLevel == AccessLevel.Player)&&( pl.Alive ))
								{
									pl.SendGump( new PublicWOGump());
								}
								
								else
								{
									pl.SendMessage(38,"Bir Hata Oluþtu");
								}
							}
							
							m.MoveToWorld( PureWarriorControl.StaffPoint, PureWarriorControl.StaffMap );
							m.Hidden = true;
						}
						
						else
						{
							m.SendMessage( 38,"Bir queste daha ev sahipliði yapamazsýn");
							m.SendGump( new EventGump());
						}
					}

					if( info.IsSwitched ( 53 ) )
					{
						BaseCreature a = new PvMTitan();
						BaseCreature b = new PvMTitan();
						BaseCreature c = new PvMTitan();
                        BaseCreature d = new DemonKnight1();
						BaseCreature e = new PvMTitan();
						BaseCreature f = new PvMTitan();
						
						BaseCreature g = new PvMTitan();
						BaseCreature h = new PvMTitan();
						BaseCreature j = new PvMTitan();
						BaseCreature k = new PvMTitan();
						BaseCreature l = new PvMTitan();
						BaseCreature m1 = new PvMTitan();

						BaseCreature n = new PvMTitan();
						Mobile o = new PvMSpy();
						
						BaseDoor bd = new BarredMetalDoor( DoorFacing.EastCCW );
						
						Item i = new PvMExitGate();
						
						if( info.Switches.Length == 1 && PvMControl.Running == false )
						{
							
							World.Broadcast( 0x481, false, "TitanQuest Baþlamýþtýr" );
							new CloseGumpTimer().Start();
							PvMControl.Running = true;
							PvMControl.TitanCount = 12;
							
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
							
							foreach ( Mobile pl in mobs ) 
							{
								if ( pl.AccessLevel > AccessLevel.Player)
								{
									pl.SendMessage(26,"{0} Bir Etkinliðe Ev Sahipliði Yapýyor!",m.Name );
									
								}
																
								else if ((pl.AccessLevel == AccessLevel.Player)&&( !pl.Alive ))
								{
									pl.Resurrect();
									pl.SendGump( new PublicPvMGump());
								}
								
								else if ((pl.AccessLevel == AccessLevel.Player)&&( pl.Alive ))
								{
									pl.SendGump( new PublicPvMGump());
								}
								
								else
								{
									pl.SendMessage(38,"Bir Hata Oluþtu.");
								}
							}
							
							m.X = 5725;
							m.Y = 875;
							m.Z = 0;
							m.Map = Map.Trammel;
							m.Hidden = true;
							
							a.MoveToWorld( Cell1, Map.Trammel );
							
							b.MoveToWorld( Cell2, Map.Trammel );
							
							
							c.MoveToWorld( Cell3, Map.Trammel );
							
							d.MoveToWorld( CellDemon, Map.Trammel );
							
							e.MoveToWorld( Cell4, Map.Trammel );
							
							f.MoveToWorld( Cell5, Map.Trammel );
							
							
							g.MoveToWorld( Cell6, Map.Trammel );
							
							h.MoveToWorld( Cell7, Map.Trammel );
							
							j.MoveToWorld( Cell8, Map.Trammel );
							
							k.MoveToWorld( Cell9, Map.Trammel );
							
							l.MoveToWorld( Cell10, Map.Trammel );

							m1.MoveToWorld( Cell11, Map.Trammel );
							
							n.MoveToWorld( Cell12, Map.Trammel );
							
						bd.X = 5731;
						bd.Y = 975;
						bd.Z = 0;
						bd.Map = Map.Trammel;
						bd.Locked = true;
						bd.KeyValue = 33;
							
						i.X = 5723;
						i.Y = 873;
						i.Z = 0;
						
						i.Map = Map.Trammel;
						i.Hue = 1152;
						i.Movable = false;
							
						}
					
						
						else
						{
							m.SendMessage( 38,"Birçok düðme basýldýðý için zaten çalýþan bir PVM vardýr.");
							m.SendGump( new EventGump());
						}	
					}
					
					if( info.IsSwitched ( 54 ) )
					{
						if( info.Switches.Length == 1 )
						{
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
			
							foreach ( Mobile pm in mobs ) 
							{
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && pm.Alive )
								pm.SendGump ( new DeathMatchGumpMage() );
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && !pm.Alive )
								{
									m.Resurrect();
									pm.SendGump( new DeathMatchGumpMage() );
								}

								new StartTimerMage(pm).Start();
							}

							World.Broadcast( 1153, false, "Deathmatch Turnuvasý Baþlamýþtýr [Mage]" );
							AutoMageControl.Running = true;
							
							
						m.MoveToWorld( AutoMageControl.StaffPoint, AutoMageControl.StaffMap );
						m.Hidden = true;
						}
						
						else
						{
							m.SendMessage( 38,"Yapamazsýnýz!!");
							m.SendGump( new EventGump());
						}
					}

					if( info.IsSwitched ( 55 ) )
					{
						if( info.Switches.Length == 1 )
						{
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
			
							foreach ( Mobile pm in mobs ) 
							{
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && pm.Alive )
								pm.SendGump ( new DeathMatchGumpWarrior() );
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && !pm.Alive )
								{
									m.Resurrect();
									pm.SendGump( new DeathMatchGumpWarrior() );
								}
				

								new StartTimerWarrior(pm).Start();
							}

							World.Broadcast( 1153, false, "Deathmatch Turnuvasý Baþlamýþtýr [Warrior]" );
							AutoWarriorControl.Running = true;
							
						m.MoveToWorld( AutoWarriorControl.StaffPoint, AutoWarriorControl.StaffMap );
						m.Hidden = true;
						}
						
						else
						{
							m.SendMessage( 38,"Yapamazsýnýz!!");
							m.SendGump( new EventGump());
						}
					}
					
					if( info.IsSwitched ( 57 ) )
					{
						if( info.Switches.Length == 1 )
						{
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
			
							foreach ( Mobile pm in mobs ) 
							{
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && pm.Alive )
								pm.SendGump ( new PublicTeamMageGump() );
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && !pm.Alive )
								{
									m.Resurrect();
									pm.SendGump( new PublicTeamMageGump() );
								}
				

								new StartTimerTeamMage(pm).Start();
							}

							World.Broadcast( 1153, false, "Takým DeathMatch Baþlamýþtýr [Mage]" );
							TeamMageControl.Running = true;
							
							m.MoveToWorld ( TeamMageControl.StaffPoint, TeamMageControl.StaffMap );
							m.Hidden = true;
						}
						
						else
						{
							m.SendMessage( 38,"Yapamazsýnýz!!");
							m.SendGump( new EventGump());
						}
					}
					
					if( info.IsSwitched ( 58 ) )
					{
						if( info.Switches.Length == 1 )
						{
							ArrayList mobs = new ArrayList( World.Mobiles.Values ); 
			
							foreach ( Mobile pm in mobs ) 
							{
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && pm.Alive )
								pm.SendGump ( new PublicTeamWarriorGump() );
								if ( pm.AccessLevel < AccessLevel.Counselor && pm.Backpack != null && !pm.Alive )
								{
									m.Resurrect();
									pm.SendGump( new PublicTeamWarriorGump() );
								}
				

								new StartTimerTeamWarrior(pm).Start();
							}

							World.Broadcast( 1153, false, "Takým DeatMatch Baþlamýþtýr [Warrior]" );
							TeamWarriorControl.Running = true;
							
							m.MoveToWorld ( TeamWarriorControl.StaffPoint, TeamWarriorControl.StaffMap );
							m.Hidden = true;
						}
						
						else
						{
							m.SendMessage( 38,"Yapamazsýnýz");
							m.SendGump( new EventGump());
						}
					}

					break;
				}
				
				case (int)Buttons.Cancel:
				{
					m.SendMessage( 38,"Ýptal Ettiniz" );
					AutoMageControl.Running = false;
					AutoWarriorControl.Running = false;
					PureMageControl.Running = false;
					PureWarriorControl.Running = false;
					PvMControl.Running = false;
					TeamMageControl.Running = false;
					TeamWarriorControl.Running = false;
					//GMTopukControl.Running = false;
					break;
				}
            }
        }
    }
}

		
	
