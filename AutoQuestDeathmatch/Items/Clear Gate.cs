/*****************************************************
Lord RequaNer  ( DoðacanDoðaner )  coded for HallowMind

Date :  09/09/2012

dogacan_dd@hotmail.com
******************************************************/
using System;
using Server.Gumps;
using System.Collections; 
using Server;
using Server.Network; 
using Server.Items; 
using Server.Mobiles; 
using Server.Misc; 
using Server.Accounting; 

namespace Server.Items
{
    public class ClearGate : Item
	{
        private bool m_Teleport;
        private Map m_DestMap;
        private Point3D m_DestPoint;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool DoTeleport
        {
            get { return m_Teleport; }
            set { m_Teleport = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Map DestMap
        {
            get { return m_DestMap; }
            set { m_DestMap = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D DestPoint
        {
            get { return m_DestPoint; }
            set { m_DestPoint = value; }
        }

		[Constructable]
        public ClearGate() : base(0xF6C)
		{
			Movable = false;
			Hue = 1152;// Hue
			Name = "Event Exit Gate";//Name
			Light = LightType.Circle300;
			
            m_Teleport = false;//Default false
		}

        public void TeleportPlayer( Mobile m )
        {
			PlayerMobile pm = m as PlayerMobile;
			
            if (m_Teleport == true)
            {
                m.Location = m_DestPoint;
                m.Map = m_DestMap;
				pm.EventType = EventType.None;
            }
        }
		
		public void ClearPlayer( Mobile m )
		{
			Container pack = m.Backpack;	
			ArrayList equipitems = new ArrayList( m.Items );
			ArrayList bagitems = new ArrayList( pack.Items );
					
			foreach (Item item in equipitems)
			{
				if (( item is EventRobe )&&( item != null ))
				{
					item.Delete();					
				}
					
				if(( item is EventLantern )&&( item != null ))
				{
					item.Delete();
				}
					
				if(( item is FullSpellBook )&&( item != null ))
				{
					item.Delete();
				}
					
				if(( item is EventChest )&&( item != null ))
				{
					item.Delete();
				}	
								
				if(( item is EventLegs )&&( item != null ))
				{
					item.Delete();
				}
								
				if(( item is EventGloves )&&( item != null ))
				{
					item.Delete();
				}
								
				if(( item is EventKryss )&&( item != null ))
				{
					item.Delete();
				}
								
				if(( item is EventShield )&&( item != null ))
				{
					item.Delete();
				}
								
				if(( item is EventHelm )&&( item != null ))
				{
					item.Delete();
				}
								
				if(( item is EventSandal )&&( item != null ))
				{
					item.Delete();
				}
								
				if(( item is BookOfChivalry )&&(item != null ))
				{
					item.Delete();
				}
			}
			
			foreach( Item i in bagitems )
			{
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
				
				if(( i is BookOfChivalry )&&(i != null ))
				{
					i.Delete();
				}
			}
		}

		public ClearGate( Serial serial ) : base( serial )
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			PlayerMobile pm = m as PlayerMobile;
			if( m.Player && pm.Alive )
			{
                TeleportPlayer(pm);
				ClearPlayer(pm);
            }
			if (!m.Player)
			{
				m.PublicOverheadMessage(0, 37, false, "It may cause a crash, but anti-crash system is working");
			}

			return false;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

            writer.Write((bool)m_Teleport);
            writer.Write((Map)m_DestMap);
            writer.Write((Point3D)m_DestPoint);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            m_Teleport = reader.ReadBool();
            m_DestMap = reader.ReadMap();
            m_DestPoint = reader.ReadPoint3D();
		}
	}
}