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
using Server.DeathMatch;
using Server.Commands;

namespace Server.DeathMatch
{	
	public class RunEvent
	{		
		public static void Initialize() 
    	{ 
      		CommandSystem.Register( "Event", AccessLevel.GameMaster, new CommandEventHandler( Event_OnCommand ) );
			CommandSystem.Register( "FinishEvent", AccessLevel.GameMaster, new CommandEventHandler( FinishEvent_OnCommand ) );
    	} 

		public static void Event_OnCommand( CommandEventArgs e)
		{
			Mobile m = e.Mobile;
			if( AutoMageControl.Running == false && AutoWarriorControl.Running == false && PureMageControl.Running == false &&
			PureWarriorControl.Running == false && PvMControl.Running == false && TeamMageControl.Running == false )
			//TeamWarriorControl.Running == false && GMTopukControl.Running == false )
			{
				m.SendGump( new EventGump());
			}
			else
				m.SendMessage( 38, "Üzgünüz, þu anda çalýþan bir etkinlik var");
		}	
		
		public static void FinishEvent_OnCommand( CommandEventArgs e )
		{
			ArrayList mobs =  new ArrayList( World.Mobiles.Values );
			ArrayList items = new ArrayList( World.Items.Values );
			
			Mobile m = e.Mobile;

			if( AutoMageControl.Running == true || AutoWarriorControl.Running == true || PureMageControl.Running == true ||
			PureWarriorControl.Running == true || PvMControl.Running == true || TeamMageControl.Running == true)
			//TeamWarriorControl.Running == true || GMTopukControl.Running == true )
			{	
				foreach( Mobile jack in mobs )
				{
					if( jack is PvMSpy )
					{
						jack.Delete();
					}
					
					/*if( jack is GMTopukMonster )
					{
						jack.Delete();
					}*/
					
					if( jack is PvMTitan )
					{
						jack.Delete();
					}
				}
				
				foreach( Item i in items )
				{
					if( i != null )
					{	
						if(( i is QuestTokens)&&( i != null ))
						{
							i.Delete();
						}
						
						if( i is PvMExitGate && i != null )
						{
							i.Delete();
						}
						
						if( i is BarredMetalDoor && i != null )
						{
							i.Delete();
						}
						
						if( i is Key && i != null )
						{
							i.Delete();
						}	
						
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
						
						if(( i is FullSpellBook)&&( i != null ))
						{
							if( i.Hue == 3 || i.Hue == 38 )
							{
								i.Delete();
							}
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
				
				m.SendMessage( 63,"Tüm Turnuvalar Tamamlanmýþtýr, Turnuvalardaki itemler Silinmiþtir" );
				
					AutoMageControl.Running = false;
					AutoWarriorControl.Running = false;
					PureMageControl.Running = false;
					PureWarriorControl.Running = false;
					PvMControl.Running = false;
					TeamMageControl.Running = false;
					TeamWarriorControl.Running = false;
					//GMTopukControl.Running = false;
					//GMTopukControl.Members = 0;
			}
			else
				m.SendMessage( 38,"Üzgünüm Event Devam Ediyor");
		}
	}					
}