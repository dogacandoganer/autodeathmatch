using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections; 

namespace Server.Gumps
{
	public class ClearEquipsGump : Gump
	{
		public ClearEquipsGump()
			: base( 0, 0 )
		{
			this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(214, 168, 335, 221, 3600);
			this.AddLabel(232, 192, 37, @"Aþaðýdaki öðeler dünyadan silinecek!");
			this.AddLabel(243, 223, 1152, @"If you press yes button");
			this.AddHtml( 237, 266, 291, 56, "<basefont color=#FF0000>EventChest, Event Legs, Event Gloves, Event Helm, Event Kryss,  Event Shield,  Event Lantern, Event Robe</basefont>", (bool)false, (bool)false);
			this.AddImage(164, 126, 10400);
			this.AddImage(513, 353, 10412);
			this.AddButton(300, 341, 249, 248, 2, GumpButtonType.Reply, 0);
			this.AddButton(395, 340, 242, 243, 1, GumpButtonType.Reply, 0);

		}
		
		public enum Buttons
		{
		}
		
		public override void OnResponse( NetState state, RelayInfo info ) 
		{ 		
			Mobile m = state.Mobile;
		
			switch ( info.ButtonID ) 
			{
				case 2:
				{
					ArrayList items = new ArrayList( World.Items.Values );
					ArrayList mobs =  new ArrayList( World.Mobiles.Values );
					
					foreach( Item i in items )
					{
						if( i != null )
						{
							if(( i is EventChest )&&( i != null ))
							{
								i.Delete();
							}	
							
							if(( i is EventLegs )&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is EventGloves )&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is EventKryss )&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is EventShield )&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is EventHelm )&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is EventRobe )&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is EventLantern)&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is EventSandal )&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is DeathMatchClearGate)&&(i != null ))
							{
								i.Delete();
							}
							
							if(( i is BagOfAga)&&(i != null ))
							{
								i.Delete();
							}
							
							if(( i is BagOfAids)&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is BagOfCure)&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is BagOfHeal)&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is BagOfPoison)&&( i != null ))
							{
								i.Delete();
							}
							
							if(( i is BagOfStr)&&( i != null ))
							{
								i.Delete();
							}
						}
					}
						


					foreach( Mobile zm in mobs )
					{
						PlayerMobile pm = null;
						if(zm is PlayerMobile)
						{
							pm = zm as PlayerMobile;
						}
						
						if (pm != null && pm.EventType != EventType.None )
						{
							pm.EventType = EventType.None;
							pm.EventDeath = 0;
							pm.EventKill = 0;
						}
					}

					m.SendMessage( 62,"Yapýldý");
					break;
				}
				
				case 1: 
				{
					m.SendMessage( 62,"Ýptal" );
					break;
				}
				
				case 0:
				{
					m.SendMessage( 37,"Ýptal");
					break;
				}
				
			}
		}
	}
}