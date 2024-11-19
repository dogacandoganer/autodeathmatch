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

namespace Server.Gumps
{
	public class DeathMatchGumpMage : Gump
	{
		
		public DeathMatchGumpMage()
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
			this.AddLabel(202, 211, 1150, ServerSettings.Server_Name.ToString());
			this.AddLabel(543, 453, 1150, ServerSettings.Scripter_Name.ToString());
			this.AddLabel(204, 318, 37, @"Etkinliðe Katýlmak Ýstiyormusunuz ?");
			this.AddButton(347, 376, 10820, 10800, 2, GumpButtonType.Reply, 0);
			this.AddButton(491, 376, 10840, 10800, 1, GumpButtonType.Reply, 0);
			this.AddLabel(336, 318, 1160, @"Ölüm Maçý[mage]");
			this.AddLabel(384, 380, 0, @"Evet !");
			this.AddLabel(536, 380, 0, @"Hayýr !");

		}
		
		public enum Buttons
		{
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile m = state.Mobile;
			PlayerMobile pm = m as PlayerMobile;
			
			switch( info.ButtonID )
			{
				case 2:
				{
					if( m.Backpack != null )
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
					
					
						//pm.IsInChallenge = false;
						
						
						m.Map = Map.Malas;
						m.X = Utility.RandomList( 2356, 2357, 2358, 2359, 2360, 2361, 2362, 2363, 2364,
						2365, 2366, 2367, 2368, 2369, 2370, 2371, 2372, 2373, 2374, 2375, 2376, 2377, 2378, 2379 );
						m.Y = Utility.RandomList( 1116, 1117, 1118, 1119, 1120, 1121, 1122, 1123, 1124,
						1125, 1126, 1127, 1128, 1129, 1130, 1131, 1132, 1133, 1134, 1135, 1136, 1137, 1138, 1139 );
						m.Z = -90;
					
						if (( m.X == 2363)&&(m.Y == 1133))
							return;
						if (( m.X == 2363)&&(m.Y == 1132))
							return;
						if (( m.X == 2362)&&(m.Y == 1133))
							return;
						if (( m.X == 2362)&&(m.Y == 1132))
							return;
	
	
						if (( m.X == 2363)&&(m.Y == 1123))
							return;
						if (( m.X == 2363)&&(m.Y == 1122))
							return;
						if (( m.X == 2362)&&(m.Y == 1123))
							return;
						if (( m.X == 2362)&&(m.Y == 1122))
							return;
						
						
						if (( m.X == 2373)&&(m.Y == 1133))
							return;
						if (( m.X == 2373)&&(m.Y == 1132))
							return;
						if (( m.X == 2372)&&(m.Y == 1133))
							return;
						if (( m.X == 2372)&&(m.Y == 1132))
							return;
						
						
						if (( m.X == 2373)&&(m.Y == 1123))
							return;
						if (( m.X == 2373)&&(m.Y == 1122))
							return;
						if (( m.X == 2372)&&(m.Y == 1123))
							return;
						if (( m.X == 2372)&&(m.Y == 1122))
							return;
													
					
						m.Hidden = true;
						m.Frozen = true;
						m.Squelched = true;
						m.Blessed = true;
						m.Paralyzed = true;
						pm.EventType = EventType.AutoMage;
						m.SendMessage( 63,"Teþekkürler,Etkinliðe Katýldýnýz.");		
						
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
					m.SendMessage( 1153,"Etkinliðe Katýlmadýnýz");
					break;
				}
			}
		}
	}
}