using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartinMatta_MerlinCore.Spells
{
    public class SpellInfo
    {
        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }

        public static implicit operator SpellInfo(string data)
        {
            string[] parts = data.Split(';');
            try
            {
                return new SpellInfo
                {
                    Name = parts[0],
                    SpellType = parts[1] == "projectile" ? SpellType.PROJECTILE : SpellType.SELFCAST,
                    AnimationPath = parts[2],
                    AnimationWidth = int.Parse(parts[3]),
                    AnimationHeight = int.Parse(parts[4]),
                    EffectNames = parts[5].Split(',')
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"data: {data}");
                return null;
            }
        }
    }
}
