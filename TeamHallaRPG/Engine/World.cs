using System.Collections.Generic;

namespace Engine
{
    public class World
    {
        public static readonly List<Item> Items = new List<Item>();
        public static readonly List<Monster> Monsters = new List<Monster>();
        public static readonly List<Quest> Quests = new List<Quest>();
        public static readonly List<Location> Locations = new List<Location>();

        public const int ITEM_ID_NOJ = 1;
        public const int ITEM_ID_SHAL_SSKA = 2;
        public const int ITEM_ID_TENISKA_SSKA = 3;
        public const int ITEM_ID_POLICEISKA_KASKA = 4;
        public const int ITEM_ID_POLICEISKI_SHTIT = 5;
        public const int ITEM_ID_BUHALKA = 6;
        public const int ITEM_ID_AMFET = 7;
        public const int ITEM_ID_SHAL_MAINA = 8;
        public const int ITEM_ID_TENISKA_MAINA = 9;
        public const int ITEM_ID_BILET_ZA_MACH = 10;

        public const int MONSTER_ID_CSKA_FAN = 1;
        public const int MONSTER_ID_POLICEMAN = 2;
        public const int MONSTER_ID_BOTEV_FAN = 3;

        public const int QUEST_ID_CLEAR_BORISOVA_GARDEN = 1;
        public const int QUEST_ID_CLEAR_1VO_RPU = 2;

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_VITOSHKA = 2;
        public const int LOCATION_ID_STADIONA = 3;
        public const int LOCATION_ID_KRUCHMA = 4;
        public const int LOCATION_ID_BORISOVA_GARDEN = 5;
        public const int LOCATION_ID_NKP = 6;
        public const int LOCATION_ID_1VO_RPU = 7;
        public const int LOCATION_ID_AVTOBUS = 8;
        public const int LOCATION_ID_PLOVDIV = 9;

        static World()
        {
            PopulateItems();
            PopulateMonsters();
            PopulateQuests();
            PopulateLocations();
        }

        private static void PopulateItems()
        {
            Items.Add(new Weapon(ITEM_ID_NOJ, "Noj", "Noja", 0, 5));
            Items.Add(new Item(ITEM_ID_SHAL_SSKA, "Shal na cska", "Shalove na cska"));
            Items.Add(new Item(ITEM_ID_TENISKA_SSKA, "teniska na cska", "Teniski na cska"));
            Items.Add(new Item(ITEM_ID_POLICEISKA_KASKA, "Policeiska kaska", "Policeiski kaski"));
            Items.Add(new Item(ITEM_ID_POLICEISKI_SHTIT, "Policeiski shtit", "Policeiski shtitove"));
            Items.Add(new Weapon(ITEM_ID_BUHALKA, "Buhalka", "Buhalki", 3, 10));
            Items.Add(new HealingPotion(ITEM_ID_AMFET, "Amfet", "Amfeta", 5));
            Items.Add(new Item(ITEM_ID_SHAL_MAINA, "Shal na botev pld", "shalove na botev pld"));
            Items.Add(new Item(ITEM_ID_TENISKA_MAINA, "Teniska na botev pld", "Teniski na botev pld"));
            Items.Add(new Item(ITEM_ID_BILET_ZA_MACH, "Bilet za mach", "Bileta za machove"));
        }

        private static void PopulateMonsters()
        {
            Monster cskaFan = new Monster(MONSTER_ID_CSKA_FAN, "Ultras cska", 5, 3, 10, 3, 3);
            cskaFan.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHAL_SSKA), 75, false));
            cskaFan.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TENISKA_SSKA), 75, true));

            Monster policeman = new Monster(MONSTER_ID_POLICEMAN, "Policai", 5, 3, 10, 3, 3);
            policeman.LootTable.Add(new LootItem(ItemByID(ITEM_ID_POLICEISKA_KASKA), 75, false));
            policeman.LootTable.Add(new LootItem(ItemByID(ITEM_ID_POLICEISKI_SHTIT), 75, true));

            Monster botevFan = new Monster(MONSTER_ID_BOTEV_FAN, "Bultras", 20, 5, 40, 10, 10);
            botevFan.LootTable.Add(new LootItem(ItemByID(ITEM_ID_SHAL_MAINA), 75, true));
            botevFan.LootTable.Add(new LootItem(ItemByID(ITEM_ID_TENISKA_MAINA), 25, false));

            Monsters.Add(cskaFan);
            Monsters.Add(policeman);
            Monsters.Add(botevFan);
        }

        private static void PopulateQuests()
        {
            Quest clearBorisovaGarden =
                new Quest(
                    QUEST_ID_CLEAR_BORISOVA_GARDEN,
                    "Pochisti Borisovata gradina",
                    "Ubivai praseta v Borisovata i donesi 3 tehni shala.Za nagrada shte poluchish amfeti i 10 lea.", 20, 10);

            clearBorisovaGarden.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_SHAL_SSKA), 3));

            clearBorisovaGarden.RewardItem = ItemByID(ITEM_ID_AMFET);

            Quest clear1voRpu =
                new Quest(
                    QUEST_ID_CLEAR_1VO_RPU,
                    "Dokaji che si tegav",
                    "Vlez v 1vo raionno i prichini bezredici.Donesi 3 policeiski kaski i shte poluchish bilet i 20 lea.", 20, 20);

            clear1voRpu.QuestCompletionItems.Add(new QuestCompletionItem(ItemByID(ITEM_ID_POLICEISKA_KASKA), 3));

            clear1voRpu.RewardItem = ItemByID(ITEM_ID_BILET_ZA_MACH);

            Quests.Add(clearBorisovaGarden);
            Quests.Add(clear1voRpu);
        }

        private static void PopulateLocations()
        {
            // Create each location
            Location home = new Location(LOCATION_ID_HOME, "Vkushti", "Home, sweet home <3");

            Location vitoshka = new Location(LOCATION_ID_VITOSHKA, "Vitoshka", "Centura na Sofia ne e nishto specialno...ima prekaleno mnogo hora i postoqnno se pitash 'kakvo pravq tuk?'");

            Location kruchma = new Location(LOCATION_ID_KRUCHMA, "Kruchma", "Vlizash v 12 na obqd, a vsichki tuk sa veche piqni");
            kruchma.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_BORISOVA_GARDEN);

            Location borisovaGradina = new Location(LOCATION_ID_BORISOVA_GARDEN, "Borisovata Gradina", "Pulno s praseta, metuli i kuki. Nepriqtno mqsto...");
            borisovaGradina.MonsterLivingHere = MonsterByID(MONSTER_ID_CSKA_FAN);

            Location magazinaNaLevski = new Location(LOCATION_ID_NKP, "NKP, magazina na Levski", "Lichi si ot kilometri kakvo e. Otpred sedqt nqkolko choveka ot sofiq zapad i obsujdat nablijavashtiq mach");
            magazinaNaLevski.QuestAvailableHere = QuestByID(QUEST_ID_CLEAR_1VO_RPU);

            Location purvoRaionno = new Location(LOCATION_ID_1VO_RPU, "1vo raionno", "Policaite tuk imat slavata na edni ot nai-zlobnite v Sofiq.Dosega beshe chuval samo legendi za tova mqsto.");
           purvoRaionno.MonsterLivingHere = MonsterByID(MONSTER_ID_POLICEMAN);

            Location stadiona = new Location(LOCATION_ID_STADIONA, "Nacionalen Stadion Vasil Levski", "Na vhoda ima ogromna opashka,po dobre poburzai i si prigotvi bileta",
                ItemByID(ITEM_ID_BILET_ZA_MACH));

            Location avtobusa = new Location(LOCATION_ID_AVTOBUS, "Avtobus", "Reshavash da se kachish i da vidish kude shte te otvede");

            Location plovdiv = new Location(LOCATION_ID_PLOVDIV, "Mainatown", "Avtobusa spira i ti izvednuj se okazvash ...v Plovdiv.Horata tuk govorqt stranno i ti razbirash che pribiraneto nqma da e lesno");
            plovdiv.MonsterLivingHere = MonsterByID(MONSTER_ID_BOTEV_FAN);

            // Link the locations together
            home.LocationToNorth = vitoshka;

            vitoshka.LocationToNorth = kruchma;
            vitoshka.LocationToSouth = home;
            vitoshka.LocationToEast = stadiona;
            vitoshka.LocationToWest = magazinaNaLevski;

            magazinaNaLevski.LocationToEast = vitoshka;
            magazinaNaLevski.LocationToWest = purvoRaionno;

            purvoRaionno.LocationToEast = magazinaNaLevski;

            kruchma.LocationToSouth = vitoshka;
            kruchma.LocationToNorth = borisovaGradina;

            borisovaGradina.LocationToSouth = kruchma;

            stadiona.LocationToEast = avtobusa;
            stadiona.LocationToWest = vitoshka;

            avtobusa.LocationToWest = stadiona;
            avtobusa.LocationToEast = plovdiv;

            plovdiv.LocationToWest = avtobusa;

            // Add the locations to the static list
            Locations.Add(home);
            Locations.Add(vitoshka);
            Locations.Add(stadiona);
            Locations.Add(kruchma);
            Locations.Add(borisovaGradina);
            Locations.Add(magazinaNaLevski);
            Locations.Add(purvoRaionno);
            Locations.Add(avtobusa);
            Locations.Add(plovdiv);
        }

        public static Item ItemByID(int id)
        {
            foreach (Item item in Items)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public static Monster MonsterByID(int id)
        {
            foreach (Monster monster in Monsters)
            {
                if (monster.ID == id)
                {
                    return monster;
                }
            }

            return null;
        }

        public static Quest QuestByID(int id)
        {
            foreach (Quest quest in Quests)
            {
                if (quest.ID == id)
                {
                    return quest;
                }
            }

            return null;
        }

        public static Location LocationByID(int id)
        {
            foreach (Location location in Locations)
            {
                if (location.ID == id)
                {
                    return location;
                }
            }

            return null;
        }
    }
}