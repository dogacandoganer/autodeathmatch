using System;
using Server.Misc;

namespace Server.Items
{
    public class QuestTokens : Item
    {
        [Constructable]
        public QuestTokens()
            : this(1)
        {
        }

        [Constructable]
        public QuestTokens(int amountFrom, int amountTo)
            : this(Utility.Random(amountFrom, amountTo))
        {
        }

        [Constructable]
        public QuestTokens(int amount)
            : base(0xEED)
        {
            Name = "Quest Tokens";
            Stackable = true;
            Weight = 0;
            Amount = amount;
            Hue = 433;
            LootType = LootType.Blessed;
        }

        public QuestTokens(Serial serial)
            : base(serial)
        {
        }

        /*public override int GetDropSound()
        {
            if (Amount <= 1)
                return 0x2E4;
            else if (Amount <= 5)
                return 0x2E5;
            else
                return 0x2E6;
        }

        public override Item Dupe(int amount)
        {
            return base.Dupe(new QuestTokens(amount), amount);
        }*/

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
