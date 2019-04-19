using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsTree
{
    public class Skill : ISkill
    {
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            var item = obj as Skill;
            if (item == null)
                return false;
            return Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
