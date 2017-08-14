using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Helpers
{
    public class MyListView : ListView
    {
        private bool mCreating;
        private bool mReadOnly;
        protected override void OnHandleCreated(EventArgs e)
        {
            mCreating = true;
            base.OnHandleCreated(e);
            mCreating = false;
        }
        public bool ReadOnly
        {
            get { return mReadOnly; }
            set { mReadOnly = value; }
        }
        protected override void OnItemCheck(ItemCheckEventArgs e)
        {
            if (!mCreating && mReadOnly) e.NewValue = e.CurrentValue;
            base.OnItemCheck(e);
        }
    }
}
