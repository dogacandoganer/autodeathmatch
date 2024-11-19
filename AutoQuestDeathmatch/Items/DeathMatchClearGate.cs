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
    public class DeathMatchClearGate : Item
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
        public DeathMatchClearGate() : base(0xF6C)
		{
			Movable = false;
			Hue = 1152;// Hue
			Name = "Etkinlik Çýkýþ";//Name
			Light = LightType.Circle300;
			
            m_Teleport = true;//Default false
			m_DestPoint = new Point3D( 4595, 3574, 76 );
			DestMap = Map.Felucca;
		}

        public void TeleportPlayer(Mobile m)
        {
            if (m_Teleport == true)
            {
                m.Location = m_DestPoint;
                m.Map = m_DestMap;
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

		public DeathMatchClearGate( Serial serial ) : base( serial )
		{
		}

		public override bool OnMoveOver( Mobile m )
		{
			PlayerMobile pm = m as PlayerMobile;
			
			if((m.Player)&&(pm.Alive)&&(pm.AccessLevel == AccessLevel.Player ))
			{
                TeleportPlayer(pm);
				ClearPlayer(pm);
				pm.EventType = EventType.None;
				pm.EventKill = 0;
				pm.EventDeath = 0;
            }
			
			if (!m.Player)
			{
				m.PublicOverheadMessage(0, 37, false, "çökmeye neden olabilir, ama anti-crash sistemi çalýþýyor");
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