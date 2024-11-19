/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using System.Collections;
using System.Web.Mail;
using System.IO;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Accounting;
using Server.Prompts;
using Server.Items;
using Server.Commands;

namespace Server.Scripts.Commands
{	
	public class ClearEquips
	{
		public static void Initialize() 
    	{ 
      		CommandSystem.Register( "ClearEquips", AccessLevel.GameMaster, new CommandEventHandler( ClearEquips_OnCommand ) );
    	} 

		public static void ClearEquips_OnCommand( CommandEventArgs e)
		{
			Mobile m = e.Mobile;
			{
				m.CloseGump( typeof( ClearEquipsGump));
				m.SendGump( new ClearEquipsGump());
			}
		}
	}
}