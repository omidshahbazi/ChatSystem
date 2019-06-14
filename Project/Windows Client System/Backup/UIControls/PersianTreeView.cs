using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BinarySoftCo.UIControls
{
    public class PersianTreeView : TreeView
    {
        private TreeNode GetNodeByNameCore(TreeNode Node, string Name)
        {
            foreach (TreeNode tn in Node.Nodes)
                if (tn.Name == Name)
                    return tn;
                else
                {
                    TreeNode t = GetNodeByNameCore(tn, Name);
                    //
                    if (t != null)
                        return t;
                }
            //
            return null;
        }

        public TreeNode GetNodeByName(string Name)
        {
            foreach (TreeNode tn in Nodes)
                if (tn.Name == Name)
                    return tn;
                else
                {
                    TreeNode t = GetNodeByNameCore(tn, Name);
                    //
                    if (t != null)
                        return t;
                }
            //
            return null;
        }

        private void SetImageKeyToAllCore(TreeNode Node, string Key)
        {
            foreach (TreeNode tn in Node.Nodes)
            {
                tn.ImageKey = tn.SelectedImageKey = Key;
                //
                SetImageKeyToAllCore(tn, Key);
            }
        }

        public void SetImageKeyToAll(string Key)
        {
            foreach (TreeNode tn in Nodes)
            {
                tn.ImageKey = tn.SelectedImageKey = Key;
                //
                SetImageKeyToAllCore(tn, Key);
            }
        }

        public PersianTreeView()
            : base()
        {
        }
    }
}
