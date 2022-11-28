using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class SpellDataProvider : ISpellDataProvider
    {
        private class SpellEffect
        {
            public string Name { get; set; }
            public int Cost { get; set; }
        }

        private static SpellDataProvider instance = new SpellDataProvider();
        private Dictionary<string, SpellInfo> spellInfos;
        private Dictionary<string, int> effectInfos;

        private SpellDataProvider()
        {

        }

        public static SpellDataProvider GetInstance()
        {
            if (instance == null)
                instance = new SpellDataProvider();
            
            return instance;
        }

        public Dictionary<string, int> GetSpellEffects()
        {
            if (effectInfos == null)
                this.LoadEffectInfo();

            return effectInfos;
        }

        private void LoadEffectInfo()
        {
            effectInfos = new Dictionary<string, int>();
            string json = File.ReadAllText("resources/effects.json");
            List<SpellEffect> parsed = JsonConvert.DeserializeObject<List<SpellEffect>>(json);

            foreach (SpellEffect effect in parsed)
            {
                effectInfos.Add(effect.Name, effect.Cost);
            }
        }

            private void LoadSpellInfo()
        {
            spellInfos = new Dictionary<string, SpellInfo>();

            string[] lines = File.ReadAllLines("resources/spells.csv");

            foreach (string line in lines[1..])
            {
                string[] parts = line.Split(';');
                spellInfos.Add(parts[0], (SpellInfo)line);
            }
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            if (spellInfos == null)
                this.LoadSpellInfo();

            return spellInfos;
        }
    }
}
