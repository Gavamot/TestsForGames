using System.Collections.Generic;
using System.Linq;

namespace SkillsTree
{
    public class SkillsTreeNode<T> where T : ISkill
    {
        public T Skill { get; set; }
        public bool IsLocked { get; set; } = true; // This is fast way but better make private field and create method
        public bool CanBeUnlocked => !Parents.Any(x => x.IsLocked);
        public readonly List<SkillsTreeNode<T>> Parents = new List<SkillsTreeNode<T>>();
        public readonly List<SkillsTreeNode<T>> Children = new List<SkillsTreeNode<T>>();
    }
}