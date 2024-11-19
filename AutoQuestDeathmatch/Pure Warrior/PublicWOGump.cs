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

namespace Server.DeathMatch
{
	public class PublicWOGump : Gump
	{
		public PublicWOGump()
			: base( 0, 0 )
		{
			this.Closable=false;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(161, 257, 499, 166, 2600);
			this.AddImage(340, 31, 1418);
			this.AddImage(610, 228, 1417);
			this.AddImage(131, 372, 1417);
			this.AddImage(111, 200, 10400);
			this.AddImage(628, 389, 10412);
			this.AddLabel(202, 211, 1153, ServerSettings.Server_Name.ToString());
			this.AddLabel(543, 453, 1153, ServerSettings.Scripter_Name.ToString());
			this.AddLabel(204, 318, 37, @"Etkinliðe Katýlmak Ýstiyormusunuz ?");
			this.AddButton(347, 376, 10820, 10800, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			this.AddButton(491, 376, 10840, 10800, (int)Buttons.Button2, GumpButtonType.Reply, 0);
			this.AddLabel(336, 318, 1160, @"Pure Warrior Turnuvasý");
			this.AddLabel(384, 380, 0, @"Evet !");
			this.AddLabel(536, 380, 0, @"Hayýr !");

		}
		
		public enum Buttons
		{
			Button1,
			Button2,
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile m = state.Mobile;
			PlayerMobile pm = m as PlayerMobile;	
			
			switch( info.ButtonID )
			{
				case 0:
				{
					if( m.Backpack != null )
					{
						try
						{
							Backpack bag = new Backpack();
							Container pack = m.Backpack;
							BankBox box = m.BankBox;
							ArrayList equipitems = new ArrayList(m.Items);
							ArrayList bagitems = new ArrayList( pack.Items );
							foreach (Item item in equipitems)
							{
								if ((item.Layer != Layer.Bank) && (item.Layer != Layer.Backpack) && (item.Layer != Layer.Hair) && (item.Layer != Layer.FacialHair) && (item.Layer != Layer.Mount))
								{
									pack.DropItem( item );
								}
							}
							Container pouch = m.Backpack;
							ArrayList finalitems = new ArrayList( pouch.Items );
							foreach (Item items in finalitems)
							{
								bag.DropItem(items);
							}
							box.DropItem(bag);
						}
					
						catch
						{
							World.Broadcast( 37, false,"{0} itemlerinizi bankanýza koyunuz,Aksi Takdirs", m.Name );
							return;
						}
					
						m.TithingPoints = 25000;
					
						pm.EventType = EventType.PureWarrior;
						//pm.IsInChallenge = false;
					
						m.MoveToWorld( PureWarriorControl.WarriorArena, PureWarriorControl.WarriorArenaMap );
					
						m.EquipItem( new EventKryss() );
						m.EquipItem( new EventShield() );					
						m.EquipItem( new EventHelm() );
						m.EquipItem( new EventGloves() );
						m.EquipItem( new EventChest() );
						m.EquipItem( new EventLegs() );
						m.EquipItem( new EventSandal() );
						
						m.AddToBackpack( new BagOfAga());
						m.AddToBackpack( new BagOfCure());
						m.AddToBackpack( new BagOfPoison());
						m.AddToBackpack( new BagOfHeal());
						m.AddToBackpack( new BagOfStr());
						m.AddToBackpack( new BagOfAids());
						m.AddToBackpack( new BookOfChivalry());
						m.SendMessage( 1153,"Pure Warrior TUrnuvasýna Katýldýnýz");

						if ( m.Mount != null )
						{
							IMount mount = m.Mount;	
							mount.Rider = null;
							if( mount is BaseMount )
							{
								BaseMount oldMount = (BaseMount)mount;	
								oldMount.Delete();
							}
						}	
					}
					break;
				}
				
				case 1:
				{
					m.SendMessage( 1152,"Etkinliðe Katýlmadýnýz");
					break;
				}
			}
		}
	}
}