using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary10;

namespace Lab11
{
    class TestCollections
    {
        Queue<Organization> link;
        Queue<string> key;
        SortedDictionary<Organization, Library> coll1;
        SortedDictionary<string, Library> coll2;

        public Queue<Organization> Link
        {
            get { return link; }
        }

        public Queue<string> Key
        {
            get { return key; }
        }

        public SortedDictionary<Organization, Library> Coll1
        {
            get { return coll1; }
        }
            
        public SortedDictionary<string, Library> Coll2
        {
            get { return coll2; }
        }

        public TestCollections(int size)
        {
            Random rnd = new Random();
            link = new Queue<Organization>();
            key = new Queue<string>();
            coll1 = new SortedDictionary<Organization, Library>();
            coll2 = new SortedDictionary<string, Library>();
            int y = 1800;
            for (int i = 0; i<size; i++)
            {
                Library temp = new Library("TestElement " + (i+1), y, rnd.Next(10, 101));
                link.Enqueue(temp.BaseOrg);
                key.Enqueue(temp.BaseOrg.ToString());
                coll1.Add(temp.BaseOrg, temp);
                coll2.Add(temp.BaseOrg.ToString(), temp);
                y++; 
            }
        }

        public void Add(Library newLib)
        {
            link.Enqueue(newLib.BaseOrg);
            key.Enqueue(newLib.BaseOrg.ToString());
            coll1.Add(newLib.BaseOrg, newLib);
            coll2.Add(newLib.BaseOrg.ToString(), newLib);
        }

        public void Remove(Library lib)
        {
            Queue<Organization> linkCopy = new Queue<Organization>();
            Organization[] tempArr = link.ToArray();
            foreach (Organization x in tempArr) if (!x.Equals(lib)) linkCopy.Enqueue(x);
            link = linkCopy;

            Queue<string> keyCopy = new Queue<string>();
            string[] tempArr1 = key.ToArray();
            foreach (string x in tempArr1) if (!(x == lib.BaseOrg.ToString())) keyCopy.Enqueue(x);
            key = keyCopy;

            Coll1.Remove(lib.BaseOrg);
            Coll2.Remove(lib.BaseOrg.ToString());
        }

    }
}
