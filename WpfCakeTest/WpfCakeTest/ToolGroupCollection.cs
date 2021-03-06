﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCakeTest.Model;

namespace WpfCakeTest
{
    class ToolGroupCollection : IList<ToolGroup>
    {
        protected List<ToolGroup> Groups { get; set; } = new List<ToolGroup>();
        public ToolGroup this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ToolGroup this[string index]
        {
            get => ((IList<ToolGroup>)Groups).First(t => t.Name.Equals(index, StringComparison.InvariantCultureIgnoreCase));
            set
            {
                Groups[Groups.FindIndex(t => t.Name.Equals(index, StringComparison.InvariantCultureIgnoreCase))] = value;
            }
        }//索引器

        public int Count => ((IList<ToolGroup>)Groups).Count;

        public bool IsReadOnly => ((IList<ToolGroup>)Groups).IsReadOnly;


        public void Add(ToolGroup item)
        {
            ((IList<ToolGroup>)Groups).Add(item);
        }

        public void Clear()
        {
            ((IList<ToolGroup>)Groups).Clear();
        }

        public bool Contains(ToolGroup item)
        {
            return ((IList<ToolGroup>)Groups).Contains(item);
        }

        public void CopyTo(ToolGroup[] array, int arrayIndex)
        {
            ((IList<ToolGroup>)Groups).CopyTo(array, arrayIndex);
        }

        public IEnumerator<ToolGroup> GetEnumerator()
        {
            return ((IList<ToolGroup>)Groups).GetEnumerator();
        }

        public int IndexOf(ToolGroup item)
        {
            return ((IList<ToolGroup>)Groups).IndexOf(item);
        }

        public void Insert(int index, ToolGroup item)
        {
            ((IList<ToolGroup>)Groups).Insert(index, item);
        }

        public bool Remove(ToolGroup item)
        {
            return ((IList<ToolGroup>)Groups).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<ToolGroup>)Groups).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<ToolGroup>)Groups).GetEnumerator();
        }
    }
}
