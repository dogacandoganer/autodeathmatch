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

namespace Server.DeathMatch
{
	public class PublicPvMGump : Gump
	{
		public PublicPvMGump()
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
			this.AddLabel(204, 318, 37, @"Katýlmak Ýstermisiniz ?");
			this.AddButton(347, 376, 10820, 10800, (int)Buttons.Button1, GumpButtonType.Reply, 0);
			this.AddButton(491, 376, 10840, 10800, (int)Buttons.Button2, GumpButtonType.Reply, 0);
			this.AddLabel(336, 318, 1160, @"Titan Quest");
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
					m.SendMessage( 1153,"Queste Katýldýnýz" );
					m.X = 5731;
					m.Y = 868;
					m.Z = 0;
					m.Map = Map.Trammel;
					m.Hidden = true;
					pm.EventType = EventType.PvM;
					break;
				}
				
				case 1:
				{
					m.SendMessage( 1152,"Queste Katýlmadýnýz!");
					break;
				}
			}
		}
	}
}