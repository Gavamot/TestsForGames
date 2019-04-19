using System;
using System.Collections.Generic;
using System.Text;

namespace SkillsTree
{
    public class SkillsTree<T> where T : ISkill
    {
        public readonly List<SkillsTreeNode<T>> Skills = new List<SkillsTreeNode<T>>();
    }
}
