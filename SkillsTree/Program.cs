using System;

namespace SkillsTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new SkillTreeRep();
            var tree1 = rep.Get1();
            var tree2 = rep.Get2();
            
            Console.ReadKey();
        }
    }
}
