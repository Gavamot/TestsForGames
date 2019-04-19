using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SkillsTree
{
    public class SkillTreeRep
    {
        public SkillsTreeNode<Skill> CreateNode(string name, bool isLocked = true)
            => new SkillsTreeNode<Skill>
            {
                Skill = new Skill {Name = name},
                IsLocked = isLocked
            };

        private void BindOneByOne(SkillsTreeNode<Skill> parent, SkillsTreeNode<Skill> child)
        {
            parent.Children.Add(child);
            child.Parents.Add(parent);
        }

        private SkillsTreeNode<Skill> CreateAndBind(SkillsTreeNode<Skill> parent, string name, bool isLocked = true)
        {
            var res = CreateNode(name, isLocked);
            BindOneByOne(parent, res);
            return res;
        }

        public SkillsTree<Skill> Get1()
        {
            var res = new SkillsTree<Skill>();
            var mage = CreateNode("Mage", false);
            res.Skills.Add(mage);
                var fireball = CreateAndBind(mage, "Fireball");
                    var electroshock = CreateAndBind(fireball,"Electroshock");
                        var thunderbolt = CreateAndBind(electroshock, "Thunderbolt");
                    var freeze = CreateAndBind(fireball, "Freeze");
                        var snowstorm = CreateAndBind(freeze, "Snowstorm");
            return res;
        }

        public SkillsTree<Skill> Get2()
        {
            var res = new SkillsTree<Skill>();
            var warrior = CreateNode("Warrior", false);
            res.Skills.Add(warrior);
               var strike = CreateAndBind(warrior, "Strike");
                  var doubleStrike = CreateAndBind(strike, "Double Strike");
                  var slash = CreateAndBind(strike, "Slash");
                    var roundhouseKick = CreateAndBind(slash, "Roundhouse Kick");
            var hit = CreateAndBind(warrior, "Hit");
                var knockout = CreateAndBind(hit, "Knockout");
                    roundhouseKick.Parents.Add(knockout);
            return res;
        }
    }
}
