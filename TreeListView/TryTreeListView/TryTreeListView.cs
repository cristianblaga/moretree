using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;
using System.Diagnostics;
using System.Collections.Generic;

namespace TryTreeListView
{
    
    /// <summary>
    /// Summary description for TryTreeListView.
    /// </summary>
    public class TryTreeListView : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeListView treeListView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
        private Button button3;
        private Button button4;
        private System.ComponentModel.IContainer components;

		public TryTreeListView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer1 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TryTreeListView));
            this.treeListView1 = new System.Windows.Forms.TreeListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllowColumnReorder = true;
            this.treeListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeListView1.CheckBoxes = System.Windows.Forms.CheckBoxesTypes.Recursive;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            treeListViewItemCollectionComparer1.Column = 0;
            treeListViewItemCollectionComparer1.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.treeListView1.Comparer = treeListViewItemCollectionComparer1;
            this.treeListView1.HideSelection = false;
            this.treeListView1.LabelEdit = true;
            this.treeListView1.Location = new System.Drawing.Point(5, 5);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.Size = new System.Drawing.Size(1005, 303);
            this.treeListView1.SmallImageList = this.imageList1;
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.UseCustomDrawHeader = true;
            this.treeListView1.BeforeLabelEdit += new System.Windows.Forms.TreeListViewBeforeLabelEditEventHandler(this.treeListView1_BeforeLabelEdit);
            this.treeListView1.BeforeExpand += new System.Windows.Forms.TreeListViewCancelEventHandler(this.treeListView1_BeforeExpand);
            this.treeListView1.BeforeCollapse += new System.Windows.Forms.TreeListViewCancelEventHandler(this.treeListView1_BeforeCollapse);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Attribute";
            this.columnHeader2.Width = 100;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(10, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add / Remove All";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(852, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(153, 26);
            this.button2.TabIndex = 2;
            this.button2.Text = "Expand / Collapse All";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(320, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(153, 26);
            this.button3.TabIndex = 3;
            this.button3.Text = "allocate 1000";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(498, 318);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(153, 26);
            this.button4.TabIndex = 4;
            this.button4.Text = "deallocate 1000";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TryTreeListView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(1015, 349);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeListView1);
            this.Name = "TryTreeListView";
            this.Text = "TryTreeListView";
            this.Load += new System.EventHandler(this.TryTreeListView_Load);
            this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new TryTreeListView());
		}

		private void TryTreeListView_Load(object sender, System.EventArgs e)
		{
			AddItems();
		}

		private void treeListView1_BeforeExpand(object sender, System.Windows.Forms.TreeListViewCancelEventArgs e)
		{
			if(e.Item.ImageIndex == 1) e.Item.ImageIndex = 2;
		}

		private void treeListView1_BeforeCollapse(object sender, System.Windows.Forms.TreeListViewCancelEventArgs e)
		{
			if(e.Item.ImageIndex == 2) e.Item.ImageIndex = 1;
		}

		private void treeListView1_BeforeLabelEdit(object sender, System.Windows.Forms.TreeListViewBeforeLabelEditEventArgs e)
		{
			if(e.Item.ImageIndex < 1 || e.Item.ImageIndex > 2)
				e.ColumnIndex = 0;
			if(e.ColumnIndex == 1)
			{
				ComboBox combobox = new ComboBox();
				combobox.Items.AddRange(new string[]{"New value 1","New value 2","New value 3"});
				e.Editor = combobox;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            if (treeListView1.Items.Count > 0)
                treeListView1.Items.Clear();
            else
                AddItems();
        }

		bool collapse = false;
		private void button2_Click(object sender, System.EventArgs e)
		{
			//if(collapse) treeListView1.CollapseAll();
			//else treeListView1.ExpandAll();
			//collapse = !collapse;
		}

       
        private void AddItems()
		{
			

            var ic = new TreeListViewItem("XXX", 0);
            var ic1 = new TreeListViewItem("XXy", 0);
            var ic2 = new TreeListViewItem("XXz", 0);

			var myCustomSubItem = new TreeListViewSubItem()
			{
				Text = "Text",
				UseGradientBackground = true,
				BackgroundGradientStartColor = Color.Red,
				FillRatio = .6,
			};

			ic1.SubItems.Add(myCustomSubItem);

            ic1.SubItems.Add(new Button2Item("r ic1"));
            
            ic.SubItems.Add(new Button2Item("r ic"));

            ic.Items.Add(ic1);
            ic1.Items.Add(ic2);
            treeListView1.Items.Add(ic);
            
            
           
        }
	
		private enum DrivesDescr{First, Second, Third, Fourth}
		private enum Drives{C, D, E, Z}

        List<TreeListViewItem> items1k = new List<TreeListViewItem>();
        private void button3_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < 1000; ++i)
            {
                Button2Item referencedButton = new Button2Item("ref");
                TreeListViewItem referencedListItem = new TreeListViewItem("new Hierarchy", 0);
                referencedListItem.SubItems.Add(referencedButton);
                items1k.Add(referencedListItem);
                treeListView1.Items.Add(referencedListItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //dealocate the list
            foreach (var li in items1k)
            {
                var theButton = li.SubItems[1] as IDisposable;
                treeListView1.Items.Remove(li);
                theButton.Dispose();

            }
        }

    
    }

    public class ButtonItem : TreeListViewItem, IControlWrappedItem, IDisposable
    {
        Button _b = new Button() { Text = "Push me" };
        public Control Control { get => _b; set => throw new NotImplementedException(); }
        public ButtonItem()
        {
            _b.Visible = false;
            _b.Click += (sender, e) =>
            {
                MessageBox.Show("Hello dude.");
            };
        }

        public void Dispose()
        {
            _b.Dispose();
        }
    }

    public class Button2Item : ListViewSubItem, IControlWrappedItem,IDisposable
    {

        Button _b = new Button() { Text = "Push me too" };
        public Control Control { get => _b; set => throw new NotImplementedException(); }
        public Button2Item(string label)
        {
            _b.FlatStyle = FlatStyle.System;
            _b.Text = label;
            _b.Visible = false;
            _b.Click += (sender, e) =>
            {
                MessageBox.Show("Hello dude from 2.");
            };
            _b.HandleDestroyed += (sender, e) => {
                Debug.WriteLine($" handle destroyed!\n");
            };
        }

        public void Dispose()
        {
            _b.Dispose();
        }
    }
}
